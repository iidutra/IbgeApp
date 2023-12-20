using System.ComponentModel.DataAnnotations;
namespace IbgeApp.Models
{
    public class Ibge
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(2, ErrorMessage = "O campo não pode ser vazio!")]
        public string State { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "O nome tem que possuir mais de 2 caracteres!")]
        [MaxLength(40, ErrorMessage = "O nome não pode ter mais de 40 caracteres")]
        public string City { get; set; } = string.Empty;
    }
}
