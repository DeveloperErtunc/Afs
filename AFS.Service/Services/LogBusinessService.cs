using AFS.Data.Context;
using AFS.Data.DbModels;
using AFS.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Service.Services
{
    public class LogBusinessService : BaseService<LogBusiness>, ILogBusinessService
    {
        public LogBusinessService(AFSContext db) : base(db)
        {
        }
    }
}
