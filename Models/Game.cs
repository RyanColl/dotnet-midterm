using System.ComponentModel.DataAnnotations;

namespace OlympicsWeb.Models
{
    public class Game
    {
        public string Id { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(30)]
        public string Country { get; set; }
        [MaxLength(30)]
        public string Continent { get; set; }
        [MaxLength(30)]
        public string Season { get; set; }
        public string Year { get; set; }
        public string Opening { get; set; }
        public string Closing { get; set; }
    }
}