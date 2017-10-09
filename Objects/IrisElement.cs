using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace IrisLib
{
    /// <summary>
    /// Basic interface for creating generic lists of IrisElement.
    /// </summary>
    public interface IIrisElement { }

    /// <summary>
    /// Basic element base class. Includes Uuid and Type properties.
    /// </summary>
    public class IrisElement : IIrisElement
    {
        /// <summary>
        /// Unique Id.
        /// </summary>
        [JsonProperty("uuid", Order = -2)]
        public Guid Uuid { get; private set; }

        /// <summary>
        /// Object type.
        /// </summary>
        [JsonProperty("type", Order = -2)]
        public string Type { get; set; }

        /// <summary>
        /// Constructor for an IrisElement.
        /// </summary>
        public IrisElement()
        {
            Uuid = Guid.NewGuid();
        }

        /// <summary>
        /// Sets the Uuid of this Iris Element to something else.
        /// </summary>
        /// <param name="id"></param>
        public void SetId(Guid id)
        {
            Uuid = id;
        }

        /// <summary>
        /// Prepares user data.
        /// </summary>
        /// <param name="userDataStrings"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Serializes this object to JSON.
        /// </summary>
        /// <returns></returns>
        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
        }

    }

}
