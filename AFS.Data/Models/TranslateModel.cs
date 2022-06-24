using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Data.Models
{
    public class LogBusinessDTO 
    {
        public string DataTime { get; set; }
        public ApiTranslateModel ApiTranslateModel { get; set; }
        public TextOfTranslate TextOfTranslate { get; set; }
        public string UserEmail { get; set; }
    }

    public class Contents
    {
        public string translation { get; set; }
        public string text { get; set; }
        public string translated { get; set; }
    }
    public class TextOfTranslate
    {
        public string text { get; set; }
    }
    public class ApiTranslateModel
    {
        public Success success { get; set; }
        public Contents contents { get; set; }
    }

    public class Success
    {
        public int total { get; set; }
    }
}
