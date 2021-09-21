using System;
using System.ComponentModel.DataAnnotations;

namespace SRProject.Models
{
    public class VehicleType
    {
        [Key]
        public Guid VehicleTypeId { get; set; }
        [Required(ErrorMessage ="Vehicle Type name field is required")]
        [MaxLength(50)]
        [MinLength(5)]
        [Display(Name ="Vehicle Type Name")]
        public string VehicleTypeName { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
