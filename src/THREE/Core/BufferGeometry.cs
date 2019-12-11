using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using THREE.Serialization;
using THREE.Utility;

namespace THREE.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class BufferGeometry : Element, IGeometry, IEquatable<BufferGeometry>
    {

        [JsonProperty("data")]
        BufferGeometryData Data { get; set; }

        [JsonProperty("index")]
        public BufferAttribute Index 
        {
            get { return Data.Index; }
            set { Data.Index = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public BufferGeometryBoundingSphere BoundingSphere
        {
            get { return Data.BoundingSphere; }
            set { Data.BoundingSphere = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, BufferAttribute> Attributes
        {
            get { return Data.Attributes; }
            set { Data.Attributes = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public BufferGeometry()
        {
            Data = new BufferGeometryData();
            Attributes = new Dictionary<string, BufferAttribute>();
            BoundingSphere = new BufferGeometryBoundingSphere();
        }

        public void SetIndex(BufferAttribute index)
        {
            Data.Index = index;
        }

        public string ToJSON(bool format)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = format == true ? Formatting.Indented : Formatting.None,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCaseCustomResolver()
            };

            return JsonConvert.SerializeObject(this, serializerSettings);
        }

        public bool Equals(BufferGeometry other)
        {
            if (other == null) return false;
            else
                return Data.Attributes.SequenceEqual(other.Data.Attributes)&&
                       Data.BoundingSphere.Equals(other.BoundingSphere)&&
                       Data.Index.Equals(other.Data.Index);
        }

        public override bool Equals(object other)
        {
            if (other.GetType() == typeof(BufferGeometry)) return Equals((BufferGeometry)other) && base.Equals(other);
            else return false;
        }

        /// <summary>
        /// Override of the == operator.
        /// </summary>
        /// <param name="a">The first buffer geometry.</param>
        /// <param name="b">The second buffer geometry.</param>
        /// <returns>True if buffer geometries are equal, false if not.</returns>
        public static bool operator ==(BufferGeometry a, BufferGeometry b)
        {
            bool ba = a is null;
            bool bb = b is null;
            if (ba & bb) return true; //they are both null, thus are equal
            else if (!ba & !bb) return a.Equals(b); //they are both not null, check their contents
            else return false; //one of them is null, thus they are not equal
        }

        /// <summary>
        /// Override the != operator.
        /// </summary>
        /// <param name="a">The first buffer geometry.</param>
        /// <param name="b">The second buffer geometry.</param>
        /// <returns>False if buffer geometries are equal, true if not.</returns>
        public static bool operator !=(BufferGeometry a, BufferGeometry b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Override of the GetHashCode function.
        /// </summary>
        /// <returns>A hashcode of the combined data.</returns>
        public override int GetHashCode()
        {
            return Data.Attributes.GetHashCode() ^ Data.BoundingSphere.GetHashCode() ^ Data.Index.GetHashCode();
        }

    }

    internal class BufferGeometryData
    {
        [JsonProperty("attributes")]
        internal Dictionary<string, BufferAttribute> Attributes { get; set; }

        [JsonProperty("boundingSphere")]
        internal BufferGeometryBoundingSphere BoundingSphere { get; set; }

        [JsonProperty("index")]
        internal BufferAttribute Index { get; set; }
    }

    /// <summary>
    /// Data for the bounding sphere.
    /// </summary>
    public class BufferGeometryBoundingSphere
    {
        /// <summary>
        /// Center position of the bounding sphere.
        /// </summary>
        [JsonProperty("center")]
        public float[] Center { get; set; }

        /// <summary>
        /// Radius of the bounding sphere.
        /// </summary>
        [JsonProperty("radius")]
        public float Radius { get; set; }

    }

    public class BufferGeometryCollection : Collection<BufferGeometry>
    {
        /// <summary>
        /// Add a BufferGeometry to this collection if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(BufferGeometry item)
        {
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

    internal class BufferGeometrySerializationAdapter : SerializationAdaptor
    {

    }
}
