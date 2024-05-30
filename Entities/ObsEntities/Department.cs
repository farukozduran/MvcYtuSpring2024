﻿using Core.Repositories.CommonInterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsEntities
{
    public class Department : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FacultyId")]
        [Required(ErrorMessage = "This is required!")]
        public int FacultyId { get; set; }
        [Required(ErrorMessage = "This is required!")]
        public string? Name { get; set; }
    }
}
