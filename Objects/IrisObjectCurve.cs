using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace IrisLib
{
    public class IrisObjectCurve : IrisElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("geometry")]
        public Guid Geometry { get; set; }

        [JsonProperty("material")]
        public Guid Material { get; set; }

        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; set; }

        [JsonProperty("matrix")]
        public IList<float> Matrix { get; set; }

        public IrisObjectCurve()
        {
            Type = "Line";
        }

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
