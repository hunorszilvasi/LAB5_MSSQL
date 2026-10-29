using System.ComponentModel.DataAnnotations;

namespace LAB5_MSSQL
{
    public class CategorieProdus
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Denumire { get; set; } = string.Empty;
    }
}
