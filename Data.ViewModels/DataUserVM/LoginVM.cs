using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels.DataUserVM
{
    public class LoginVm
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; } = false;
    }
}
