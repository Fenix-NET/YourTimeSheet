using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourTimeSheet.Core.DataTransferObject
{
    public class UserRegisterDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Требуется имя пользователя")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Требуется пароль")]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set;}

    }
}
