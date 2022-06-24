using AFS.Data.Context;
using AFS.Data.DbModels;
using AFS.Data.ResponseModels;
using AFS.Service.Helpers;
using AFS.Service.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public readonly AFSContext _db;
        public BaseService(AFSContext db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public ResponseModel Create(T model, bool IsSave = true)
        {
            try
            {
                _db.Set<T>().Add(model);
                if (IsSave)
                    Save();

                return ResponseHelper.IsSuccess(ResponseHelper.IsSuccessMessage,model);

            }
            catch (Exception ex)
            {
                return ResponseHelper.IsNotSuccess(JsonConvert.SerializeObject(ex));

            }
        }
        public IQueryable<T> GetEntityNoTrack()
        {
            return _db.Set<T>().AsNoTracking();
        }
    }
}
