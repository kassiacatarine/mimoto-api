using System.ComponentModel.DataAnnotations;

namespace Mimoto.Application.ViewModels.Common
{
    public class CompanyProfileViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cnpj { get; set; }
    }
}