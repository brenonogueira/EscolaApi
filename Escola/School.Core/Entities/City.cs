using Sapiens.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace School.Core.Entities
{
    public class City: AuditBase
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(2)]
        public string Region { get; set; }

        public City(string name, string region)
        {
            this.Name = name;
            this.Region = region;
        }
    }
}
