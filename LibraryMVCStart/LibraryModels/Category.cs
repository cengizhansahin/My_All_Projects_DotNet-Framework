using System.ComponentModel.DataAnnotations;

namespace LibraryModels
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Name cannot be longer than 15 characters")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Display order should be between only 1 and 100")]
        public int DisplayOrder { get; set; }
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now; // Default olarak o anki tarih-saati vermiş olduk.
    }
}
