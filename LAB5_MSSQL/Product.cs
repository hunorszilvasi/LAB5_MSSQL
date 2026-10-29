
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB5_MSSQL
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime EntryDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Quantity { get; set; }

        public int IdCategorie { get; set; }

        [ForeignKey(nameof(IdCategorie))]
        public CategorieProdus? Categorie { get; set; }
    }
}


