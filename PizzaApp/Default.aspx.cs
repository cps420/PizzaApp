using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaApp
{
    public partial class _Default : Page
    {
        Pizza Pizza
        {
            get
            {
                return (Pizza)Session["Pizza"];
            }
            set
            {
                Session["Pizza"] = value;
            }
        }

        PizzaForm PizzaInput {
            get
            {
                return (PizzaForm) Session["PizzaInput"];
            }
            set
            {
                Session["PizzaInput"] = value;
            }
        }

        PizzaOrder Order
        {
            get
            {
                return (PizzaOrder)Session["Order"];
            }
            set
            {
                Session["Order"] = value;
            }
        }

        List<ListItem> PizzaSizes
        {
            get
            {
                List<ListItem> sizes = new List<ListItem>();
                foreach (int size in Enum.GetValues(typeof(PizzaSize)))
                {
                    String name = ((PizzaSize) size).ToString();
                    sizes.Add(new ListItem(name, size.ToString()));
                }
                return sizes;
            }
        }

        List<ListItem> Ingredients
        {
            get
            {
                List<ListItem> ingredients = new List<ListItem>();
                foreach (int ingredient in Enum.GetValues(typeof(PizzaIngredient)))
                {
                    String name = ((PizzaIngredient)ingredient).ToString();
                    ingredients.Add(new ListItem(name, ingredient.ToString()));
                }
                return ingredients;
            }
        }

        List<ListItem> CrustTypes
        {
            get
            {
                List<ListItem> types = new List<ListItem>();
                foreach (int type in Enum.GetValues(typeof(PizzaCrustType)))
                {
                    String name = ((PizzaCrustType)type).ToString();
                    types.Add(new ListItem(name, type.ToString()));
                }
                return types;
            }
        }

        void BindPizzaSize()
        {
            this.ddlPizzaSize.DataTextField = "Text";
            this.ddlPizzaSize.DataValueField = "Value";
            this.ddlPizzaSize.DataSource = PizzaSizes;
            this.ddlPizzaSize.DataBind();
        }

        void BindIngredients()
        {
            this.cblIngredients.DataTextField = "Text";
            this.cblIngredients.DataValueField = "Value";
            this.cblIngredients.DataSource = Ingredients;
            this.cblIngredients.DataBind();
        }

        void BindCrustType()
        {
            this.rblCrustType.DataTextField = "Text";
            this.rblCrustType.DataValueField = "Value";
            this.rblCrustType.DataSource = CrustTypes;
            this.rblCrustType.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindPizzaSize();
                this.BindIngredients();
                this.BindCrustType();
            }
        }

        void ReadSize()
        {
            string size = ddlPizzaSize.SelectedValue;
            this.PizzaInput.Size = (PizzaSize)int.Parse(size);
        }

        void ReadIngredients()
        {
            ListItemCollection ingredients = cblIngredients.Items;
            this.PizzaInput.Ingredients = new List<PizzaIngredient>();
            foreach (ListItem ingredient in ingredients)
            {
                if (ingredient.Selected)
                {
                    PizzaIngredient choice = (PizzaIngredient)int.Parse(ingredient.Value);
                    this.PizzaInput.Ingredients.Add(choice);
                }
            }
        }

        void ReadCrustSize()
        {
            ListItemCollection crustTypes = rblCrustType.Items;
            foreach (ListItem crustType in crustTypes)
            {
                if (crustType.Selected)
                {
                    PizzaCrustType choice = (PizzaCrustType)int.Parse(crustType.Value);
                    this.PizzaInput.Crust = choice;
                }
            }
        }

        void ShowInput()
        {
            string inputStr = $"Size: {this.PizzaInput.Size}" + Environment.NewLine;
            if (this.PizzaInput.Ingredients.Count > 0) {
                inputStr += "Ingredients:" + Environment.NewLine;
                foreach (PizzaIngredient ingredient in this.PizzaInput.Ingredients)
                {
                    inputStr += $"{ingredient.ToString()}" + Environment.NewLine;
                }
            }
            inputStr += $"Crust Size: {this.PizzaInput.Crust}" + Environment.NewLine;

            tbInputDisplay.Text = inputStr;
            divCheckoutInfoContainer.Visible = true;
        }

        void SaveForm()
        {
            this.PizzaInput = new PizzaForm();
            this.ReadSize();
            this.ReadIngredients();
            this.ReadCrustSize();

            ddlPizzaSize.Enabled = false;
            cblIngredients.Enabled = false;
            rblCrustType.Enabled = false;

            ShowInput();
        }

        protected void btnSaveForm_Click(object sender, EventArgs e)
        {
            SaveForm();
        }

        void ClearForm()
        {
            this.BindPizzaSize();
            this.BindIngredients();
            this.BindCrustType();
            this.PizzaInput = new PizzaForm();

            ddlPizzaSize.Enabled = true;
            cblIngredients.Enabled = true;
            rblCrustType.Enabled = true;

            txtTip.Text = "";
            chkDelivery.Checked = false;

            tbInputDisplay.Text = "";
            tbInvoice.Text = "";
            divCheckoutInfoContainer.Visible = false;
            divInvoiceDisplayContainer.Visible = false;
        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        float ReadTip()
        {
            return float.Parse(txtTip.Text);
        }

        void GenerateInvoice()
        {
            float tip = ReadTip();
            this.Order = this.Pizza.GenerateOrder(tip);
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            this.PizzaInput.Delivery = chkDelivery.Checked;
            this.Pizza = this.PizzaInput.Save();
            this.GenerateInvoice();
            tbInvoice.Text = this.Order.InvoiceString();
            divInvoiceDisplayContainer.Visible = true;
        }
    }
}