using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BookStore2.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisallowNull]
        [MaxLength(80)]
        public string Name { get; set; }
    }
}
