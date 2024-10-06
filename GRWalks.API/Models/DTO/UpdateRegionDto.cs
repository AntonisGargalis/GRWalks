using System.ComponentModel.DataAnnotations;

namespace GRWalks.API.Models.DTO
{
    public class UpdateRegionDto
    {
        [Required]  // data anotanions
        public string Name { get; set; }
        [Required]
        [MaxLength(2, ErrorMessage = "Two characters only")]
        [MinLength(2, ErrorMessage = "Two characters only")]
        public string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
