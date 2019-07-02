using System.ComponentModel.DataAnnotations;

namespace Mimoto.Application.ViewModels.Common
{
    public class AppProfileViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Domain { get; set; }
    }
}