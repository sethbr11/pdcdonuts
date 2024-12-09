namespace donuts.Models
{
    public class Donuts
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string flavor { get; set; }

        [Required]
        public string variety { get; set; }

        [Required]
        public string image { get; set; }
        
        public float? price { get; set; }
    }
}
