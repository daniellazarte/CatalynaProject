
using System.ComponentModel.DataAnnotations;

namespace Catalyna.Core.Entities
{
    public class User
    {
        public User()
        {

        }
        [Key]
        public int idUser { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
