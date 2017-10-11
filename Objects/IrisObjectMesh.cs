using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace IrisLib
{
    /// <summary>
    /// For creating mesh objects. Analogous to:
    /// https://threejs.org/docs/index.html#api/objects/Mesh
    /// </summary>
    public class IrisObjectMesh : IrisElement
    {
        /// <summary>
        /// Object name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Object geometry.
        /// </summary>
        [JsonProperty("geometry")]
        public Guid Geometry { get; set; }

        /// <summary>
        /// Object material.
        /// </summary>
        [JsonProperty("material")]
        public Guid Material { get; set; }

        /// <summary>
        /// Cast shadow flag.
        /// </summary>
        [JsonProperty("castShadow")]
        public bool CastShadow { get; set; }

        /// <summary>
        /// Receive shadow flag.
        /// </summary>
        [JsonProperty("receiveShadow")]
        public bool ReceiveShadow { get; set; }

        /// <summary>
        /// Object user data.
        /// </summary>
        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; set; }

        /// <summary>
        /// Object orientation matrix.
        /// </summary>
        [JsonProperty("matrix")]
        public IList<float> Matrix { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IrisObjectMesh()
        {
            Type = "Mesh";
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="material"></param>
        /// <param name="name"></param>
        /// <param name="layer"></param>
        public IrisObjectMesh(Guid geometry, Guid material, string name, string layer) : this()
        {
            Name = name;
            Geometry = geometry;
            Material = material;
            CastShadow = true;
            ReceiveShadow = true;

            var ud = new Dictionary<string, Dictionary<string, object>>();
            var userDataScene = new Dictionary<string, object> { { "Layer", layer }, { "Selected", false }, { "BBoxId", null } };
            ud.Add("Scene", userDataScene);
            UserData = ud;

            Matrix = IrisData.Matrix;
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="material"></param>
        /// <param name="name"></param>
        /// <param name="layer"></param>
        /// <param name="userDataObject"></param>
        /// <param name="userDataAttributes"></param>
        public IrisObjectMesh(Guid geometry, Guid material, string name, string layer, NameValueCollection userDataObject, NameValueCollection userDataAttributes) : this()
        {
            Name = name;
            Geometry = geometry;
            Material = material;

            CastShadow = true;
            ReceiveShadow = true;

            var ud = new Dictionary<string, Dictionary<string, object>>();

            if (userDataObject.HasKeys())
                ud.Add("Object", PrepareUserData(userDataObject));
            if (userDataAttributes.HasKeys())
                ud.Add("Attribute", PrepareUserData(userDataAttributes));

            var userDataScene = new Dictionary<string, object> { { "Layer", layer }, { "Selected", false }, { "BBoxId", null } };
            ud.Add("Scene", userDataScene);
            UserData = ud;

            Matrix = IrisData.Matrix;
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="material"></param>
        /// <param name="name"></param>
        /// <param name="layer"></param>
        /// <param name="matrix"></param>
        public IrisObjectMesh(Guid geometry, Guid material, string name, string layer, float[] matrix) : this()
        {
            Name = name;
            Geometry = geometry;
            Material = material;

            var ud = new Dictionary<string, Dictionary<string, object>>();
            var userDataScene = new Dictionary<string, object> { { "Layer", layer }, { "Selected", false }, { "BBoxId", null } };
            ud.Add("Scene", userDataScene);
            UserData = ud;

            Matrix = matrix;
        }

    }

}
