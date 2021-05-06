using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace crud_musica.Models
{
    public class Musica
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es Obligatorio")]
        [StringLength(50,ErrorMessage ="{0} debe ser de entre {1} y {2} caracteres",MinimumLength =3)]
        public string   Nombre{ get; set; }

        public string   Album{ get; set; }

        [StringLength(50, ErrorMessage = "{0} debe ser de entre {1} y {2} caracteres", MinimumLength = 3)]
        public string   Artista{ get; set; }

        [Display(Name ="Año")]
        [Required(ErrorMessage ="El campo Año es obligatorio")]
        public int Year{ get; set; }

        [Display(Name = "Genero")]
        public string Genero{ get; set; }
    }
}
