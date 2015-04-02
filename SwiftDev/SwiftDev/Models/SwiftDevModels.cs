using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftDev.Models
{
    // Will contain the Instance of PROJECT, METHODOLOGY

    [Table("Methodology")]
    public class Methodology
    {
        [Key]
        public string MethodologyID { get; set; }
        public string MethodologyName { get; set; }
    }

    [Table("Projects")]
    public class Project
    {

        [Required]
        [Key]
        public string ProjectID { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectDescription { get; set; }
        [Required]
        public string Company { get; set;}
        [Required]
        public string Methodology { get; set; }
        [Required]
        public string ProjectLeader { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DateStarted { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DateFinished { get; set; }


    }

}   