using System.ComponentModel.DataAnnotations;

namespace ModelExamen.Models
{
    public class Zbor
    {
        [Key]
        public int ZborId { get; set; }
        [Required]
        public string AeroportPlecare { get; set; }
        [Required]
        public string AeroportDestinatie { get; set; }
        [Required]
        public int Durata { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int PilotId { get; set; }
        public Pilot? Pilot { get; set; }
    }
}
