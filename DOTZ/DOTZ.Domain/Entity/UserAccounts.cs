using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOTZ.Domain.Entity
{
    [Table(nameof(UserAccounts))]
    public class UserAccounts
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
    }
}
