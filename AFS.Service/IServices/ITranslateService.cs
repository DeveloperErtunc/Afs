using AFS.Data.DbModels;
using AFS.Data.Models;
using AFS.Data.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Service.IServices
{
    public interface ITranslateService :IBaseService<TranslateData>
    {
        public ResponseModel AddTranslateData(ApiTranslateModel apiTranslateModel, Guid userId);
        public Task<ResponseModel> Translate(TextOfTranslate textOfTranslate, AppUser user);
    }
}
