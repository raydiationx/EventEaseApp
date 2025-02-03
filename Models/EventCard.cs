using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(100, ErrorMessage = "Event name cannot be longer than 100 characters.")]
        public string? EventName { get; set; }

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(200, ErrorMessage = "Location cannot be longer than 200 characters.")]
        public string? Location { get; set; }
    }
}