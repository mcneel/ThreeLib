using Newtonsoft.Json;
using System;

namespace IrisLib
{

    /// <summary>
    /// Class for creating text objects.
    /// </summary>
    public class IrisGeometryText : IrisElement
    {
        /// <summary>
        /// The text which this object displays.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; private set; }

        /// <summary>
        /// Test / Font parameters.
        /// </summary>
        [JsonProperty("parameters")]
        public IrisTextGeometryData Data { get; set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        public IrisGeometryText()
        {
            Type = "TextGeometry";
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="data"></param>
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

    /// <summary>
    /// Attributes for the text object.
    /// </summary>
    public class IrisTextGeometryData
    {
        /// <summary>
        /// Size of the text.
        /// </summary>
        [JsonProperty("size")]
        public double Size { get; set; }

        /// <summary>
        /// Height of the text.
        /// </summary>
        [JsonProperty("height", DefaultValueHandling = DefaultValueHandling.Include)]
        public float Height { get; set; }

        /// <summary>
        /// The glyphs which this text includes.
        /// </summary>
        [JsonProperty("glyphs")]
        public Guid Glyphs { get; set; }

    }
}
