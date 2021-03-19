using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblDateText.Text = DateTime.Now.ToString(" dddd, MMMM d, yyyy");
            btnSummary.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int numOfGuests = 0;
            if(!int.TryParse(txtNumOfGuests.Text, out numOfGuests))
            {
                MessageBox.Show("You must enter a valid guest amount!");
                return;
            }
            numOfGuests = int.Parse(txtNumOfGuests.Text);
            double menuPrice = 0;
            double saucePrice = 0;
            double sidePrice = 0;
            double drinkPrice = 0;
            double total = 0;
            if(rdoSteak.Checked == true)
            {
                menuPrice = 30.95;
            }
            if (rdoChicken.Checked == true)
            {
                menuPrice = 19.95;
            }
            if (rdoPasta.Checked == true)
            {
                menuPrice = 14.95;
            }
            if(cmbSauces.SelectedItem == "Aioli")
            {
                saucePrice = 2.50;
            }
            if (cmbSauces.SelectedItem == "Drawn Butter")
            {
                saucePrice = 1.00;
            }
            if (cmbSauces.SelectedItem == "Garlic Sauce")
            {
                saucePrice = 1.50;
            }
            if (cmbSauces.SelectedItem == "Hollandaise")
            {
                saucePrice = 3.00;
            }
            if (cmbSauces.SelectedItem == "Remoulade")
            {
                saucePrice = 2.50;
            }
            if(cmbSides.SelectedItem == "Brussels Sprouts")
            {
                sidePrice = 3.00;
            }
            if (cmbSides.SelectedItem == "Butternut Squash")
            {
                sidePrice = 4.00;
            }
            if (cmbSides.SelectedItem == "Macaroni Salad")
            {
                sidePrice = 2.50;
            }
            if (cmbSides.SelectedItem == "Roasted Broccoli")
            {
                sidePrice = 2.00;
            }
            if(chbOpenBar.Checked == true && chbWineWDinner.Checked == true)
            {
                drinkPrice = 33.00;
            }
            else if(chbWineWDinner.Checked == true && chbOpenBar.Checked == false)
            {
                drinkPrice = 8.00;
            }
            else if (chbWineWDinner.Checked == false && chbOpenBar.Checked == true)
            {
                drinkPrice = 25.00;
            }
            else
            {
                drinkPrice = 0;
            }

            total = (numOfGuests * menuPrice) + (numOfGuests * saucePrice) + (numOfGuests * sidePrice) + (numOfGuests * drinkPrice);
            txtAmountDue.Text = total.ToString("C");
            btnSummary.Enabled = true;
        }

      

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAmountDue.Clear();
            txtNumOfGuests.Clear();
            rdoChicken.Checked = false;
            rdoPasta.Checked = false;
            rdoSteak.Checked = false;
            cmbSauces.SelectedIndex = -1;
            cmbSides.SelectedIndex = -1;
            chbOpenBar.Checked = false;
            chbWineWDinner.Checked = false;
            btnSummary.Enabled = false;
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            int numOfGuests = int.Parse(txtNumOfGuests.Text);
            double menuPrice = 0;
            double saucePrice = 0;
            double sidePrice = 0;
            double drinkPrice = 0;
            string menuItem = "";
            string sauceItem = "";
            string sideItem = "";
            string drinkItems = "";
            double total = 0;
            if (rdoSteak.Checked == true)
            {
                menuPrice = 30.95*numOfGuests;
                menuItem = "Steak";
            }
            if (rdoChicken.Checked == true)
            {
                menuPrice = 19.95*numOfGuests;
                menuItem = "Chicken";
            }
            if (rdoPasta.Checked == true)
            {
                menuPrice = 14.95*numOfGuests;
                menuItem = "Pasta";
            }
            if (cmbSauces.SelectedItem == "Aioli")
            {
                saucePrice = 2.50*numOfGuests;
                sauceItem = "Aioli";
            }
            if (cmbSauces.SelectedItem == "Drawn Butter")
            {
                saucePrice = 1.00*numOfGuests;
                sauceItem = "Drawn Butter";
            }
            if (cmbSauces.SelectedItem == "Garlic Sauce")
            {
                saucePrice = 1.50*numOfGuests;
                sauceItem = "Garlic Sauce";
            }
            if (cmbSauces.SelectedItem == "Hollandaise")
            {
                saucePrice = 3.00*numOfGuests;
                sauceItem = "Hollandaise";
            }
            if (cmbSauces.SelectedItem == "Remoulade")
            {
                saucePrice = 2.50*numOfGuests;
                sauceItem = "Remoulade";
            }
            if (cmbSides.SelectedItem == "Brussels Sprouts")
            {
                sidePrice = 3.00*numOfGuests;
                sideItem = "Brussels Sprouts";
            }
            if (cmbSides.SelectedItem == "Butternut Squash")
            {
                sidePrice = 4.00*numOfGuests;
                sideItem = "Butternut Squash";
            }
            if (cmbSides.SelectedItem == "Macaroni Salad")
            {
                sidePrice = 2.50*numOfGuests;
                sideItem = "Macaroni Salad";
            }
            if (cmbSides.SelectedItem == "Roasted Broccoli")
            {
                sidePrice = 2.00*numOfGuests;
                sideItem = "Roasted Broccoli";
            }
            if (chbOpenBar.Checked == true && chbWineWDinner.Checked == true)
            {
                drinkPrice = 33.00*numOfGuests;
                drinkItems = "Wine with Dinner and Open Bar";
            }
            else if (chbWineWDinner.Checked == true && chbOpenBar.Checked == false)
            {
                drinkPrice = 8.00*numOfGuests;
                drinkItems = "Wine with Dinner";
            }
            else if (chbWineWDinner.Checked == false && chbOpenBar.Checked == true)
            {
                drinkPrice = 25.00*numOfGuests;
                drinkItems = "Open Bar";
            }
            else
            {
                drinkPrice = 0;
                drinkItems = "nothing";
            }

            total = menuPrice + saucePrice + sidePrice + drinkPrice;
            string message = "Your meal is " + menuItem + ", and costs: " + menuPrice.ToString("C") + "\nYour sauce is " + sauceItem + ", and costs: " + saucePrice.ToString("C") + "\nYour side is " + sideItem + ", and costs: " + sidePrice.ToString("C") + "\nYour drink option is " + drinkItems + ", and costs: " + drinkPrice.ToString("C") + "\nThe total is: " + total.ToString("C") + "\nThe amount of guests is: " + numOfGuests  + "\n" + "\nWould you like to clear everything?";
            string title = "Summary";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, button);
            if(result == DialogResult.Yes)
            {
                txtAmountDue.Clear();
                txtNumOfGuests.Clear();
                rdoChicken.Checked = false;
                rdoPasta.Checked = false;
                rdoSteak.Checked = false;
                cmbSauces.SelectedIndex = -1;
                cmbSides.SelectedIndex = -1;
                chbOpenBar.Checked = false;
                chbWineWDinner.Checked = false;
                btnSummary.Enabled = false;
                return;
            }
            else
            {
                return;
            }
        }
    }
}

