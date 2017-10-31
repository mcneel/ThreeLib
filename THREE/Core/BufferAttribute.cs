using Newtonsoft.Json;
using System;

namespace ThreeLib
{
    public class BufferAttribute
    {
        [JsonProperty("uuid")]
        public Guid Uuid { get; private set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("itemSize")]
        int ItemSize { get; set; }

        [JsonProperty("count")]
        public int Count { get; private set; }

        [JsonProperty("normalized")]
        bool Normalized { get; set; }

        [JsonProperty("dynamic")]
        bool Dynamic { get; set; }

        [JsonProperty("array")]
        public object[] Array { get; set; }

        public BufferAttribute()
        {
            Uuid = Guid.NewGuid();
        }

        public BufferAttribute(object[] array, int itemSize, bool normalized) : this()
        {
            ItemSize = itemSize;
            Array = array;
            Count = Array != null ? Array.Length / ItemSize : 0;
            Normalized = normalized;
            Dynamic = false;
        }
    }
}
