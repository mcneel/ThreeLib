using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;

namespace IrisLib
{
    public class IrisLambertMaterial : IrisMaterial, IEquatable<IrisLambertMaterial>
    {

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; private set; }

        [JsonProperty("ambient")]
        public int Ambient { get; private set; }

        [JsonProperty("emissive")]
        public int Emissive { get; private set; }

        [JsonProperty("opacity")]
        public double Opacity { get; private set; }

        [JsonProperty("transparent")]
        public bool Transparent { get; private set; }

        [JsonProperty("vertexColors")]
        public int VertexColors { get; private set; }

        [JsonProperty("side")]
        public int Side { get; private set; }

        [JsonProperty("map")]
        public Guid Map { get; private set; }

        [JsonProperty("bumpMap")]
        public Guid BumpMap { get; private set; }

        [JsonProperty("alphaMap")]
        public Guid AlphaMap { get; private set; }

        [JsonProperty("envMap")]
        public Guid EnvironmentMap { get; private set; }

        public IrisLambertMaterial()
        {
            Type = "MeshLambertMaterial";
        }

        public IrisLambertMaterial(Color color, int vertexColors) : this()
        {
            Color = IrisMethods.ColorToRGB(color);
            Side = 2;
            VertexColors = vertexColors;
        }

        public IrisLambertMaterial(Color diffuseColor, Color ambientColor, Color emissionColor, double transparency, string name, int vertexColors, bool closed) : this()
        {
            bool transparent = false;
            double opacity = 1.0;
            int side = 2;
            if (transparency > 0)
            {
                transparent = true;
                opacity = 1 - transparency;
                //if (closed)
                // _side = 0;
            }

            Name = name;
            Color = IrisMethods.ColorToRGB(diffuseColor);
            Ambient = IrisMethods.ColorToRGB(ambientColor);
            Emissive = IrisMethods.ColorToRGB(emissionColor);
            Opacity = opacity;
            Transparent = transparent;
            VertexColors = vertexColors;
            Side = side;
        }

        public IrisLambertMaterial(Color diffuseColor, Color ambientColor, Color emissionColor, double transparency, string name, Guid mapUuid, int vertexColors) : this()
        {
            bool transparent = false;
            double opacity = 1.0;
            int side = 2;
            if (transparency > 0)
            {
                transparent = true;
                opacity = 1 - transparency;
            }

            Name = name;
            Color = IrisMethods.ColorToRGB(diffuseColor);
            Ambient = IrisMethods.ColorToRGB(ambientColor);
            Emissive = IrisMethods.ColorToRGB(emissionColor);
            Opacity = opacity;
            Transparent = transparent;
            VertexColors = vertexColors;
            Side = side;
            Map = mapUuid;
        }

        public IrisLambertMaterial(Color? diffuseColor = null, Color? ambientColor = null, Color? emissionColor = null, double transparency = 0, string name = "", Dictionary<string, Guid> textures = null, int vertexColors = 0, bool closed = false)
            : this()
        {
            bool transparent = false;
            double opacity = 1.0;
            int side = 2;
            if (transparency > 0)
            {
                transparent = true;
                opacity = 1 - transparency;
                if (Math.Abs(opacity) < double.Epsilon) opacity = 0.01;
                //if (closed)
                // _side = 0;
            }

            Guid bitmapId = Guid.Empty;
            Guid bumpId = Guid.Empty;
            Guid transparencyId = Guid.Empty;
            Guid environmentId = Guid.Empty;

            foreach (var texture in textures)
            {
                switch (texture.Key)
                {
                    case "bitmap":
                        bitmapId = texture.Value;
                        break;
                    case "bump":
                        bumpId = texture.Value;
                        break;
                    case "transparency":
                        transparencyId = texture.Value;
                        transparent = true;
                        //_side = 2;
                        break;
                    case "environment":
                        environmentId = texture.Value;
                        break;
                }

            }

            Name = name;
            Color = IrisMethods.ColorToRGB(diffuseColor.Value);
            Ambient = IrisMethods.ColorToRGB(ambientColor.Value);
            Emissive = IrisMethods.ColorToRGB(emissionColor.Value);

            Opacity = opacity;

            Transparent = transparent;
            Side = side;
            VertexColors = vertexColors;
            Map = bitmapId;
            BumpMap = bumpId;
            AlphaMap = transparencyId;
            EnvironmentMap = environmentId;
        }

        public bool Equals(IrisLambertMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Type.Equals(other.Type) &&
                       AlphaMap.Equals(other.AlphaMap) &&
                       Ambient.Equals(other.Ambient) &&
                       BumpMap.Equals(other.BumpMap) &&
                       Color.Equals(other.Color) &&
                       Emissive.Equals(other.Emissive) &&
                       EnvironmentMap.Equals(other.EnvironmentMap) &&
                       Map.Equals(other.Map) &&
                       Opacity.Equals(other.Opacity) &&
                       Side.Equals(other.Side) &&
                       Transparent.Equals(other.Transparent) &&
                       VertexColors.Equals(other.VertexColors);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IrisLambertMaterialCollection : Collection<IrisLambertMaterial>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisLambertMaterial item)
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