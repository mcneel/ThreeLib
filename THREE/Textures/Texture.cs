using Newtonsoft.Json;
using System;

namespace IrisLib
{

    public class Texture
    {
        /// <summary>
        /// Object Id.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Image associated with this texture.
        /// </summary>
        [JsonIgnore]
        public Image Image { get; set; }

        /// <summary>
        /// URL of the image.
        /// </summary>
        [JsonProperty("image")]
        public Guid? ImageUuid
        {
            get
            {
                if (Image != null)
                    return Image.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Texture mapping.
        /// </summary>
        [JsonProperty("mapping")]
        public int Mapping { get; set; }

        /// <summary>
        /// Texture wrapping.
        /// </summary>
        [JsonProperty("wrap")]
        public int[] Wrap { get; set; }

        /// <summary>
        /// Texture repetition.
        /// </summary>
        [JsonProperty("repeat")]
        public double[] Repeat { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Texture()
        {
            Uuid = Guid.NewGuid();
        }

    }
    
}
