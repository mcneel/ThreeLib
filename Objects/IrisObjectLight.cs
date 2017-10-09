using Newtonsoft.Json;
using System;

namespace IrisLib
{
    public interface IIrisObjectLight : IIrisElement { }

    public class IrisObjectLight : IIrisObjectLight
    {
        [JsonProperty("uuid", Order = -2)]
        public Guid Uuid { get; private set; }

        [JsonProperty("type", Order = -2)]
        public string Type { get; set; }

        public IrisObjectLight()
        {
            Uuid = Guid.NewGuid();
        }

    }
}
