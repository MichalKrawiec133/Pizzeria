using System;

namespace Pizzeria.Api.ViewModels
{
    
    public class ClientViewModel
    {
    
        public int ClientId{get; set;}
        public string ClientFirstName{get; set;}
        public string ClientLastName{get; set;}
        public long ClientPesel{get; set;}
        public string ClientEmail { get; set; }
        public string ClientHash { get; set; }

        public string ClientRole { get; set; }   
    
    }
};

