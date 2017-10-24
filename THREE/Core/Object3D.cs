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
        [JsonProperty("matrix")]
        public IList<float> Matrix { get; set; }

        #endregion

#region Constructors

        /// <summary>
        /// Default constructor. Results in an empty Object3D with new Uuid.
        /// </summary>
        public Object3D()
        {
            Type = "Object3D";
            Children = new List<IElement>();
            Matrix = new float[]{ 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
        }

        #endregion

#region Methods

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
