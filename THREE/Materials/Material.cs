using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Material : Element, IMaterial
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lights")]
        public bool Lights = true;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("flatShading")]
        public bool FlatShading = false;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vertexColors")]
        public int VertexColors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("side")]
        public int Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("opacity")]
        public float Opacity { get; set; }

        /// <summary>
        /// Object user data.
        /// </summary>
        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; set; }

        public Material()
        {
            Type = "Material";
        }
    }
}
