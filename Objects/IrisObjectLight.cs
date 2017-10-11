using Newtonsoft.Json;
using System;

namespace IrisLib
{
    /// <summary>
    /// Base interface for light objects.
    /// </summary>
    public interface IIrisObjectLight : IIrisElement { }

    /// <summary>
    /// Base class for Light objects.
    /// </summary>
    public class IrisObjectLight : IIrisObjectLight
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        [JsonProperty("uuid", Order = -2)]
        public Guid Uuid { get; private set; }

        /// <summary>
        /// Object type.
        /// </summary>
        [JsonProperty("type", Order = -2)]
        public string Type { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IrisObjectLight()
        {
            Uuid = Guid.NewGuid();
        }

    }
}
