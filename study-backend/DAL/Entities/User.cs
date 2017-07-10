using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Resources;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(20, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "UserNameMaxLengthError")]
        [MinLength(3 , ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "UserNameMinLengthError")]
        [RegularExpression("([A-Za-z._0-9]+)", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "UserNameFormatError")]
        public string UserName { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(40, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "EmailMaxLengthError")]
        [RegularExpression("([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "EmailFormatError")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "PasswordMaxLengthError")]
        [MinLength(8, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "PasswordMinLengthError")]
        public string Password { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
