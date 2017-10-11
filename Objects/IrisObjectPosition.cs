using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace IrisLib
{
    /// <summary>
    /// Adds a position element to the scene. A position element records the orientation and position of a given number of objects.
    /// </summary>
    public class IrisObjectPosition : IrisElement
    {
        /// <summary>
        /// Name of the position.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Position collection.
        /// </summary>
        [JsonProperty("positions")]
        public float[][] Positions { get; set; }

        /// <summary>
        /// Objects which are modified by this position.
        /// </summary>
        [JsonProperty("objectIds")]
        public Guid[] ObjectIds { get; set; }

        /// <summary>
        /// User data for the position.
        /// </summary>
        [JsonProperty("userData")]
        public List<Dictionary<string, object>> UserData { get; private set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        public IrisObjectPosition()
        {
            Type = "Position";
        }


    }

}
