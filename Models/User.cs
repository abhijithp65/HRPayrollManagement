using System;
using System.ComponentModel.DataAnnotations;
using HRPayrollManagement.Models;

namespace HRPayrollManagement.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
       
        public string Password { get; set; }

        public string Role { get; set; }
    }

}
