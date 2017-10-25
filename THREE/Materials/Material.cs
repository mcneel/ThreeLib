using Newtonsoft.Json;
using System.Collections.Generic;

namespace IrisLib
{
    /// <summary>
    /// Abstract base class for materials.
    /// Analogous to: https://threejs.org/docs/index.html#api/materials/Material
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/materials/Material.js
    /// </summary>
    public abstract class Material : Element, IMaterial
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
