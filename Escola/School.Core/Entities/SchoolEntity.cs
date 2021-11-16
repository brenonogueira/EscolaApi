using Sapiens.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace School.Core.Entities
{
    public class SchoolEntity : AuditBase
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }
        
        public long? CityId { get; set; }
        public City? City { get; set; }

        [StringLength(100)]
        public string? Coordinate { get; set; }

        [StringLength(50)]
        public string? Phone { get; set; }

        [StringLength(50)]
        public string? CelPhone { get; set; }

        [StringLength(100)]
        public string? WhatsApp { get; set; }

        [StringLength(100)] 
        public string Email { get; set; }

        [StringLength(18)] 
        public string Cnpj { get; set; }
        
        public bool Active { get; set; } = true;

        public SchoolEntity(string name, string cnpj, string email)
        {
            Name = name;
            Cnpj = cnpj;
            Email = email;
        }
    }
}
