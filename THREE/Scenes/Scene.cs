using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 
        /// </summary>
        public Scene()
        {
            Type = "Scene";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToJSON()
        {
            var sceneSerializer = new SceneSerializer()
            {
                Metadata = new Metadata
                {
                    Version = 4.5,
                    Type = "Object",
                    Generator = "ThreeLib"
                }
            };

            foreach (var child in Children)
            {
                Debug.WriteLine((child as Element).Type, "ThreeLib");
                switch ((child as Element).Type)
                {
                    case "Mesh":
                        try
                        {
                            var mesh = child as Mesh;
                            sceneSerializer.Geometries.Add(mesh.Geometry);

                            if(mesh.Material is MeshStandardMaterial)
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
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message, "ThreeLib");
                        }

                        break;
                    default:
                        Debug.WriteLine((child as Element).Type);
                        break;
                }
            }

            return JsonConvert.SerializeObject(sceneSerializer, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
        }

    }

    internal class SceneSerializer
    {
        [JsonProperty("metadata")]
        internal Metadata @Metadata { get; set; }

        [JsonProperty("geometries")]
        internal List<IGeometry> Geometries { get; set; }

        [JsonProperty("images")]
        internal List<Image> Images { get; set; }

        [JsonProperty("textures")]
        internal List<ITexture> Textures { get; set; }

        [JsonProperty("materials")]
        internal List<IMaterial> Materials { get; set; }

        [JsonProperty("object")]
        internal Object3D @Object { get; set; }


        internal SceneSerializer()
        {
            Geometries = new List<IGeometry>();
            Materials = new List<IMaterial>();
            Images = new List<Image>();
            Textures = new List<ITexture>();
            Object = new Object3D()
            {
                Type = "Scene"
            };
        }
    }



}
