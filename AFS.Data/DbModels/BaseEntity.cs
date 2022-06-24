using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Data.DbModels
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public long CreateDate { get; set; }
    }
}
