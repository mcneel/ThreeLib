using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace THREE
{
    /// <summary>
    /// Base class for all objects. Analogous to https://threejs.org/docs/index.html#api/core/Object3D
    /// </summary>
    public class Object3D : Element
    {

        #region Properties

        /// <summary>
        /// Object visibility.
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Flag for determining if object casts shadow.
        /// </summary>
        [JsonProperty("castShadow")]
        public bool CastShadow { get; set; }

        /// <summary>
        /// Flag for determining if object receives shadow.
        /// </summary>
        [JsonProperty("receiveShadow")]
        public bool ReceiveShadow { get; set; }

        /// <summary>
        /// List with object's children.
        /// </summary>
        [JsonProperty("children")]
        public List<IElement> Children { get; set; }

        [JsonIgnore]
        public Object3D Parent { get; set; }

        /// <summary>
        /// Object user data.
        /// </summary>
        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; set; }

        /// <summary>
        /// Object matrix.
        /// </summary>
        [JsonIgnore]
        public Matrix4 Matrix { get; set; }

        [JsonProperty("matrix")]
        public IEnumerable<object> MatrixArray { get { return Matrix.ToObjectList(); } }

        /// <summary>
        /// The object's local position.
        /// </summary>
        [JsonIgnore]
        public Vector3 Position { get { return Position; } set { Matrix.SetPosition(value); } }

        [JsonIgnore]
        public Euler Rotation { get; set; }

        [JsonIgnore]
        public Quaternion Quaternion { get; set; }

        [JsonIgnore]
        public Vector3 Scale { get; set; }

        [JsonIgnore]
        internal Object3DSerializationAdaptor SerializationAdaptor { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor. Results in an empty Object3D with new Uuid.
        /// </summary>
        public Object3D()
        {
            Children = new List<IElement>();
            Matrix = Matrix4.Identity();
            Position = new Vector3();
            Rotation = new Euler();
            Quaternion = new Quaternion();
            Scale = new Vector3 { X = 1, Y = 1, Z = 1 };
            Parent = null;
        }

        #endregion

        #region Methods

        public void UpdateMatrix()
        {
            Matrix.Compose(Matrix.GetPosition(), Quaternion, Scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeChildren()
        {
            return Children.Count > 0;
        }

        /// <summary>
        /// Adds an object as a child of this object.
        /// </summary>
        /// <param name="obj"></param>
        public void Add(IElement obj)
        {
            if (obj.GetType().IsSubclassOf(typeof(Object3D)))
                (obj as Object3D).Parent = this;
            
            Children.Add(obj);
        }

        /// <summary>
        /// Adds a list of objects as children of this object.
        /// </summary>
        /// <param name="objs"></param>
        public void AddRange(List<IElement> objs)
        {
            Children.AddRange(objs);
        }

        /// <summary>
        /// Convert the object to JSON format. 
        /// </summary>
        /// <returns>A string representation of this object, serialized to JSON.</returns>
        /// <summary>
        /// Converts this Scene to a compatible JSON format.
        /// </summary>
        /// <returns>JSON String.</returns>
        public virtual string ToJSON(bool format)
        {

            SerializationAdaptor = new Object3DSerializationAdaptor();
            SerializationAdaptor.Object.Name = Name;

            ProcessChildren();

            return JsonConvert.SerializeObject(SerializationAdaptor, format ==true ? Formatting.Indented : Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
        }

        internal void ProcessChildren(Group group = null)
        {
            var children = new List<IElement>();

            if (group == null)
                children = Children;
            else
            {
                children = group.Children;
                if (!(group.Parent is Group) && group.Parent.Parent == null)
                {
                    SerializationAdaptor.Object.Children.Add(group);
                }
            }

            foreach (var child in children)
            {
                Debug.WriteLine((child as Element).Type, "ThreeLib");

                if (child.GetType() == typeof(Group))
                {
                    ProcessChildren(child as Group);
                }

                else
                {
                    

                    if (child.GetType().GetProperty("Geometry") != null)
                    {
                        var currentGeo = child.GetType().GetProperty("Geometry").GetValue(child, null) as Geometry;
                        var geoId = SerializationAdaptor.Geometries.AddIfNew(currentGeo);
                        currentGeo.Uuid = geoId;
                    }

                    switch ((child as Element).Type)
                    {
                        case "Mesh":

                            var mesh = child as Mesh;

                            if (mesh.Material is MeshStandardMaterial)
                            {
                                var material = mesh.Material as MeshStandardMaterial;

                                foreach (var kvp in material.GetTextures())
                                    if (kvp.Value != null)
                                    {
                                        SerializationAdaptor.Images.Add(kvp.Value.Image);
                                        SerializationAdaptor.Textures.Add(kvp.Value);
                                    }

                                material.Uuid = SerializationAdaptor.Materials.AddIfNew(material);

                            }

                            if(group == null)
                                SerializationAdaptor.Object.Children.Add(mesh);

                            break;

                        case "Line":

                            var line = child as Line;
                            SerializationAdaptor.Materials.Add(line.Material as LineBasicMaterial);

                            if (group == null)
                                SerializationAdaptor.Object.Children.Add(line);

                            break;

                        case "Points":

                            var points = child as Points;
                            SerializationAdaptor.Materials.Add(points.Material as PointsMaterial);

                            if (group == null)
                                SerializationAdaptor.Object.Children.Add(points);

                            break;

                        case "PointLight":
                        case "AmbientLight":
                        case "SpotLight":
                        case "DirectionalLight":
                        case "HemisphereLight":
                        case "PerspectiveCamera":
                        case "OrthographicCamera":
                            if (group == null)
                                SerializationAdaptor.Object.Children.Add(child);
                            break;
                            /*
                        case "Group":
                            var group = child as Group;
                            group.SerializationAdaptor = new Object3DSerializationAdaptor();
                            group.ProcessChildren();

                            foreach (var o in group.Children)
                            {

                                if (o.GetType().GetProperty("Geometry") != null)
                                {
                                    var g = o.GetType().GetProperty("Geometry").GetValue(o, null) as Geometry;
                                    g.Uuid = SerializationAdaptor.Geometries.AddIfNew(g);
                                }

                                if (o.GetType().GetProperty("Material") != null)
                                {
                                    var m = o.GetType().GetProperty("Material").GetValue(o, null) as Material;

                                    if (m is MeshStandardMaterial)
                                    {
                                        var msm = m as MeshStandardMaterial;
                                        foreach (var t in msm.GetTextures())
                                        {
                                            if (t.Value != null)
                                            {
                                                t.Value.Image.Uuid = SerializationAdaptor.Images.AddIfNew(t.Value.Image);
                                                t.Value.Uuid = SerializationAdaptor.Textures.AddIfNew(t.Value);
                                            }

                                        }

                                    }

                                    m.Uuid = SerializationAdaptor.Materials.AddIfNew(m);

                                }

                            }

                            SerializationAdaptor.Object.Children.Add(group);
                            break;
                            */
                        default:
                            Debug.WriteLine((child as Element).Type, "ThreeLib");
                            break;
                    }
                }

                
            }
        }

        #endregion

    }

    internal class Object3DSerializationAdaptor : ObjectSerializationAdaptor, IElement
    {
        [JsonProperty("object", Order = 5)]
        internal Object3D Object { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal Object3DSerializationAdaptor()
        {
            Object = new Object3D();
            Metadata.Generator = "ThreeLib-Object3D.toJSON";
        }
    }

}
