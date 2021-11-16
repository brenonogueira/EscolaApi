using System.ComponentModel.DataAnnotations;

namespace Sapiens.Core.Entities
{
    public abstract class AuditBase : EntityBase
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }

        [StringLength(100)]
        public string? DeletedBy { get; set; }
    }
}
