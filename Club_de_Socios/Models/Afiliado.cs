using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Club_de_Socios.Models
{
    public class Afiliado
    {

        [Key]
        [Required]
        public int AfiliadoID { get; set; }

        [Required]
        [Display(Name = "Nombre Afiliado")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Afiliado")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required]
        public sexo Sexo { get; set; }

        [Required]
        public int Edad { get; set; }

        public int SocioID { get; set; }
        public virtual Socio Socio { get; set; }

    }
}