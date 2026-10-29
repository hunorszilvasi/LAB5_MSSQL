using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace LAB5_MSSQL
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string categoryName = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Enter a category name!");
                return;
            }

            button1.Enabled = false;
            button2.Enabled = false;

            try
            {
                await Task.Run(() =>
                {
                    using var db = new ProductDbContext();

                    bool exists = db.CategoriiProduse.Any(
                        c => c.Denumire.ToLower() == categoryName.ToLower());

                    if (exists)
                    {
                        throw new InvalidOperationException(
                            "This category already exists.");
                    }

                    db.CategoriiProduse.Add(new CategorieProdus
                    {
                        Denumire = categoryName
                    });

                    db.SaveChanges();
                });

                if (!IsDisposed)
                {
                    MessageBox.Show("Category added successfully!");
                    textBox1.Clear();
                }
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    MessageBox.Show(
                        "Error adding category:\n" + ex.Message,
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
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
