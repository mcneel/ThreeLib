using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace IrisLib
{
    /// <summary>
    /// For creating point objects. Analogous to Points:
    /// https://threejs.org/docs/index.html#api/objects/Points
    /// </summary>
    public class IrisObjectPoints : IrisElement
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
        /// Object material
        /// </summary>
        [JsonProperty("material")]
        public Guid Material { get; set; }

        /// <summary>
        /// User data attatched to the object.
        /// </summary>
        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; set; }

        /// <summary>
        /// Orientation matrix.
        /// </summary>
        [JsonProperty("matrix")]
        public IList<float> Matrix { get; set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        public IrisObjectPoints()
        {
            Type = "PointCloud";
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="material"></param>
        /// <param name="layer"></param>
        public IrisObjectPoints(Guid geometry, Guid material, string layer) : this()
        {
            Geometry = geometry;
            Material = material;

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
        /// <param name="layer"></param>
        /// <param name="userDataObject"></param>
        /// <param name="userDataAttributes"></param>
        public IrisObjectPoints(Guid geometry, Guid material, string layer, NameValueCollection userDataObject, NameValueCollection userDataAttributes) : this()
        {
            Geometry = geometry;
            Material = material;

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

    }

}
