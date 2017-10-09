using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{
	public class IrisObjectGroup : IrisElement
	{
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("children")]
        public List<IIrisElement> Children { get; set; }

        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; private set; }

        [JsonProperty("matrix")]
        public IList<float> Matrix { get; set; }

        public IrisObjectGroup()
        {
            Type = "Group";
        }

        public IrisObjectGroup(List<IIrisElement> children) : this()
        {
            Children = children;

            var ud = new Dictionary<string, Dictionary<string, object>>();
            var userDataScene = new Dictionary<string, object> { { "Selected", false }, { "BBoxId", null } };
            ud.Add("Scene", userDataScene);
            UserData = ud;
        }

        public IrisObjectGroup(string layer): this()
        {
            var ud = new Dictionary<string, Dictionary<string, object>>();
            var userDataScene = new Dictionary<string, object> { { "Layer", layer }, { "Selected", false }, { "BBoxId", null } };
            ud.Add("Scene", userDataScene);
            UserData = ud;
        }

	}
}