using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace CashRegister
{


    public partial class appetizerLabel : Form
    {
        string myGlobal = "2.00";
        
        double fries = 0;
        double pasta = 0;
        double drinks = 0;
        double total = 0;
        double subtotal = 0;
        double tax = 0;
        double tender = 0;
        double change = 0;

        public appetizerLabel()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.chaChing);
            player.Play();

            try
            {
                fries = Convert.ToDouble(friesInput.Text);
                pasta = Convert.ToDouble(pastaInput.Text);
                drinks = Convert.ToDouble(drinksInput.Text);

                subtotal = (fries + pasta + drinks) * 2.00;
                tax = subtotal * 0.13;
                total = subtotal + tax;

                subTotalOutput.Text = $"{subtotal.ToString("C")}";
                taxOutput.Text = $"{tax.ToString("C")}";
                totalOutput.Text = $"{total.ToString("C")}";

            }
            catch
            {
                subTotalOutput.Text = "ERROR";
                taxOutput.Text = "ERROR";
                totalOutput.Text = "ERROR";
            }
        }
        private void calculateChangeButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.chaChing);
            player.Play();

            tender = Convert.ToDouble(tenderInput.Text);
            
            change = tender - total;

            changeOutput.Text = $"{change.ToString("C")}";

        }

        private void printButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.print);
            player.Play();

            //receipt is printing
            receiptOutputLabel.Text += $"\n        The Authentic Cuisine";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n Fries         x{fries}            $ {myGlobal}";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n Pasta         x{pasta}            $ {myGlobal}";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            player.Play();

            receiptOutputLabel.Text += $"\n";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n Drinks        x{drinks}            $ {myGlobal}";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n Subtotal                    {subtotal.ToString("C")}";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n Tax                         {tax.ToString("C")}";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            player.Play();

            receiptOutputLabel.Text += $"\n Total                       {total.ToString("C")}";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n Tendered                    {tender.ToString("C")}";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            receiptOutputLabel.Text += $"\n Change                      {change.ToString("C")}";
            receiptOutputLabel.Refresh();
            Thread.Sleep(300);

            player.Play();

            receiptOutputLabel.Text += $"\n         Have a Nice Day :)";

            receiptOutputLabel.Text += $"\n";

            receiptOutputLabel.Refresh();
            Thread.Sleep(300);
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            friesInput.Text = "";
            pastaInput.Text = "";
            drinksInput.Text = "";
            totalOutput.Text = "";
            subTotalOutput.Text = "";
            taxOutput.Text = "";
            tenderInput.Text = "";
            changeOutput.Text = "";
            receiptOutputLabel.Text = String.Empty;
        }
    }
}
