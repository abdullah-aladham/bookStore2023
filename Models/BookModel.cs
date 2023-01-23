using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookStore2.Models
{
    public class BookModel
    {
        [Key]
        [Column]
        public int Id { get; set; }
        [Required]
        [DisallowNull]
        [MaxLength(80)]
        public string Title { get; set; }   

    }
}
