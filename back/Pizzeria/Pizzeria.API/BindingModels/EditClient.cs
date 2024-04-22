using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;


namespace Pizzeria.Api.BindingModels
{
    public class EditClient
    { 
//        [Required]
        [Display(Name = "ClientFirstName")]
        public string ClientFirstName { get; set; }

//        [Required]
//        [EmailAddress]
        [Display(Name = "ClientLastName")]
        public string ClientLastName { get; set; }
        
//        [Required]
        [Display(Name = "ClientPesel")]
        public long ClientPesel { get; set; }
        
        [Display(Name = "ClientEmail")]
        public string ClientEmail { get; set; }
        
        [Display(Name = "ClientHash")]
        public string ClientHash { get; set; }
        
        [Display(Name = "ClientRole")]
        public string ClientRole { get; set; }
        
       

    }
    
    public class EditClientValidator : AbstractValidator<EditClient> {
            public EditClientValidator() {
                    RuleFor(x => x.ClientFirstName).NotNull();
                    RuleFor(x => x.ClientLastName).NotNull();
                    RuleFor(x => x.ClientPesel).NotNull();
                    RuleFor(x => x.ClientEmail).NotNull();
                    RuleFor(x => x.ClientHash).NotNull();
                    RuleFor(x => x.ClientRole).NotNull();

            }
    }

}