using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class PizzaOrder
    {
        static float TaxRate = 0.06f;
        static float DeliveryChargeRate = 0.5f;

        Pizza Pizza;

        public float PizzaCost = 0.0f;

        public float Tip = 0.0f;

        public float DeliveryCharge = 0.0f;

        public float Tax
        {
            get
            {
                return (PizzaCost + Tip + DeliveryCharge) * TaxRate;
            }
        }

        public float Total
        {
            get
            {
                return PizzaCost + Tip + DeliveryCharge + Tax;
            }
        }

        public PizzaOrder(Pizza pizza, float tip)
        {
            this.Pizza = pizza;
            this.PizzaCost = this.Pizza.Cost;
            this.Tip = tip;
            if (pizza.Delivery)
            {
                this.DeliveryCharge = DeliveryChargeRate;
            }
        }

        public string InvoiceString()
        {
            string invoiceStr = $"Pizza Cost: ${PizzaCost}" + Environment.NewLine +
                   $"Tip: ${Tip}" + Environment.NewLine;
            if (this.Pizza.Delivery)
            {
                invoiceStr += $"Delivery: ${DeliveryCharge}" + Environment.NewLine;
            }
            invoiceStr += $"Tax: ${Tax}" + Environment.NewLine +
                          $"Total: ${Total}";

            return invoiceStr;
        }
    }
}