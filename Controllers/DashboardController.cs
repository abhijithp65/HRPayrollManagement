using System;
using System.Web.Mvc;
using HRPayrollManagement.Repository; // Replace with your repository namespace
using HRPayrollManagement.Models; // Replace with your model namespace

namespace HRPayrollManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly RegistrationRepository registrationRepository;

        public DashboardController()
        {
            registrationRepository = new RegistrationRepository();
        }

        // GET: EditUserDetails
        public ActionResult EditUserDetails()
        {
            // Get the currently logged-in user's username
            string loggedInUsername = GetCurrentUserUsername();

            // Retrieve the user's details from the database based on their username
            Registration user = registrationRepository.SelectRegistrationByUsername(loggedInUsername);

            if (user == null)
            {
                return HttpNotFound(); // Handle the case where the user is not found
            }

            // Map the user details to a view model if necessary
            // For now, assuming Registration model matches the view model
            return View(user);
        }

        // POST: EditUserDetails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserDetails(Registration registration)
        {
            if (ModelState.IsValid)
            {
                // Update the user's details in the database
                registrationRepository.UpdateRegistration(registration);

                // Redirect to a success page or return to the dashboard
                return RedirectToAction("UserDashboard", new { username = registration.Username });
            }

            // If the model state is not valid, return the edit form with validation errors
            return View(registration);
        }

        // Other actions...

        private string GetCurrentUserUsername()
        {
            // Implement your logic to get the currently logged-in user's username
            // This could be from your authentication system, session, or cookies
            // For example, if you are using ASP.NET Identity, you can retrieve it like this:
            return User.Identity.Name;
        }
    }

}
