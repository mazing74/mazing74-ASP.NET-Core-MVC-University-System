using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
    public class RegiVM
    {
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
