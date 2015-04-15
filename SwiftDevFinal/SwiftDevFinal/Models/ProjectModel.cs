using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;



namespace IdentitySample.Models
{

    public class ProjectModel
    {
        [Key]
        public int ProjectID { get; set; }

        [Display(Name = "Project Name")]
        [MaxLength(255)]
        public string ProjectName { get; set; }

        [Display(Name = "Project Description")]
        [MaxLength(255)]
        public string ProjectDescription { get; set; }

        [Display(Name = "Company")]
        [MaxLength(30)]
        public string Company { get; set; }

        [Display(Name = "Methodology")]
        [MaxLength(10)]
        public string Methodology { get; set; }

        [Display(Name = "ProjectLeader")]
        [MaxLength(256)]
        public string ProjectLeader { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateStarted { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateFinished { get; set; }


        public IEnumerable<SelectListItem> ProjectsList { get; set; }
    }

}