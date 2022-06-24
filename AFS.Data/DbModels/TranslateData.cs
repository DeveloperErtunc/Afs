using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Data.DbModels
{
    public class TranslateData:BaseEntity
    {
        [Required]
        public string DataToTranslate { get; set; }
        [Required]
        public string DataTranslated { get; set; }
        public Guid IdentityUserId { get; set; }
    }
}
