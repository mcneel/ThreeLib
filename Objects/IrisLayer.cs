using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{
    public class IrisLayer: IrisElement
    {
        [JsonProperty("sortIndex")]
        public int SortIndex { get; set; }

        [JsonProperty("fullPath")]
        public string FullPath { get; set; }

        [JsonProperty("isVisible")]
        public bool IsVisible { get; set; }
    }

    public class IrisLayerCollection : Collection<IrisLayer>
    {
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