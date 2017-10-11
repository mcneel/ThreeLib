using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// For creating lambert materials. Analogous to:
    /// https://threejs.org/docs/index.html#api/materials/MeshLambertMaterial
    /// </summary>
    public class IrisLambertMaterial : IrisMaterial, IEquatable<IrisLambertMaterial>
    {
        /// <summary>
        /// Object name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Material diffuse color.
        /// </summary>
        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; set; }

        /// <summary>
        /// Material ambient color.
        /// </summary>
        [JsonProperty("ambient")]
        public int Ambient { get; set; }

        /// <summary>
        /// Material emissive color.
        /// </summary>
        [JsonProperty("emissive")]
        public int Emissive { get; set; }

        /// <summary>
        /// Material opacity.
        /// </summary>
        [JsonProperty("opacity")]
        public double Opacity { get; set; }

        /// <summary>
        /// Material transparency flag.
        /// </summary>
        [JsonProperty("transparent")]
        public bool Transparent { get; set; }

        /// <summary>
        /// Material vertex color flag.
        /// </summary>
        [JsonProperty("vertexColors")]
        public int VertexColors { get; set; }

        /// <summary>
        /// Material side.
        /// </summary>
        [JsonProperty("side")]
        public int Side { get; set; }

        /// <summary>
        /// Material diffuse map.
        /// </summary>
        [JsonProperty("map")]
        public Guid Map { get; set; }

        /// <summary>
        /// Material bump map.
        /// </summary>
        [JsonProperty("bumpMap")]
        public Guid BumpMap { get; set; }

        /// <summary>
        /// Material alpha map.
        /// </summary>
        [JsonProperty("alphaMap")]
        public Guid AlphaMap { get; set; }

        /// <summary>
        /// Material environment map.
        /// </summary>
        [JsonProperty("envMap")]
        public Guid EnvironmentMap { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IrisLambertMaterial()
        {
            Type = "MeshLambertMaterial";
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="vertexColors"></param>
        public IrisLambertMaterial(Color color, int vertexColors) : this()
        {
            Color = IrisMethods.ColorToRGB(color);
            Side = 2;
            VertexColors = vertexColors;
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="diffuseColor"></param>
        /// <param name="ambientColor"></param>
        /// <param name="emissionColor"></param>
        /// <param name="transparency"></param>
        /// <param name="name"></param>
        /// <param name="vertexColors"></param>
        /// <param name="closed"></param>
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

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="diffuseColor"></param>
        /// <param name="ambientColor"></param>
        /// <param name="emissionColor"></param>
        /// <param name="transparency"></param>
        /// <param name="name"></param>
        /// <param name="mapUuid"></param>
        /// <param name="vertexColors"></param>
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

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="diffuseColor"></param>
        /// <param name="ambientColor"></param>
        /// <param name="emissionColor"></param>
        /// <param name="transparency"></param>
        /// <param name="name"></param>
        /// <param name="textures"></param>
        /// <param name="vertexColors"></param>
        /// <param name="closed"></param>
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

        /// <summary>
        /// Check if object equals another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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
    /// For collecting materials.
    /// </summary>
    public class IrisLambertMaterialCollection : Collection<IrisLambertMaterial>
    {
        /// <summary>
        /// Add a material to the collection if it is unique.
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