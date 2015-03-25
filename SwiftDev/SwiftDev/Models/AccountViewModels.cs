using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SwiftDev.Models
{

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
     
        [Required]
        public string UserName { get; set; }
        public int CurrentProject { get; set; }
        [Required]
        public bool UserStillEmployed { get; set; }

        public ApplicationUser GetUser()
        {
            var User = new ApplicationUser()
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,       
                CurrentProject = this.CurrentProject,
                UserStillEmployed = this.UserStillEmployed,
            };
            return User;
        }
    }


    public class EditUserViewModel
    {
        public EditUserViewModel() { }
        
        //Initialise with an instance of ApplicationUser
        public EditUserViewModel(ApplicationUser user)
        {
            this.UserName = this.UserName;
            this.FirstName = this.FirstName;
            this.LastName = this.LastName;
            this.Email = this.Email;
            this.CurrentProject = this.CurrentProject;
            this.UserStillEmployed = this.UserStillEmployed;
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Current Project")]
        public int CurrentProject { get; set; }

        [Required]
        [Display(Name = "UserStillEmployed")]
        public bool UserStillEmployed { get; set; }
    
    }




    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class SelectUserRolesViewModel
    {
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }

        //Init Instance of ApplicationUser
        public SelectUserRolesViewModel(ApplicationUser user):this()
        {
            this.UserName= user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.CurrentProject = user.CurrentProject;
            this.UserStillEmployed = user.UserStillEmployed;

            var DB = new ApplicationDbContext();
            
            // Add All Available Roles to list of EditorViewModels:

            var AllRoles = DB.Roles;
            foreach(var role in AllRoles)
            {
                //EditorViewModel will be used
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }

            // Set SELECTED to TRUE for ALL the roles assigned to USER
            foreach (var userRole in user.Roles)
            {
                var checkUserRole = this.Roles.Find(r => r.RoleName == userRole.RoleId);
                checkUserRole.Selected = true;
            }
        }



        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CurrentProject { get; set; }
        public bool UserStillEmployed { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // Display Single Role with a checkbox within a list
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel(){}
        public SelectRoleEditorViewModel(IdentityRole role)
        {
            this.RoleName = role.Name;
        }

        public bool Selected { get; set; }
        public string RoleName { get; set; }
    }

}
