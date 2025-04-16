using System.ComponentModel.DataAnnotations;

namespace school_holistic.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public List<Teacher> teachers { get; set; } = new List<Teacher>();
    }
}
