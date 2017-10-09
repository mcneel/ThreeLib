using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace IrisLib
{

    public class IrisObjectPosition : IrisElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("positions")]
        public float[][] Positions { get; set; }

        [JsonProperty("objectIds")]
        public Guid[] ObjectIds { get; set; }

        [JsonProperty("userData")]
        public List<Dictionary<string, object>> UserData { get; private set; }

        public IrisObjectPosition()
        {
            Type = "Position";
        }


    }

}
