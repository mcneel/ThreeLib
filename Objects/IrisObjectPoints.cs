using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace IrisLib
{
    public class IrisObjectPoints : IrisElement
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("geometry")]
        public Guid Geometry { get; private set; }

        [JsonProperty("material")]
        public Guid Material { get; private set; }

        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; private set; }

        [JsonProperty("matrix")]
        public IList<float> Matrix { get; private set; }

        public IrisObjectPoints()
        {
            Type = "PointCloud";
        }

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
