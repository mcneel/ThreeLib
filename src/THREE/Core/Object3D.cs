using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using THREE.Geometries;
using THREE.Materials;
using THREE.Math;
using THREE.Objects;
using THREE.Serialization;
using THREE.Utility;

namespace THREE.Core
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
        public bool Visible { get; set; }

        /// <summary>
        /// Flag for determining if object casts shadow.
        /// </summary>
        public bool CastShadow { get; set; }

        /// <summary>
        /// Flag for determining if object receives shadow.
        /// </summary>
        public bool ReceiveShadow { get; set; }

        /// <summary>
        /// List with object's children.
        /// </summary>
        public List<IElement> Children { get; set; }

        [JsonIgnore]
        public Object3D Parent { get; set; }

        /// <summary>
        /// Object user data.
        /// </summary>
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
        public Euler Rotation
        { get; set; }

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
            if (obj!=null && obj.GetType().IsSubclassOf(typeof(Object3D)))
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

            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = format == true ? Formatting.Indented : Formatting.None,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCaseCustomResolver()
            };

            return JsonConvert.SerializeObject(SerializationAdaptor, serializerSettings);
        }

        internal void ProcessChildren(Object3D obj = null)
        {
            var children = new List<IElement>();

            if (obj == null)
                children = Children;
            else
            {
                children = obj.Children;

                if (obj is Group)
                    if (!(obj.Parent is Group) && obj.Parent.Parent == null)
                        SerializationAdaptor.Object.Children.Add(obj);
                else
                    if (obj.Parent.Parent == null)
                        SerializationAdaptor.Object.Children.Add(obj);
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
                        var geoId = Guid.Empty;
                        var currentGeo = child.GetType().GetProperty("Geometry").GetValue(child, null);

                        switch (currentGeo.GetType().Name)
                        {
                            case "BufferGeometry":
                                (currentGeo as BufferGeometry).Uuid = SerializationAdaptor.BufferGeometries.AddIfNew(currentGeo as BufferGeometry);
                                break;
                            case "Geometry":
                                (currentGeo as Geometry).Uuid = SerializationAdaptor.Geometries.AddIfNew(currentGeo as Geometry);
                                break;
                            case "SphereBufferGeometry":
                                (currentGeo as SphereBufferGeometry).Uuid = SerializationAdaptor.Geometries.AddIfNew(currentGeo as SphereBufferGeometry);
                                break;
                            case "TextBufferGeometry":
                                var font = SerializationAdaptor.Fonts.AddIfNew((currentGeo as TextBufferGeometry).Parameters.Font.FontData);

                                (currentGeo as TextBufferGeometry).Parameters.Font.Data = font;
                                (currentGeo as TextBufferGeometry).Uuid = SerializationAdaptor.Geometries.AddIfNew(currentGeo as TextBufferGeometry);
                                break;
                            default:
                                //other derivatives of Geometry
                                //geoId = SerializationAdaptor.Geometries.AddIfNew(currentGeo as Geometry);
                                break;
                        }
                        
                    }

                    if (child.GetType().GetProperty("Children").GetValue(child, null) is List<IElement> objChildren && objChildren.Count > 0)
                    {
                        ProcessChildren(child as Object3D);
                    }

                    switch ((child as Element).Type)
                    {
                        case "Mesh":

                            var mesh = child as Mesh;

                            dynamic material = new Material();

                            if (mesh.Material is MeshStandardMaterial)
                            {
                                material = mesh.Material as MeshStandardMaterial;

                            }
                            else if (mesh.Material is MeshBasicMaterial)
                            {
                                material = mesh.Material as MeshBasicMaterial;
                            }

                            foreach (var kvp in material.GetTextures())
                                if (kvp.Value != null)
                                {
                                    kvp.Value.Image.Uuid = SerializationAdaptor.Images.AddIfNew(kvp.Value.Image);
                                    kvp.Value.Uuid = SerializationAdaptor.Textures.AddIfNew(kvp.Value);
                                }
                            
                            material.Uuid = SerializationAdaptor.Materials.AddIfNew(material);

                            if(obj == null)
                                SerializationAdaptor.Object.Children.Add(mesh);

                            break;

                        case "Line":

                            var line = child as Line;
                            (line.Material as LineBasicMaterial).Uuid = SerializationAdaptor.Materials.AddIfNew(line.Material as LineBasicMaterial);

                            if (obj == null)
                                SerializationAdaptor.Object.Children.Add(line);

                            break;

                        case "Points":

                            var points = child as Points;
                            (points.Material as PointsMaterial).Uuid = SerializationAdaptor.Materials.AddIfNew(points.Material as PointsMaterial);

                            if (obj == null)
                                SerializationAdaptor.Object.Children.Add(points);

                            break;

                        case "PointLight":
                        case "AmbientLight":
                        case "SpotLight":
                        case "DirectionalLight":
                        case "RectAreaLight":
                        case "HemisphereLight":
                        case "PerspectiveCamera":
                        case "OrthographicCamera":
                            if (obj == null)
                                SerializationAdaptor.Object.Children.Add(child);
                            break;
                           
                        default:
                            Debug.WriteLine((child as Element).Type + "Not supported.", "ThreeLib");
                            break;
                    }
                }

                
            }

            SerializationAdaptor.Elements.AddRange(SerializationAdaptor.BufferGeometries);
            SerializationAdaptor.Elements.AddRange(SerializationAdaptor.Geometries);
        }

        #endregion

    }

    internal class Object3DSerializationAdaptor : ObjectSerializationAdaptor, IElement
    {
        [JsonProperty(Order = 5)]
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
