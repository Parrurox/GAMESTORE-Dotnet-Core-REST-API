using System.ComponentModel.DataAnnotations;

namespace GameStore.api.Entities
{
    public class Game
    {
        public int ID { get; set; }

        [Required]  // validation added
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(0, 100)]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Url]
        [StringLength(255)]
        public string ImageUri { get; set; }
    }
}