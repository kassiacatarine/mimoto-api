using System.ComponentModel.DataAnnotations;

namespace Mimoto.Application.ViewModels.Common
{
    public class UserProfileViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
    }
}