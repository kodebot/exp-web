using AutoMapper;
using Microsoft.AspNet.Mvc;
using System.Linq;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.ViewModels.Radio;

namespace WebVaanoli.Controllers
{
    public class RadioController : Controller
    {
        private readonly IRadioRepository _radioRepository;
        private readonly IMappingEngine _mappingEngine;

        public RadioController(IRadioRepository radioRepository, IMappingEngine mappingEngine)
        {
            _radioRepository = radioRepository;
            _mappingEngine = mappingEngine;
        }

        public IActionResult Index()
        {

            var viewModel = new IndexViewModel();
            viewModel.Radios = _radioRepository.FindAll().ToList();
            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            if (id == 0)
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

        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return new BadRequestResult();
            }

            var selectedRadio = _radioRepository.Find(id);
            if (selectedRadio == null)
            {
                return new HttpNotFoundResult();
            }

            var editorViewModel = _mappingEngine.Map<EditorViewModel>(selectedRadio);
            return View("editor", editorViewModel);
        }

        public IActionResult Add()
        {
            return View("Editor", new EditorViewModel());
        }
    }
}
