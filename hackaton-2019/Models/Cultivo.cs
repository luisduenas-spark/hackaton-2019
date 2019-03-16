using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hackaton_2019.Models
{
    public class Cultivo
    {
        public int Id { get; set; }
        public string TipoCultivo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }
        public string Coordenadas { get; set; }
    }
}