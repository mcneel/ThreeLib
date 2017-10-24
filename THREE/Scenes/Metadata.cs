using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisLib
{
    /// <summary>
    /// Basic file metadata
    /// </summary>
    /// <remarks>
    /// This is used by scene and camera objects to define which format they are written in. 
    /// </remarks>
    public class Metadata
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public double Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("generator")]
        public string Generator { get; set; }
    }
}
