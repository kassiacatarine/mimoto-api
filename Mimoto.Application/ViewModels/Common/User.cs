using System.ComponentModel.DataAnnotations;

namespace Mimoto.Application.ViewModels.Common
{
    public class UserProfileViewModel
    {
        [Required]
        public string Name { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Location { get; set; }
    }

    public class UserLoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UserSingupViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}