using Newtonsoft.Json;
using System;

namespace IrisLib
{
    public class IrisGeometryText : IrisElement
    {
        [JsonProperty("text")]
        public string Text { get; private set; }

        [JsonProperty("parameters")]
        public IrisTextGeometryData Data { get; set; }

        public IrisGeometryText()
        {
            Type = "TextGeometry";
        }

        public IrisGeometryText(string text, IrisTextGeometryData data) : this()
        {
            Text = text;
            Data = new IrisTextGeometryData
            {
                Size = 1,
                Height = 0
            };
        }

    }

    public class IrisTextGeometryData
    {
        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("height", DefaultValueHandling = DefaultValueHandling.Include)]
        public float Height { get; set; }

        [JsonProperty("glyphs")]
        public Guid Glyphs { get; set; }

    }
}
