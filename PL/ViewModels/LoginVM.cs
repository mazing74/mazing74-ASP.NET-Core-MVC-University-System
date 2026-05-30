using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
    public class LoginVM
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; } // to keep the user logged in for a longer period of time (e.g., 7 days) instead of the default session duration Using Cookie
    }
}
