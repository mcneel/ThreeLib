using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{

    public interface IIrisMaterial : IIrisElement
    {

    }

    public class IrisMaterial : IIrisMaterial
    {

        [JsonProperty("uuid", Order = -2)]
        public Guid Uuid { get; private set; }

        [JsonProperty("type", Order = -2)]
        public string Type { get; set; }

        public IrisMaterial()
        {
            Uuid = Guid.NewGuid();
        }

        public void SetId(Guid id)
        {
            Uuid = id;
        }

    }

    public class IrisMaterialCollection : Collection<IIrisMaterial>
    {

    }
}
