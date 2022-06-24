using AFS.Data.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Service.IServices
{
    public interface IBaseService<T> where T : class
    {
        ResponseModel Create(T model, bool IsSave = true);
        IQueryable<T> GetEntityNoTrack();
        void Save();
    }
}
