using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Data.Entity.Base
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
