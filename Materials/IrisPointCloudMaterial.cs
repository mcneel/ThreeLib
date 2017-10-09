using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{
    public class IrisPointCloudMaterial : IrisMaterial, IEquatable<IrisPointCloudMaterial>
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("color")]
        public int Color { get; private set; }

        [JsonProperty("size")]
        public double Size { get; private set; }

        [JsonProperty("sizeAttenuation", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool SizeAttenuation { get; private set; }

        [JsonProperty("vertexColors")]
        public int VertexColors { get; private set; }

        [JsonProperty("map")]
        public Guid Map { get; private set; }

        [JsonProperty("fog")]
        public bool Fog { get; private set; }

        public IrisPointCloudMaterial()
        {
            Type = "PointsMaterial";
            Color = IrisMethods.ColorToRGB(System.Drawing.Color.White);
            Size = 5;
            SizeAttenuation = false;
            VertexColors = 2;
        }

        public IrisPointCloudMaterial(string name, int color, double size, bool sizeAttenuation, int vertexColors, Guid map, bool fog)
            : this()
        {
            Name = name;
            Color = color;
            Size = size;
            SizeAttenuation = sizeAttenuation;
            VertexColors = vertexColors;
            Map = map;
            Fog = fog;
        }

        public IrisPointCloudMaterial(Guid texture) : this()
        {
            Color = IrisMethods.ColorToRGB(System.Drawing.Color.White);
            Size = 5;
            SizeAttenuation = false;
            VertexColors = 2;
            Map = texture;
        }

        public bool Equals(IrisPointCloudMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Type.Equals(other.Type) &&
                       Color.Equals(other.Color);
            }
        }
    }

    public class IrisPointCloudMaterialCollection : Collection<IrisPointCloudMaterial>
    {
        public Guid AddIfNew(IrisPointCloudMaterial item)
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
}
