using Newtonsoft.Json;
using System;

namespace ThreeLib
{

    public interface IElement { }

    /// <summary>
    /// Base class for objects which have a Uuid, Name, and Type.
    /// </summary>
    public class Element : IElement
    {
        /// <summary>
        /// Unique Guid.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of object.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Element()
        {
            Uuid = Guid.NewGuid();
            Type = GetType().Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uuid"></param>
        public void SetUuid(Guid uuid)
        {
            Uuid = uuid;
        }

    }
}
