using System.ComponentModel.DataAnnotations;

namespace ModelExamen.Models
{
    public class Pilot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public int Varsta { get; set; }
        [Required]
        public string Nationalitate { get; set; }
    }
}
