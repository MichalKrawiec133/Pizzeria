using System;

namespace Pizzeria.Api.ViewModels;

public class ProductViewModel
{
    
    public int ProductId{get; set;}
    public string ProductName{get; set;}
    
    public string ProductIngredients{get; set;}
    
    public int ProductPrice{get; set;}
    
}