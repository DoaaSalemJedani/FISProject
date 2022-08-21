using FIS.Data;
using FIS.Models;
using FIS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FIS.Controllers
{
    public class AircraftController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AircraftController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(AircraftCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var aircraft = new Aircraft
            {
                Registration = viewModel.Registration,
                Type = viewModel.Type,
                FConfig = viewModel.FConfig,
                JConfig = viewModel.JConfig,
                YConfig = viewModel.YConfig
            };

            applicationDbContext.Aircrafts.Add(aircraft);
            applicationDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        #endregion

        #region List

        [HttpGet]
        public IActionResult List()
        {
            var aircrafts = applicationDbContext.Aircrafts.ToList();

            var viewModel = new AircraftListViewModel
            {
                Aircrafts = aircrafts.Select(a => new AircraftListViewModel.AircraftItem
                {
                    Id = a.Id,
                    Registration = a.Registration,
                    Type = a.Type,
                    FConfig = a.FConfig,
                    JConfig = a.JConfig,
                    YConfig = a.YConfig
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var aircrafts = applicationDbContext.Aircrafts
                .Where(a => a.Registration.Contains(query) ||
                            a.Type.Contains(query))
                .ToList();

            var viewModel = new AircraftListViewModel
            {
                Aircrafts = aircrafts.Select(a => new AircraftListViewModel.AircraftItem
                {
                    Id = a.Id,
                    Registration = a.Registration,
                    Type = a.Type,
                    FConfig = a.FConfig,
                    JConfig = a.JConfig,
                    YConfig = a.YConfig
                }).ToList()
            };

            return View("List", viewModel);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var aircraft = applicationDbContext.Aircrafts
                .FirstOrDefault(a => a.Id == id);

            var viewModel = new AircraftEditViewModel
            {
                Id = aircraft.Id,
                Registration = aircraft.Registration,
                Type = aircraft.Type,
                FConfig = aircraft.FConfig,
                JConfig = aircraft.JConfig,
                YConfig = aircraft.YConfig
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditPost(AircraftEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var aircraft = new Aircraft
            {
                Id = viewModel.Id,
                Registration = viewModel.Registration,
                Type = viewModel.Type,
                FConfig = viewModel.FConfig,
                JConfig = viewModel.JConfig,
                YConfig = viewModel.YConfig
            };

            applicationDbContext.Aircrafts.Update(aircraft);
            applicationDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var aircraft = applicationDbContext.Aircrafts
                .FirstOrDefault(a => a.Id == id);

            var viewModel = new AircraftDeleteViewModel
            {
                Id = aircraft.Id,
                Registration = aircraft.Registration,
                Type = aircraft.Type,
                FConfig = aircraft.FConfig,
                JConfig = aircraft.JConfig,
                YConfig = aircraft.YConfig
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var aircraft = applicationDbContext.Aircrafts
                .FirstOrDefault(a => a.Id == id);

            applicationDbContext.Aircrafts.Remove(aircraft);
            applicationDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        #endregion
    }
}
