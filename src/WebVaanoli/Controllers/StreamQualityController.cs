using Microsoft.AspNet.Mvc;
using System.Linq;
using WebVaanoli.ViewModels.StreamQuality;
using AutoMapper;
using System;
using WebVaanoli.Domain;
using WebVaanoli.Data.Interfaces;

namespace WebVaanoli.Controllers
{
    /// <summary>
    /// The Stream Quality CRUD controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Mvc.Controller" />
    public class StreamQualityController : Controller
    {
        private readonly IStreamQualityRepository _streamQualityRepository;
        private readonly IMappingEngine _mappingEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamQualityController"/> class.
        /// </summary>
        /// <param name="streamQualityRepository">The streamQuality repository.</param>
        /// <param name="mappingEngine">The mapping engine.</param>
        public StreamQualityController(IStreamQualityRepository streamQualityRepository, IMappingEngine mappingEngine)
        {
            _streamQualityRepository = streamQualityRepository;
            _mappingEngine = mappingEngine;
        }

        /// <summary>
        /// StreamQuality Index.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.StreamQualities = _streamQualityRepository.FindAll().ToList();
            return View(viewModel);
        }

        /// <summary>
        /// StreamQuality Detail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The StreamQuality Detail view with selected streamQuality detail.</returns>
        public IActionResult Detail(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return HttpBadRequest();
            }

            var selectedStreamQuality = _streamQualityRepository.Find(id);
            if (selectedStreamQuality == null)
            {
                return HttpNotFound();
            }

            var viewModel = _mappingEngine.Map<DetailViewModel>(selectedStreamQuality);
            return View(viewModel);
        }

        public IActionResult Edit(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return HttpBadRequest();
            }

            var selectedStreamQuality = _streamQualityRepository.Find(id);
            if (selectedStreamQuality == null)
            {
                return HttpNotFound();
            }

            var viewModel = _mappingEngine.Map<EditorViewModel>(selectedStreamQuality);
            return View("editor", viewModel);
        }

        public IActionResult Add()
        {
            return View("editor", new EditorViewModel());
        }

        public IActionResult Save(EditorViewModel editorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("editor", editorViewModel);
            }

            var streamQuality = _mappingEngine.Map<StreamQuality>(editorViewModel);

            if (string.IsNullOrWhiteSpace(streamQuality.Id))
            {
                try
                {
                    var newId = _streamQualityRepository.Add(streamQuality);
                    return RedirectToAction("Detail", new { id = newId });
                }
                catch (Exception ex)
                {
                    // todo: log ex
                    ModelState.AddModelError("", "Unable to add streamQuality. Please contact your system administrator.");
                    return View("editor", editorViewModel);
                }
            }
            else
            {
                try
                {
                    _streamQualityRepository.Save(streamQuality);
                    return RedirectToAction("Detail", new { id = streamQuality.Id });
                }
                catch (Exception ex)
                {
                    // todo: log ex
                    ModelState.AddModelError("", "Unable to update streamQuality. Please contact your system administrator.");
                    return View("editor", editorViewModel);
                }
            }
        }
    }
}
