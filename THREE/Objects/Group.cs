using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisLib
{
    /// <summary>
    /// Class based on Object3D for grouping objects. Analogous to https://threejs.org/docs/index.html#api/objects/Group
    /// </summary>
    public class Group : Object3D
    {
        /// <summary>
        /// 
        /// </summary>
        public Group()
        {
            Type = "Group";
        }
    }
}
