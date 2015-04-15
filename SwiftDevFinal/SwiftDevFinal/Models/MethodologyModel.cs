using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;




namespace IdentitySample.Models
{

    public class MethodologyModel
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "MethodologyName")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> MethodologyList { get; set; }
 

    }
}