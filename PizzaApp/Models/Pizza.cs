using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public enum PizzaSize
    {
        Small, Medium, Large, ExtraLarge
    }

    public enum PizzaIngredient
    {
        Sausage, GreenPepper, Spinach, Pineapple
    }

    public enum PizzaCrustType
    {
        DeepDish, ThinCrust, PanPizza
    }

    public class Pizza
    {
        public PizzaSize Size;
        public List<PizzaIngredient> Ingredients;
        public PizzaCrustType Crust;

        public Pizza(PizzaSize size, List<PizzaIngredient> ingredients, PizzaCrustType crust)
        {
            Size = size;
            Ingredients = ingredients;
            Crust = crust;
        }
    }

    public class PizzaForm
    {
        public PizzaSize Size;
        public List<PizzaIngredient> Ingredients;
        public PizzaCrustType Crust;

        public override string ToString()
        {
            return $"{this.Size.ToString()}, {this.Ingredients.ToString()}, {this.Crust.ToString()}";
        }
    }
}