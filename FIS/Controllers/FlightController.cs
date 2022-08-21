using FIS.Data;
using FIS.Models;
using FIS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FIS.Controllers
{
    public class FlightController : Controller
    {
        // create reference to the database
        private readonly ApplicationDbContext applicationDbContext;

        // constructor to initilize the database
        public FlightController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            // read aircraft list from db
            var aircrafts = applicationDbContext.Aircrafts.ToList();

            // create view model and fill aircraft list in the select list items
            var viewModel = new FlightCreateViewModel
            {
                AircraftList = aircrafts.Select(a => new SelectListItem()
                {
                    Text = a.Registration,
                    Value = a.Id.ToString()
                }).ToList()
            };

            // pass the view model to the view
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePost(FlightCreateViewModel viewModel)
        {
            // server validation (optional)
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // get the user selected aircraft from db
            var aircraft = applicationDbContext.Aircrafts
                .FirstOrDefault(a => a.Id == int.Parse(viewModel.Aircraft));

            // convert viewmodel to model
            var flight = new Flight
            {
                FlightNumber = viewModel.FlightNumber,
                FlightDate = viewModel.FlightDate,
                DepartureStation = viewModel.DepartureStation,
                ArrivalStation = viewModel.ArrivalStation,
                FPassengers = viewModel.FPassengers,
                JPassengers = viewModel.JPassengers,
                YPassengers = viewModel.YPassengers,
                Aircraft = aircraft
            };

            // save model to the database
            applicationDbContext.Flights.Add(flight);
            applicationDbContext.SaveChanges();

            // redirect to any view
            return RedirectToAction("List");
        }

        #endregion

        #region List

        [HttpGet]
        public IActionResult List()
        {
            // get flights from databae
            var flights = applicationDbContext.Flights.ToList();

            // convert model to view model
            var viewModel = new FlightListViewModel
            {
                Flights = flights.Select(f => new FlightListViewModel.FlightItem
                {
                    Id = f.Id,
                    FlightNumber = f.FlightNumber,
                    FlightDate = f.FlightDate.ToShortDateString(),
                    DepartureStation = f.DepartureStation,
                    ArrivalStation = f.ArrivalStation
                }).ToList()
            };

            // pass the view model to the view
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            // get flights using the search query from database
            var flights = applicationDbContext.Flights
                .Where(f => f.FlightNumber.Contains(query) ||
                            f.DepartureStation.Contains(query) ||
                            f.ArrivalStation.Contains(query))
                .ToList();

            // convert model to view model
            var viewModel = new FlightListViewModel
            {
                Flights = flights.Select(f => new FlightListViewModel.FlightItem
                {
                    Id = f.Id,
                    FlightNumber = f.FlightNumber,
                    FlightDate = f.FlightDate.ToShortDateString(),
                    DepartureStation = f.DepartureStation,
                    ArrivalStation = f.ArrivalStation
                }).ToList()
            };

            // pass the view model to the List view
            return View("List", viewModel);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // get aircrafts list from db to fill the select drop down list
            var aircrafts = applicationDbContext.Aircrafts.ToList();

            // get the selected flight from db
            var flight = applicationDbContext.Flights
                .Include(f => f.Aircraft)
                .FirstOrDefault(f => f.Id == id);

            // convert the models to view model
            var viewModel = new FlightEditViewModel
            {
                FlightNumber = flight.FlightNumber,
                FlightDate = flight.FlightDate,
                DepartureStation = flight.DepartureStation,
                ArrivalStation = flight.ArrivalStation,
                FPassengers = flight.FPassengers,
                JPassengers = flight.JPassengers,
                YPassengers = flight.YPassengers,
                Aircraft = flight.Aircraft != null ? flight.Aircraft.Id.ToString() : "",
                AircraftList = aircrafts.Select(a => new SelectListItem()
                {
                    Text = a.Registration,
                    Value = a.Id.ToString()
                }).ToList()
            };

            // pass the view model the view
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditPost(FlightEditViewModel viewModel)
        {
            // server validation
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // get the user selected aircraft from db
            var aircraft = applicationDbContext.Aircrafts
                .FirstOrDefault(a => a.Id == int.Parse(viewModel.Aircraft));

            // create the new flight model
            // and add the selected aircraft to it
            var flight = new Flight
            {
                Id = viewModel.Id,
                FlightNumber = viewModel.FlightNumber,
                FlightDate = viewModel.FlightDate,
                DepartureStation = viewModel.DepartureStation,
                ArrivalStation = viewModel.ArrivalStation,
                FPassengers = viewModel.FPassengers,
                JPassengers = viewModel.JPassengers,
                YPassengers = viewModel.YPassengers,
                Aircraft = aircraft
            };

            // update the flight info in db
            applicationDbContext.Flights.Update(flight);
            applicationDbContext.SaveChanges();

            // redirect to the List action
            return RedirectToAction("List");
        }

        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // get the selected flight from db
            var flight = applicationDbContext.Flights
                .Include(f => f.Aircraft)
                .FirstOrDefault(f => f.Id == id);

            // convert the model to view model
            var viewModel = new FlightDeleteViewModel
            {
                FlightNumber = flight.FlightNumber,
                FlightDate = flight.FlightDate,
                DepartureStation = flight.DepartureStation,
                ArrivalStation = flight.ArrivalStation,
                FPassengers = flight.FPassengers,
                JPassengers = flight.JPassengers,
                YPassengers = flight.YPassengers,
                Aircraft = flight.Aircraft != null ? flight.Aircraft.Registration : ""
            };

            // pass the view model to the view
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            // get the selected flight from db
            var flight = applicationDbContext.Flights
                .FirstOrDefault(f => f.Id == id);

            // delete the selected flight from db
            applicationDbContext.Flights.Remove(flight);
            applicationDbContext.SaveChanges();

            // redirect to the List action
            return RedirectToAction("List");
        }

        #endregion

    }
}
