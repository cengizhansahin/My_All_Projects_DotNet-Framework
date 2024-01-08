using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class ApplyInfo
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool WillAttend { get; set; }
    }
}