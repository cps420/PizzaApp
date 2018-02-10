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
        PizzaForm PizzaInput = new PizzaForm();

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

        protected void btnSaveForm_Click(object sender, EventArgs e)
        {
            this.ReadSize();
            this.ReadIngredients();
            this.ReadCrustSize();
            this.lblHeaderTitle.Text += this.PizzaInput.ToString();
        }
    }
}