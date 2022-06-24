using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Data.DbModels
{
    public class LogBusiness:BaseEntity
    {
        public string CallData { get; set; }
        public string ResultData { get; set; }
        public string UserEmail { get; set; }
    }
}
