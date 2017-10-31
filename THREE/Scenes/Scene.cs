using Newtonsoft.Json;

namespace THREE
{
    /// <summary>
    /// Scenes allow you to set up what and where is to be rendered by three.js. This is where you place objects, lights and cameras.
    /// Analogous to https://threejs.org/docs/index.html#api/scenes/Scene
    /// </summary>
    public class Scene : Object3D
    {

        #region Properties

        /// <summary>
        /// Background color for the scene.
        /// </summary>
        [JsonProperty("background")]
        public int Background { get; set; }

        [JsonIgnore]
        internal new SceneSerializationAdaptor SerializationAdaptor { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Converts this Scene to a compatible JSON format.
        /// </summary>
        /// <returns>JSON String.</returns>
        public override string ToJSON(bool format)
        {
            base.SerializationAdaptor = new Object3DSerializationAdaptor();

            ProcessChildren();

            SerializationAdaptor = new SceneSerializationAdaptor();
            SerializationAdaptor.Object.Name = Name;
            SerializationAdaptor.Object.Background = Background;
            SerializationAdaptor.Geometries = base.SerializationAdaptor.Geometries;
            SerializationAdaptor.Images = base.SerializationAdaptor.Images;
            SerializationAdaptor.Textures = base.SerializationAdaptor.Textures;
            SerializationAdaptor.Materials = base.SerializationAdaptor.Materials;
            SerializationAdaptor.Object.Children = base.SerializationAdaptor.Object.Children;

            return JsonConvert.SerializeObject(SerializationAdaptor, format == true ? Formatting.Indented : Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
        }

        #endregion

    }
    /// <summary>
    /// Internal class to format Scene object for the Three.js Object Scene Format:
    /// https://github.com/mrdoob/three.js/wiki/JSON-Object-Scene-format-4
    /// </summary>
    internal class SceneSerializationAdaptor : ObjectSerializationAdaptor
    {

        [JsonProperty("object", Order = 5)]
        internal SceneObject Object { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal SceneSerializationAdaptor()
        {
            Object = new SceneObject()
            {
                Type = "Scene"
            };
            Metadata.Generator = "ThreeLib-Object3D.toJSON";
        }

        internal class SceneObject : Object3D
        {
            [JsonProperty("background")]
            public int Background { get; set; }
        }
    }

}
