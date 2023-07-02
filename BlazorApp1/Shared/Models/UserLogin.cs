using BlazorApp1.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared.Models
{
    public class UserLogin
    {
        [Display(Name ="Usuario"),Required(ErrorMessage = Utilities.MSGREQUIRED)]
        public string UserName { get; set; }

        [Display(Name = "Password"), Required(ErrorMessage = Utilities.MSGREQUIRED)]
        public string Password { get; set; }
    }
}
