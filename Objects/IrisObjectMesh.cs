using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace IrisLib
{
    public class IrisObjectMesh : IrisElement
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("geometry")]
        public Guid Geometry { get; private set; }

        [JsonProperty("material")]
        public Guid Material { get; set; }

        [JsonProperty("castShadow")]
        public bool CastShadow { get; private set; }

        [JsonProperty("receiveShadow")]
        public bool ReceiveShadow { get; private set; }

        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; private set; }

        [JsonProperty("matrix")]
        public IList<float> Matrix { get; private set; }

        public IrisObjectMesh()
        {
            Type = "Mesh";
        }

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
