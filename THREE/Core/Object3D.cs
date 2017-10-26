using Newtonsoft.Json;
using System.Collections.Generic;

namespace IrisLib
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
        public bool Visible = true;

        /// <summary>
        /// Flag for determining if object casts shadow.
        /// </summary>
        [JsonProperty("castShadow")]
        public bool CastShadow = false;

        /// <summary>
        /// Flag for determining if object receives shadow.
        /// </summary>
        [JsonProperty("receiveShadow")]
        public bool ReceiveShadow = false;

        /// <summary>
        /// List with object's children.
        /// </summary>
        [JsonProperty("children")]
        public List<IElement> Children { get; set; }

        /// <summary>
        /// Object user data.
        /// </summary>
        [JsonProperty("userData")]
        public List<Dictionary<string, object>> UserData { get; set; }

        /// <summary>
        /// Object matrix.
        /// </summary>
        [JsonIgnore]
        public Matrix4 Matrix { get; set; }

        [JsonProperty("matrix")]
        public float[] MatrixArray { get { return Matrix.ToArray(); } }

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

        #endregion

#region Constructors

        /// <summary>
        /// Default constructor. Results in an empty Object3D with new Uuid.
        /// </summary>
        public Object3D()
        {
            Type = "Object3D";
            Children = new List<IElement>();
            Matrix = Matrix4.Identity();
            Position = new Vector3();
            Rotation = new Euler();
            Quaternion = new Quaternion();
            Scale = new Vector3 { X = 1, Y = 1, Z = 1 };
            
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
            return (Children.Count > 0);
        }

        /// <summary>
        /// Adds an object as a child of this object.
        /// </summary>
        /// <param name="obj"></param>
        public void Add(IElement obj)
        {
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
        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
        
        #endregion

    }
    
}
