
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB5_MSSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.CellDoubleClick +=
                dataGridView1_CellDoubleClick;

            LoadProducts();
        }

        // TermÃ©kek betÃ¶ltÃ©se hÃ¡ttÃ©rszÃ¡lon
        private async void LoadProducts(string searchText = "")
        {
            try
            {
                var products = await Task.Run(() =>
                {
                    using var db = new ProductDbContext();

                    var query = db.Products
                        .AsNoTracking()
                        .Include(p => p.Categorie)
                        .AsQueryable();

                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        query = query.Where(p =>
                            p.Name.Contains(searchText) ||
                            p.Description.Contains(searchText) ||
                            (p.Categorie != null &&
                             p.Categorie.Denumire.Contains(searchText)));
                    }

                    return query.Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Description,
                        p.EntryDate,
                        p.ExpirationDate,
                        p.Quantity,
                        Category = p.Categorie != null
                            ? p.Categorie.Denumire
                            : "Fara categorie"
                    }).ToList();
                });

                if (IsDisposed || !IsHandleCreated)
                    return;

                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new Action(() =>
                    {
                        dataGridView1.DataSource = products;
                    }));
                }
                else
                {
                    dataGridView1.DataSource = products;
                }
            }
            catch (Exception ex)
            {
                if (!IsDisposed && IsHandleCreated)
                {
                    MessageBox.Show(
                        "Error loading products:\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // Add Product
        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new AddProductForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(textBox1.Text.Trim());
                }
            }
        }

        // Search
        private void button2_Click(object sender, EventArgs e)
        {
            LoadProducts(textBox1.Text.Trim());
        }

        // Clear search
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            LoadProducts();
        }

        // Double-click a product to sell it
        private void dataGridView1_CellDoubleClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataGridView1.Rows[e.RowIndex];

            if (row.Cells["Id"].Value == null ||
                row.Cells["Name"].Value == null ||
                row.Cells["Quantity"].Value == null)
            {
                return;
            }

            int selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            string selectedName = row.Cells["Name"].Value?.ToString()
                ?? string.Empty;
            int selectedQuantity = Convert.ToInt32(
                row.Cells["Quantity"].Value);

            using (var form = new SellProductForm(
                selectedId,
                selectedName,
                selectedQuantity))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(textBox1.Text.Trim());
                }
            }
        }

        private void dataGridView1_CellContentClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        // New Product menu
        private void newProductToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            using (var form = new AddProductForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(textBox1.Text.Trim());
                }
            }
        }

        // Increase Existing Stock menu
        private void increaseExistingStockToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            using (var form = new IncreaseStockForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(textBox1.Text.Trim());
                }
            }
        }

        // Refresh
        private void button4_Click(object sender, EventArgs e)
        {
            LoadProducts(textBox1.Text.Trim());
        }

        // Categories
        private void categoriesToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            using (var form = new CategoryForm())
            {
                form.ShowDialog();
            }
        }


        private void salesHistoryToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            using (var form = new SalesHistoryForm())
            {
                form.ShowDialog();
            }
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new CategoryForm())
            {
                form.ShowDialog();
            }
        }
    }
}






