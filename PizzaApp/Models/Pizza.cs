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
        static float BasePrice = 5.0f;
        static float SizePriceModifier = 0.50f;
        static float IngredientPriceRate = 1.0f;

        public PizzaSize Size;
        public List<PizzaIngredient> Ingredients;
        public PizzaCrustType Crust;
        public bool Delivery;

        float SizePrice
        {
            get
            {
                int size = ((int)Size);
                float sizeFl = ((float)(size + 1));
                float sizePrice = sizeFl * SizePriceModifier;
                return sizePrice;
            }
        }

        float IngredientsPrice
        {
            get
            {
                int count = Ingredients.Count;
                float countFl = (float)count;
                float ingredientsPrice = countFl * IngredientPriceRate;
                return ingredientsPrice;
            }
        }

        public float Cost
        {
            get
            {
                float basePrice = BasePrice;
                float sizePrice = SizePrice;
                float ingrPrice = IngredientsPrice;
                float total = basePrice + sizePrice + ingrPrice;
                return total;
            }
        }

        public Pizza(PizzaSize size, List<PizzaIngredient> ingredients, PizzaCrustType crust, bool delivery)
        {
            Size = size;
            Ingredients = ingredients;
            Crust = crust;
            Delivery = delivery;
        }

        public PizzaOrder GenerateOrder(float tip)
        {
            PizzaOrder order = new PizzaOrder(this, tip);
            return order;
        }
    }

    public class PizzaForm
    {
        public PizzaSize Size;
        public List<PizzaIngredient> Ingredients;
        public PizzaCrustType Crust;
        public bool Delivery = false;

        public Pizza Save()
        {
            return new Pizza(Size, Ingredients, Crust, Delivery);
        }

        public override string ToString()
        {
            return $"{this.Size.ToString()}, {this.Ingredients.ToString()}, {this.Crust.ToString()}";
        }
    }
}