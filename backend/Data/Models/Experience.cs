using System.ComponentModel.DataAnnotations.Schema;

// public enum ExperienceType
// {
//     work,
//     education,
//     voluntary,
//     hobbyproject,
//     other,
// }

namespace backend.Data.Models
{
    [Table("experience", Schema = "public")]
    public record Experience(
        [property: Column("id")] Guid Id,
        [property: Column("user_id")] Guid UserId,
        [property: Column("title")] string Title,
        [property: Column("role")] string Role,
        [property: Column("type")] string Type,
        [property: Column("start_date")] DateTime StartDate,
        [property: Column("end_date")] DateTime? EndDate,
        [property: Column("description")] string Description,
        [property: Column("image_url")] string? ImageUrl,
        [property: Column("company")] string? Company
    )
    {
        public User? User { get; init; }
    }
}
