using AutoMapper;
using Microsoft.AspNet.Mvc;
using System;
using System.Linq;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Domain;
using WebVaanoli.Helpers;
using WebVaanoli.ViewModels.Radio;

namespace WebVaanoli.Controllers
{
    public class RadioController : Controller
    {
        private readonly IRadioRepository _radioRepository;
        private readonly IMappingEngine _mappingEngine;
        private readonly IGenreRepository _genreRepository;
        private readonly IStreamQualityRepository _streamQualityRepository;

        public RadioController(
            IRadioRepository radioRepository,
            IGenreRepository genreRepository,
            IStreamQualityRepository streamQualityRepository,
            IMappingEngine mappingEngine)
        {
            _radioRepository = radioRepository;
            _genreRepository = genreRepository;
            _streamQualityRepository = streamQualityRepository;
            _mappingEngine = mappingEngine;
        }

        public IActionResult Index()
        {

            var viewModel = new IndexViewModel();
            viewModel.Radios = _radioRepository.FindAll().ToList();
            return View(viewModel);
        }

        public IActionResult Detail(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return new BadRequestResult();
            }

            var selectedRadio = _radioRepository.Find(id);
            if (selectedRadio == null)
            {
                return new HttpNotFoundResult();
            }

            var detailViewModel = _mappingEngine.Map<DetailViewModel>(selectedRadio);

            return View(detailViewModel);
        }

        public IActionResult Edit(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return new BadRequestResult();
            }

            var selectedRadio = _radioRepository.Find(id);
            if (selectedRadio == null)
            {
                return new HttpNotFoundResult();
            }

            var editorViewModel = _mappingEngine.Map<EditorViewModel>(selectedRadio);
            SetupEditorViewModelSelectListItems(editorViewModel);
            return View("editor", editorViewModel);
        }

        public IActionResult Add()
        {
            var viewModel = new EditorViewModel();
            SetupEditorViewModelSelectListItems(viewModel);
            return View("Editor", viewModel);
        }

        public IActionResult Save(EditorViewModel editorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("editor", editorViewModel);
            }

            var radio = _mappingEngine.Map<Radio>(editorViewModel);

            if (string.IsNullOrWhiteSpace(radio.Id))
            {
                try
                {
                    var newId = _radioRepository.Add(radio);
                    return RedirectToAction("Detail", new { id = newId });
                }
                catch (Exception ex)
                {
                    // todo: log ex
                    ModelState.AddModelError("", "Unable to add radio. Please contact your system administrator.");
                    return View("editor", editorViewModel);
                }
            }
            else
            {
                try
                {
                    _radioRepository.Save(radio);
                    return RedirectToAction("Detail", new { id = radio.Id });
                }
                catch (Exception ex)
                {
                    // todo: log ex
                    ModelState.AddModelError("", "Unable to update radio. Please contact your system administrator.");
                    return View("editor", editorViewModel);
                }
            }
        }

        #region Private methods
        private void SetupEditorViewModelSelectListItems(EditorViewModel viewModel)
        {
            var genres = _genreRepository.FindAll().ToList();
            viewModel.Genres = genres.AsSelectList<Genre>(genre => genre.Name, genre => genre.Id);

            var streamQualities = _streamQualityRepository.FindAll().ToList();
            viewModel.StreamQualities = streamQualities.AsSelectList<StreamQuality>(streamQuality => streamQuality.Name, streamQuality => streamQuality.Id);

        }
        #endregion
    }
}
