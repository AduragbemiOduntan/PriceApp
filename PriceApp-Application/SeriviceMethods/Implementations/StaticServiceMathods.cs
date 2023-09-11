using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.SeriviceMethods.Implementations
{
    public static class StaticServiceMathods
    {
        public static string GetAppPassword()
        {
            string path = "C:\\Users\\aduragbemi.oduntan\\Desktop\\JustProjects\\PriceApp\\PriceApp-API\\appsettings.json";
            using (StreamReader reader = File.OpenText(path))
            {
                JObject jsonObject = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                string appPw = jsonObject["AppPW"]?.ToString();
                return appPw;
            }
        }
    }
}
