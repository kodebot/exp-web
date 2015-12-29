using Microsoft.AspNet.Mvc;
using System.Linq;
using WebVaanoli.ViewModels.Genre;
using AutoMapper;
using System;
using WebVaanoli.Domain;
using WebVaanoli.Data.Interfaces;

namespace WebVaanoli.Controllers
{
    /// <summary>
    /// The Genre CRUD controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Mvc.Controller" />
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMappingEngine _mappingEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenreController"/> class.
        /// </summary>
        /// <param name="genreRepository">The genre repository.</param>
        /// <param name="mappingEngine">The mapping engine.</param>
        public GenreController(IGenreRepository genreRepository, IMappingEngine mappingEngine)
        {
            _genreRepository = genreRepository;
            _mappingEngine = mappingEngine;
        }

        /// <summary>
        /// Genre Index.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Genres = _genreRepository.FindAll().ToList();
            return View(viewModel);
        }

        /// <summary>
        /// Genre Detail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Genre Detail view with selected genre detail.</returns>
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return HttpBadRequest();
            }

            var selectedGenre = _genreRepository.Find(id);
            if (selectedGenre == null)
            {
                return HttpNotFound();
            }

            var viewModel = _mappingEngine.Map<DetailViewModel>(selectedGenre);
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpBadRequest();
            }

            var selectedGenre = _genreRepository.Find(id);
            if (selectedGenre == null)
            {
                return HttpNotFound();
            }

            var viewModel = _mappingEngine.Map<EditorViewModel>(selectedGenre);
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

            var genre = _mappingEngine.Map<Genre>(editorViewModel);

            if (genre.Id == 0)
            {
                try
                {
                    var newId = _genreRepository.Add(genre);
                    return RedirectToAction("Detail", new { id = newId });
                }
                catch (Exception ex)
                {
                    // todo: log ex
                    ModelState.AddModelError("", "Unable to add genre. Please contact your system administrator.");
                    return View("editor", editorViewModel);
                }
            }
            else
            {
                try
                {
                    _genreRepository.Save(genre);
                    return RedirectToAction("Detail", new { id = genre.Id });
                }
                catch (Exception ex)
                {
                    // todo: log ex
                    ModelState.AddModelError("", "Unable to update genre. Please contact your system administrator.");
                    return View("editor", editorViewModel);
                }
            }
        }
    }
}
