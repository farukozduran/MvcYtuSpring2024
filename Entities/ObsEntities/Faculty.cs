using Core.Repositories.CommonInterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsEntities
{
    public class Faculty : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is required!")]
        public string DeanName { get; set; }
    }
}
