using Microsoft.AspNet.Mvc;
using System.Linq;
using WebVaanoli.Data;
using WebVaanoli.ViewModels.Genre;

namespace WebVaanoli.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Genres = _genreRepository.FindAll().ToList();
            return View(viewModel);
        }
    }
}
