using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace IrisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class IrisObjectCurve : IrisElement
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
        public IrisObjectCurve()
        {
            Type = "Line";
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="material"></param>
        /// <param name="layer"></param>
        /// <param name="userDataObject"></param>
        /// <param name="userDataAttributes"></param>
        public IrisObjectCurve(Guid geometry, Guid material, string layer, NameValueCollection userDataObject, NameValueCollection userDataAttributes) : this()
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
