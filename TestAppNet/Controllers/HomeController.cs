using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAppNet.Models;

namespace TestAppNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetPerson(FindPersonViewModel findPersonViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PFRStorage, FindPFRStorageViewModel>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление

            var query = _db.PfrStorages.Where(storage => (
                (storage.Person.FirstName == findPersonViewModel.FirstName) &&
                (storage.Person.SecondName == findPersonViewModel.SecondName) &&
                (storage.Person.MiddleName == findPersonViewModel.MiddleName) &&
                (storage.Person.SNILS == findPersonViewModel.SNILS)
                ));
            
            if (query.Count() == 0)
                return PartialView("PersonNotFound");

            var storages = mapper.Map<List<FindPFRStorageViewModel>>(query);

            return PartialView("PersonInfo", storages);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
