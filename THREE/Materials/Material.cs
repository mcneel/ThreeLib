using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace IrisLib
{
    public interface IMaterial { }

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
            Type = GetType().Name;
        }
    }

    /// <summary>
    /// Abstract base class for materials.
    /// Analogous to: https://threejs.org/docs/index.html#api/materials/Material
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/materials/Material.js
    /// </summary>
    public abstract class MaterialBase<T> : Material, IEquatable<T> where T : MaterialBase<T>
    {
        
        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {

                return Type.Equals(other.Type) &&
                       Opacity.Equals(other.Opacity) &&
                       Side.Equals(other.Side) &&
                       VertexColors.Equals(other.VertexColors) &&
                       FlatShading.Equals(other.FlatShading);
            }
        }
    }

    public class MaterialCollection: Collection<Material>
    {
        /// <summary>
        /// Add a geometry to this collection if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(Material item)
        {
            Debug.WriteLine(item.Type,"ThreeLib");

            var q = from a in this
                    where a.Equals(item)
                    select a.Uuid;

            var enumerable = q as Guid[] ?? q.ToArray();
            if (!enumerable.Any())
            {
                Add(item);
                return item.Uuid;
            }
            else
            {
                return enumerable.Single();
            }
        }
    }
}
