using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resources.Errors), ErrorMessageResourceName = "UserNameMaxLengthError")]
        [MinLength(3 , ErrorMessageResourceType = typeof(Resources.Errors), ErrorMessageResourceName = "UserNameMinLengthError")]
        [RegularExpression("([A-Za-z._])", ErrorMessageResourceType = typeof(Resources.Errors), ErrorMessageResourceName = "UserNameFormatError")]
        public string UserName { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(40, ErrorMessageResourceType = typeof(Resources.Errors), ErrorMessageResourceName = "EmailMaxLengthError")]
        [RegularExpression("([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})", ErrorMessageResourceType = typeof(Resources.Errors), ErrorMessageResourceName = "EmailFormatError")]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; protected set; }

        [Required]
        [MinLength(8, ErrorMessageResourceType = typeof(Resources.Errors), ErrorMessageResourceName = "EmailFormatError")]
        public string Password
        {
            set
            {
                var hashFunction = System.Security.Cryptography.MD5.Create();
                PasswordHash = hashFunction.ComputeHash(Encoding.UTF8.GetBytes(value));
            }
        }

        [Required]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

    }
}
