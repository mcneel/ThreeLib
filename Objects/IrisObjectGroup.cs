using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// For creating groups of objects. Analogous to:
    /// https://threejs.org/docs/index.html#api/objects/Group
    /// </summary>
	public class IrisObjectGroup : IrisElement
	{
        /// <summary>
        /// Object name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// List of objects belonging to this group.
        /// </summary>
        [JsonProperty("children")]
        public List<IIrisElement> Children { get; set; }

        /// <summary>
        /// Object user data.
        /// </summary>
        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; set; }

        /// <summary>
        /// Object orientation.
        /// </summary>
        [JsonProperty("matrix")]
        public IList<float> Matrix { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IrisObjectGroup()
        {
            Type = "Group";
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="children"></param>
        public IrisObjectGroup(List<IIrisElement> children) : this()
        {
            Children = children;

            var ud = new Dictionary<string, Dictionary<string, object>>();
            var userDataScene = new Dictionary<string, object> { { "Selected", false }, { "BBoxId", null } };
            ud.Add("Scene", userDataScene);
            UserData = ud;
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="layer"></param>
        public IrisObjectGroup(string layer): this()
        {
            var ud = new Dictionary<string, Dictionary<string, object>>();
            var userDataScene = new Dictionary<string, object> { { "Layer", layer }, { "Selected", false }, { "BBoxId", null } };
            ud.Add("Scene", userDataScene);
            UserData = ud;
        }

	}
}