using System;
using System.Windows.Forms;

namespace LAB5_MSSQL
{
    public partial class IncreaseStockForm : Form
    {
        public IncreaseStockForm()
        {
            InitializeComponent();

            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 100000;
            numericUpDown1.Value = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        // Add Stock gomb
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int productId)
                || productId <= 0)
            {
                MessageBox.Show("Please enter a valid product ID.");
                return;
            }

            int quantityToAdd = (int)numericUpDown1.Value;

            try
            {
                using (var db = new ProductDbContext())
                {
                    var product = db.Products.Find(productId);

                    if (product == null)
                    {
                        MessageBox.Show("Product not found.");
                        return;
                    }

                    product.Quantity += quantityToAdd;

                    db.SaveChanges();
                }

                MessageBox.Show("Stock increased successfully!");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating stock:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Cancel gomb
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
