using hackaton_2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hackaton_2019.ViewModel
{
    public class ConceptosViewModel
    {
        public List<NewsResponse> NewsResponses { get; set; }
        public Cultivo Cultivos { get; set; }
        public Concepto Concepto { get; set; }

    }
    // class NewsResponse
    //{
    //    public string Subject { get; set; }
    //    public string Summary { get; set; }
    //}
    // class Cultivo
    //{
    //    public int Id { get; set; }
    //    public string TipoCultivo { get; set; }
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime FechaInicio { get; set; }
    //    public string Coordenadas { get; set; }
    //}
}