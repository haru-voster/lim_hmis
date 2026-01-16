using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisitAPI.Models
{
    [Table("result_table")] // Maps directly to your SQL table
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment Id
        public int Id { get; set; }

        [Required] // TestName should not be null
        [MaxLength(100)] // Optional: limit length
        public string TestName { get; set; } = null!; // null-forgiving operator

        [MaxLength(500)] // Optional: limit length for test values
        public string? TestValue { get; set; }

        [Required]
        public int LabRequestId { get; set; }

        // Navigation property (optional, useful if you want EF Core to track relationships)
        [ForeignKey("LabRequestId")]
        public LabRequest? LabRequest { get; set; }
    }
}
