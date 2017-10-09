using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace IrisLib
{
    public interface IIrisElement { }

    public class IrisElement : IIrisElement
    {
        [JsonProperty("uuid", Order = -2)]
        public Guid Uuid { get; private set; }

        [JsonProperty("type", Order = -2)]
        public string Type { get; set; }

        public IrisElement()
        {
            Uuid = Guid.NewGuid();
        }

        public void SetId(Guid id)
        {
            Uuid = id;
        }

        public static Dictionary<string, object> PrepareUserData(NameValueCollection userDataStrings)
        {
            var userData = new Dictionary<string, object>();
            var hasData = false;

            foreach (var key in userDataStrings.AllKeys)
            {
                
                if (userDataStrings.Get(key) != string.Empty || userDataStrings.Get(key) != null)
                {
                    userData.Add(key, userDataStrings.Get(key));
                    hasData = true;
                }
            }

            if (hasData) return userData;
            else return null;

        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
        }

    }

}
