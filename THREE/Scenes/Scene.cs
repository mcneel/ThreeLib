using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace IrisLib
{
    /// <summary>
    /// Scenes allow you to set up what and where is to be rendered by three.js. This is where you place objects, lights and cameras.
    /// Analogous to https://threejs.org/docs/index.html#api/scenes/Scene
    /// </summary>
    public class Scene : Object3D
    {
        /// <summary>
        /// Background color for the scene.
        /// </summary>
        [JsonProperty("background")]
        public int Background { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Scene()
        {
            Type = "Scene";
        }

        /// <summary>
        /// Converts this Scene to a compatible JSON format.
        /// </summary>
        /// <returns>JSON String.</returns>
        public override string ToJSON()
        {
            var sceneSerializer = new SceneSerializer
            {
                Metadata = new Metadata
                {
                    Version = 4.5,
                    Type = "Object",
                    Generator = "ThreeLib"
                }
            };

            sceneSerializer.Object.Name = Name;
            sceneSerializer.Object.Background = Background;

            foreach (var child in Children)
            {
                Debug.WriteLine((child as Element).Type, "ThreeLib");

                if (child.GetType().GetProperty("Geometry") != null)
                {
                    var currentGeo = child.GetType().GetProperty("Geometry").GetValue(child, null) as Geometry;
                    var geoId = sceneSerializer.Geometries.AddIfNew(currentGeo);
                    currentGeo.Uuid = geoId;
                }

                switch ((child as Element).Type)
                {
                    case "Mesh":

                        var mesh = child as Mesh;
                            
                        if (mesh.Material is MeshStandardMaterial)
                        {
                            var material = mesh.Material as MeshStandardMaterial;

                            foreach (var map in material.GetTextures())
                                if (map != null)
                                {
                                    sceneSerializer.Images.Add(map.Image);
                                    sceneSerializer.Textures.Add(map);
                                }

                            sceneSerializer.Materials.Add(material);
                        }

                        sceneSerializer.Object.Children.Add(mesh);
                   
                        break;

                    case "Line":

                        var line = child as Line;
                        sceneSerializer.Materials.Add(line.Material as LineBasicMaterial);
                        sceneSerializer.Object.Children.Add(line);

                        break;

                    case "Points":

                        var points = child as Points;
                        sceneSerializer.Materials.Add(points.Material as PointsMaterial);
                        sceneSerializer.Object.Children.Add(points);

                        break;

                    case "PointLight":
                    case "AmbientLight":
                    case "SpotLight":
                    case "DirectionalLight":
                        sceneSerializer.Object.Children.Add(child);
                        break;

                    default:
                        Debug.WriteLine((child as Element).Type, "ThreeLib");
                        break;
                }
            }

            return JsonConvert.SerializeObject(sceneSerializer, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
        }

    }

    /// <summary>
    /// Internal class to format Scene object for the Three.js Object Scene Format:
    /// https://github.com/mrdoob/three.js/wiki/JSON-Object-Scene-format-4
    /// </summary>
    internal class SceneSerializer
    {
        [JsonProperty("metadata")]
        internal Metadata @Metadata { get; set; }

        [JsonProperty("geometries")]
        internal GeometryCollection Geometries { get; set; }

        [JsonProperty("images")]
        internal List<Image> Images { get; set; }

        [JsonProperty("textures")]
        internal List<Texture> Textures { get; set; }

        [JsonProperty("materials")]
        internal List<IMaterial> Materials { get; set; }

        [JsonProperty("object")]
        internal SceneObject @Object { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal SceneSerializer()
        {
            Geometries = new GeometryCollection();
            Materials = new List<IMaterial>();
            Images = new List<Image>();
            Textures = new List<Texture>();
            Object = new SceneObject()
            {
                Type = "Scene"
            };
        }
    }

    internal class SceneObject : Object3D
    {
        [JsonProperty("background")]
        public int Background { get; set; }
    }



}
