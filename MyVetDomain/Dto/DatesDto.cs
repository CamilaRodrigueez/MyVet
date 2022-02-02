using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVetDomain.Dto
{
    public class DatesDto
    {
     
        public int IdDates { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage ="La fecha es requerida")]
        [Display(Name = "Fecha Cita")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "La Mascota es requerida")]
        public int IdPet { get; set; }

        [Required(ErrorMessage = "El Servicio es requerido")]
        public int IdServives { get; set; }

        [Required(ErrorMessage = "El Estado es requerido")]
        public int IdState { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string Name { get; set; }
        public string Services { get; set; }
        public string Estado { get; set; }
        public string Contact { get; set; }

    }
}
