using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Club_de_Socios.Models
{
    public enum sexo {F,M}
    public enum membresia { Activo, Inactivo }
    public class Socio
    {
        [Key]
        [Required]
        public int SocioID { get; set; }

        [Required]
        [Display(Name = "Nombre Socio")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Socio")]
        public string Apellidos { get; set; }

        public byte[] Foto { get; set; }

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

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Tipo de Membresía")]
        public string Tipo_Membresia { get; set; }

        [Required]
        [Display(Name = "Lugar de trabajo")]
        public string Lugar_de_trabajo { get; set; }

        [Required]
        [Display(Name = "Dirección de la Oficina")]
        public string Direccion_Oficina { get; set; }

        [Required]
        [Display(Name = "Telefono de la Oficina")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono_Oficina { get; set; }

        [Required]
        [Display(Name = "Estado de Membresía")]
        public membresia Estado_de_Membresia { get; set; }

        [Required]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Ingreso { get; set; }

        [Required]
        [Display(Name = "Fecha de Salida")]
        [DataType(DataType.Date)]
        public DateTime Fecha_de_Salida { get; set; }

    }
}