using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyna.Core.DTOS
{
    public class UserDTO
    {
          public UserDTO()
    {

    }
    [Key]
    public int idUser { get; set; }
    public string NickName { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
}
}
