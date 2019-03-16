using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hackaton_2019.Models
{
    public class ConceptoDetalle
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }
        public double Inversion { get; set; }
    }
}