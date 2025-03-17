using System.ComponentModel.DataAnnotations;

namespace CrudBS.Models
{
    public class LoginViewModel
    {
        [Required]
        public string CorreoElectronico { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}
