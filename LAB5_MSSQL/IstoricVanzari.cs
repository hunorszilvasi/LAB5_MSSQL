
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB5_MSSQL
{
    public class IstoricVanzari
    {
        public int Id { get; set; }

        public int IdProdus { get; set; }

        public int Cantitate { get; set; }

        [ForeignKey(nameof(IdProdus))]
        public Product? Produs { get; set; }
    }
}

