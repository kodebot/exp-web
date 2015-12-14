using AutoMapper;
using GenFu;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVaanoli.Data;
using WebVaanoli.Domain;
using WebVaanoli.ViewModels.Radio;

namespace WebVaanoli.Controllers
{
    public class RadioController : Controller
    {
        private readonly IRadioRepository _radioRepository;

        public RadioController(IRadioRepository radioRepository)
        {
            _radioRepository = radioRepository;
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

            var detailViewModel = Mapper.Map<DetailViewModel>(selectedRadio);

            return View(detailViewModel);
        }
    }
}
