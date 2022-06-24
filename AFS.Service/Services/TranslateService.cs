using AFS.Data.Context;
using AFS.Data.DbModels;
using AFS.Data.Models;
using AFS.Data.ResponseModels;
using AFS.Service.Helpers;
using AFS.Service.IServices;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Service.Services
{
    public class TranslateService : BaseService<TranslateData>, ITranslateService
    {
      readonly  ILogBusinessService _logBusinessService;
        public TranslateService(AFSContext db, ILogBusinessService logBusinessService) : base(db)
        {
            _logBusinessService = logBusinessService;
        }

        public ResponseModel AddTranslateData(ApiTranslateModel apiTranslateModel, Guid userId)
        {
            return Create(new TranslateData
            {
                CreateDate = DateHelper.GetUtcTimeFromHelper(),
                DataToTranslate = apiTranslateModel.contents.text,
                DataTranslated = apiTranslateModel.contents.translated,
                Id = Guid.NewGuid(),
                IdentityUserId = userId
            });
        }

        public async Task<ResponseModel> Translate(TextOfTranslate textOfTranslate, AppUser user)
        {
            HttpClient client = new HttpClient();
            var data = JsonConvert.SerializeObject(textOfTranslate);
            var log = new LogBusiness
            {
                CreateDate = DateHelper.GetUtcTimeFromHelper(),
                CallData = data,
                Id = Guid.NewGuid(),
                UserEmail = user.Email
            };
            var stringContent = new StringContent(data);

            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("https://api.funtranslations.com/translate/leetspeak.json", stringContent);
            if(response.StatusCode != HttpStatusCode.OK)
            {
                log.ResultData = response.ReasonPhrase;
                _logBusinessService.Create(log);
                return ResponseHelper.IsNotSuccess(response.ReasonPhrase);    
            }
            string result = response.Content.ReadAsStringAsync().Result;
            var apiTranslateModel = JsonConvert.DeserializeObject<ApiTranslateModel>(result);
            if (apiTranslateModel != null && apiTranslateModel.success.total == 1)
            {
                var responseFromAdd = AddTranslateData(apiTranslateModel, user.Id);
                if (responseFromAdd.IsSuccess)
                {
                    log.ResultData = result;
                    _logBusinessService.Create(log);
                    return responseFromAdd;
                }
                return responseFromAdd;
            }
            else
            {
                return ResponseHelper.IsNotSuccess();
            }

        }
    }
}
