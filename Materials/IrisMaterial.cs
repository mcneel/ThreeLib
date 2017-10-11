using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{

    /// <summary>
    /// Basic interface for Materials.
    /// </summary>
    public interface IIrisMaterial : IIrisElement
    {

    }

    /// <summary>
    /// Base class for materials.
    /// </summary>
    public class IrisMaterial : IIrisMaterial
    {
        /// <summary>
        /// Object Id.
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
        public IrisMaterial()
        {
            Uuid = Guid.NewGuid();
        }

        /// <summary>
        /// Set object Id.
        /// </summary>
        /// <param name="id"></param>
        public void SetId(Guid id)
        {
            Uuid = id;
        }

    }

    /// <summary>
    /// For collecting materials.
    /// </summary>
    public class IrisMaterialCollection : Collection<IIrisMaterial>
    {

    }
}
