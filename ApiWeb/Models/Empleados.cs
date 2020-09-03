using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiWeb.Models
{
    public class Empleados
    {
        public long IdEmpleado { get; set; }

        [Required(ErrorMessage = "Campo Requerido*")]
        public string NombreEmpleado { get; set; }

        [Required(ErrorMessage = "Campo Requerido*")]
        public string ApellidoEmpleado { get;set; }


        [Required(ErrorMessage = "Campo Requerido*")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "Campo Requerido*")]
        public string MailID { get; set; }
    }
}