using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;

namespace IrisLib
{
    public class IrisPhongMaterial : IrisMaterial, IEquatable<IrisPhongMaterial>
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; private set; }

        [JsonProperty("ambient")]
        public int Ambient { get; private set; }

        [JsonProperty("emissive")]
        public int Emissive { get; private set; }

        [JsonProperty("specular")]
        public int Specular { get; private set; }

        [JsonProperty("shininess")]
        public double Shininess { get; private set; }

        [JsonProperty("opacity")]
        public double Opacity { get; private set; }

        [JsonProperty("transparent")]
        public bool Transparent { get; private set; }

        [JsonProperty("vertexColors", DefaultValueHandling = DefaultValueHandling.Include)]
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

        public IrisPhongMaterial()
        {
            Type = "MeshPhongMaterial";
        }

        public IrisPhongMaterial(string name, int color, int ambient, int emissive, int specular, double shininess, double opacity, bool transparent, int vertexColors, int side, Guid map, Guid bumpMap, Guid alphaMap, Guid environmentMap)
            : this()
        {
            Name = name;
            Color = color;
            Ambient = ambient;
            Emissive = emissive;
            Specular = specular;
            if (shininess < 1) shininess = 1;
            Shininess = shininess;
            Opacity = opacity;
            Transparent = transparent;
            VertexColors = vertexColors;
            Side = side;
            Map = map;
            BumpMap = bumpMap;
            AlphaMap = alphaMap;
            EnvironmentMap = environmentMap;
        }

        public IrisPhongMaterial(Color? diffuseColor = null, Color? ambientColor = null, Color? emissiveColor = null, Color? specularColor = null, double shine = 0, double transparency = 0, string name = null, Dictionary<string, Guid> textures = null, int vertexColors = 0) : this()
        {
            bool transparent = false;
            double opacity = 1.0;
            double _shine = 1.0;
            int side = 2;
            if (transparency > 0)
            {
                transparent = true;
                opacity = 1 - transparency;
                if (Math.Abs(opacity) < double.Epsilon) opacity = 0.01;
                //_side = 2;
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
            Emissive = IrisMethods.ColorToRGB(emissiveColor.Value);
            Specular = IrisMethods.ColorToRGB(specularColor.Value);
            Opacity = opacity;
            Shininess = shine < _shine ? _shine : shine;
            Transparent = transparent;
            Side = side;
            VertexColors = vertexColors;
            Map = bitmapId;
            BumpMap = bumpId;
            AlphaMap = transparencyId;
            EnvironmentMap = environmentId;

        }

        public IrisPhongMaterial(Color? diffuseColor = null, Color? ambientColor = null, Color? emissiveColor = null, Color? specularColor = null, double shine = 0, double transparency = 0, string name = null, Dictionary<string, Guid> textures = null, int vertexColors = 0, bool closed = false)
            : this()
        {
            bool transparent = false;
            double opacity = 1.0;
            double _shine = 1.0;
            int side = 2;
            if (transparency > 0)
            {
                transparent = true;
                opacity = 1 - transparency;
                if (Math.Abs(opacity) < double.Epsilon) opacity = 0.01;
                //if(closed)
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
                        // _side = 2;
                        break;
                    case "environment":
                        environmentId = texture.Value;
                        break;
                }

            }

            Name = name;
            Color = IrisMethods.ColorToRGB(diffuseColor.Value);
            Ambient = IrisMethods.ColorToRGB(ambientColor.Value);
            Emissive = IrisMethods.ColorToRGB(emissiveColor.Value);
            Specular = IrisMethods.ColorToRGB(specularColor.Value);
            Opacity = opacity;
            Shininess = shine < _shine ? _shine : shine;
            Transparent = transparent;
            Side = side;
            VertexColors = vertexColors;
            Map = bitmapId;
            BumpMap = bumpId;
            AlphaMap = transparencyId;
            EnvironmentMap = environmentId;
        }

        public IrisPhongMaterial(Color color, int vertexColors) : this()
        {
            Color = IrisMethods.ColorToRGB(color);
            Shininess = 1.0;
            Side = 2;
            VertexColors = vertexColors;
        }

        public IrisPhongMaterial(Color? diffuseColor = null, Color? ambientColor = null, Color? emissiveColor = null, Color? specularColor = null, double shine = 0, double transparency = 0, string name = null, int vectorColors = 0) : this()
        {
            bool transparent = false;
            double opacity = 1.0;
            double _shine = 1.0;
            int side = 2;
            if (transparency > 0)
            {
                transparent = true;
                opacity = 1 - transparency;
                //if (closed)
                //_side = 0;
            }

            Name = name;
            Color = IrisMethods.ColorToRGB(diffuseColor.Value);
            Ambient = IrisMethods.ColorToRGB(ambientColor.Value);
            Emissive = IrisMethods.ColorToRGB(emissiveColor.Value);
            Specular = IrisMethods.ColorToRGB(specularColor.Value);
            Opacity = opacity;
            Shininess = shine < _shine ? _shine : shine;
            Transparent = transparent;
            VertexColors = vectorColors;
            Side = side;
        }

        public IrisPhongMaterial(Color? diffuseColor = null, Color? ambientColor = null, Color? emissiveColor = null, Color? specularColor = null, double shine = 0, double transparency = 0, string name = null, int vectorColors = 0, bool closed = false)
            : this()
        {
            bool transparent = false;
            double opacity = 1.0;
            double _shine = 1.0;
            int side = 2;
            if (transparency > 0)
            {
                transparent = true;
                opacity = 1 - transparency;
                //if (closed)
                //_side = 0;
            }

            Name = name;
            Color = IrisMethods.ColorToRGB(diffuseColor.Value);
            Ambient = IrisMethods.ColorToRGB(ambientColor.Value);
            Emissive = IrisMethods.ColorToRGB(emissiveColor.Value);
            Specular = IrisMethods.ColorToRGB(specularColor.Value);
            Opacity = opacity;
            Shininess = shine < _shine ? _shine : shine;
            Transparent = transparent;
            VertexColors = vectorColors;
            Side = side;
        }

        public bool Equals(IrisPhongMaterial other)
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
                       Shininess.Equals(other.Shininess) &&
                       Side.Equals(other.Side) &&
                       Specular.Equals(other.Specular) &&
                       Transparent.Equals(other.Transparent) &&
                       VertexColors.Equals(other.VertexColors);
            }
        }
    }

    public class IrisPhongMaterialCollection : Collection<IrisPhongMaterial>
    {
        public Guid AddIfNew(IrisPhongMaterial item)
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
