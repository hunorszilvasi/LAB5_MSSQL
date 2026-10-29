using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB5_MSSQL
{
    public partial class SellProductForm : Form
    {
        private readonly int productId;
        private readonly string productName;
        private readonly int availableQuantity;

        public SellProductForm(int id, string name, int quantity)
        {
            InitializeComponent();

            productId = id;
            productName = name;
            availableQuantity = quantity;

            lblProductName.Text = productName;
            lblAvailableQuantity.Text = availableQuantity.ToString();

            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = Math.Max(1, availableQuantity);
            numericUpDown1.Value = 1;
        }

        private void SellProductForm_Load(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int quantityToSell = (int)numericUpDown1.Value;

            button1.Enabled = false;
            button2.Enabled = false;

            try
            {
                await Task.Run(() =>
                {
                    using var db = new ProductDbContext();

                    var product = db.Products.Find(productId);

                    if (product == null)
                    {
                        throw new InvalidOperationException("Product not found.");
                    }

                    if (quantityToSell > product.Quantity)
                    {
                        throw new InvalidOperationException(
                            "Not enough products in stock.");
                    }

                    product.Quantity -= quantityToSell;
                    db.IstoricVanzari.Add(new IstoricVanzari
                    {
                        IdProdus = product.Id,
                        Cantitate = quantityToSell
                    });

                    db.SaveChanges();
                });

                if (!IsDisposed)
                {
                    MessageBox.Show("Sale completed successfully!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    MessageBox.Show(
                        "Error during sale:\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (!IsDisposed)
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
