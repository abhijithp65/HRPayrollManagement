using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using HRPayrollManagement.Models;


namespace HRPayrollManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["GetDatabaseConnection"].ConnectionString;
        /// <summary>
        /// Action for displaying the Sign In view
        /// </summary>
        /// <returns></returns>
        public ActionResult SignIn()
        {
            return View();
        }

        /// <summary>
        /// POST action for handling user sign-in
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            if (ModelState.IsValid)
            {
                if (IsValidUser(user.Username, user.Password))
                {
                    string role = GetUserRole(user.Username);

                    if (role == "Admin")
                    {
                        return RedirectToAction("AdminDashboard", "Account" , new { username = user.Username });
                    }
                    else if (role == "User")
                    {
                        return RedirectToAction("UserDashboard", "Account", new { username = user.Username });
                    }
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(user);
        }
        /// <summary>
        /// Action for displaying the UserDashboard view with the username parameter
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public ActionResult UserDashboard(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
               
                return View((object)username);
            }

            return HttpNotFound();
        }
        /// <summary>
        /// Action for displaying the AdminDashboard view
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminDashboard()
        {
            return View();
        }


        /// <summary>
        /// Helper method to check if a user is valid based on username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool IsValidUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SPA_User", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string status = reader["Status"].ToString();
                        if (status == "Authenticated")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        /// <summary>
        /// Helper method to get the user's role based on username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private string GetUserRole(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SPG_UserRole", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["role"].ToString();
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Action for logging out (redirects to the SignIn action)
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            return RedirectToAction("SignIn");
        }

    }

}
