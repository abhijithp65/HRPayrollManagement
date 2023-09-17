using HRPayrollManagement.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

public class ContactController : Controller
{

    private readonly string _connectionString = "Server=NITRO-5\\SQLEXPRESS;Database=Database_HRPayrollManagement;Integrated Security=True;";
    /// <summary>
    /// GET action to display the contact form
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult SubmitContactForm()
    {
        return View();
    }

    /// <summary>
    ///  POST action to handle form submission
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult SubmitContactForm(ContactForm model)
    {
        if (ModelState.IsValid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("insertContactForm", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.Parameters.AddWithValue("@email", model.Email);
                    cmd.Parameters.AddWithValue("@message", model.Message);
                    cmd.ExecuteNonQuery();
                }
            }

            TempData["SuccessMessage"] = "Message sent successfully.";

            return RedirectToAction("Contact","Home");
        }

        return View(model);
    }
    }
