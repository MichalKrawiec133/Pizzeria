using System;
using System.ComponentModel.DataAnnotations;


namespace Pizzeria.Api.BindingModels
{
    public class CreateClient
    {
        [Required]
        [Display(Name = "ClientId")]
        public int ClientId { get; set; }
        
        [Required]
        [Display(Name = "ClientFirstName")]
        public string ClientFirstName { get; set; }
        
        [Required]
        [Display(Name = "ClientLastName")]
        public string ClientLastName { get; set; }
        
        [Required]
        [Display(Name = "ClientPesel")]
        public long ClientPesel { get; set; }
        
        [Required]
        [Display(Name = "ClientEmail")]
        public string ClientEmail { get; set; }
        
        [Required]
        [Display(Name = "ClientHash")]
        public string ClientHash { get; set; }
        
        [Required]
        [Display(Name = "ClientRole")]
        public string ClientRole { get; set; }
        
    }
}