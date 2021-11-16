using System.ComponentModel.DataAnnotations;

namespace Sapiens.Core.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
