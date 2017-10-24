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
    public class Line : Object3D
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("geometry")]
        public IGeometry Geometry { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("material")]
        public IMaterial Material { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Line()
        {
            Type = "Line";
        }
    }
}
