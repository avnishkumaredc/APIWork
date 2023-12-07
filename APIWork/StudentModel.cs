using System.ComponentModel.DataAnnotations;

namespace APIWork
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public char Gender { get; set; }
        public double Fees { get; set; }
    }
}
