
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace LAB5_MSSQL
{
    public partial class SalesHistoryForm : Form
    {
        public SalesHistoryForm()
        {
            InitializeComponent();
            LoadSalesHistory();
        }

        // Eladási előzmények betöltése háttérszálon
        private async void LoadSalesHistory()
        {
            button1.Enabled = false;

            try
            {
                var sales = await Task.Run(() =>
                {
                    using var db = new ProductDbContext();

                    return db.IstoricVanzari
                        .AsNoTracking()
                        .Include(s => s.Produs)
                        .ThenInclude(p => p!.Categorie)
                        .Select(s => new
                        {
                            s.Id,
                            s.IdProdus,
                            ProductName = s.Produs != null
                                ? s.Produs.Name
                                : "Termék törölve",
                            s.Cantitate,
                            Category = s.Produs != null &&
                                       s.Produs.Categorie != null
                                ? s.Produs.Categorie.Denumire
                                : "Nincs kategória"
                        })
                        .OrderByDescending(s => s.Id)
                        .ToList();
                });

                if (IsDisposed)
                    return;

                dataGridView1.DataSource = sales;
                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    MessageBox.Show(
                        "Hiba az eladási előzmények betöltésekor:\n"
                        + ex.Message,
                        "Hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (!IsDisposed)
                    button1.Enabled = true;
            }
        }

        // Refresh
        private void button1_Click(object sender, EventArgs e)
        {
            LoadSalesHistory();
        }

        // Close
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}

