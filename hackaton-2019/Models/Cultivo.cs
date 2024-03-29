﻿using System;
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }
        public string Coordenadas { get; set; }
        public string Nombre { get; set; }
        [Display(Name ="Superficie (m2)")]
        public int Superficie { get; set; }
        public double KilosCosechados { get; set; }
        public double PrecioKilo { get; set; }
    }
}