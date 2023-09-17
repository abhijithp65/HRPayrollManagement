using System;
using System.Web.Mvc;
using HRPayrollManagement.Models;
using HRPayrollManagement.Repository;
using System.Collections.Generic;
using System.Linq;

namespace HRPayrollManagement.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly RegistrationRepository registrationRepository;

        public RegistrationController()
        {
            registrationRepository = new RegistrationRepository();
        }

        /// <summary>
        /// GET action to display the registration form
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Register()
        {           
            var registration = new Registration();            
            var stateList = new SelectList(new[]
            {
                new { Value = "State1", Text = "State 1" },
                new { Value = "State2", Text = "State 2" },
               
            }, "Value", "Text");

            ViewBag.StateList = stateList;

            return View(registration);
        }
        /// <summary>
        /// POST action to handle registration form submission
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                try
                {                  
                    string selectedState = registration.State;
                    string selectedCity = registration.City;                   
                    registrationRepository.InsertRegistration(registration);                    
                    ViewBag.RegistrationSuccess = true;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred: " + ex.Message);
                }
            }           
            var stateList = new SelectList(new[]
            {
                new { Value = "State1", Text = "State 1" },
                new { Value = "State2", Text = "State 2" },
               
            }, "Value", "Text");

            ViewBag.StateList = stateList;

            return View(registration);
        }
    }
}
