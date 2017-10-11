using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{

    /// <summary>
    /// For creating layers.
    /// </summary>
    public class IrisLayer: IrisElement
    {
        /// <summary>
        /// Layer index when sorted.
        /// </summary>
        [JsonProperty("sortIndex")]
        public int SortIndex { get; set; }

        /// <summary>
        /// Full path to layer.
        /// </summary>
        [JsonProperty("fullPath")]
        public string FullPath { get; set; }

        /// <summary>
        /// Visibility flag.
        /// </summary>
        [JsonProperty("isVisible")]
        public bool IsVisible { get; set; }
    }

    /// <summary>
    /// For collecting layers.
    /// </summary>
    public class IrisLayerCollection : Collection<IrisLayer>
    {
        /// <summary>
        /// Add a new layer to the collection if it is unique.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisLayer item)
        {
            var q = from a in this
                    where a.Equals(item)
                    select a.Uuid;

            var enumerable = q as Guid[] ?? q.ToArray();
            if (!enumerable.Any())
            {
                Add(item);
                return item.Uuid;
            }
            else
            {
                return enumerable.Single();
            }
        }
    }


}