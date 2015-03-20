//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SwiftDev.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.Users = new HashSet<User>();
        }
    
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string Company { get; set; }
        public string Methodology { get; set; }
        public System.DateTime ProjectStart { get; set; }
        public Nullable<System.DateTime> ProjectEnd { get; set; }
        public bool ProjectTermination { get; set; }
    
        public virtual Methodology Methodology1 { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}