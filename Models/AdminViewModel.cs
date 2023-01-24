using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookStore2.Models
{
    public class AdminViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisallowNull]
        [MaxLength(80)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
