using Newtonsoft.Json;
using System;
using System.IO;

namespace IrisLib
{
    public class Image
    {

        /// <summary>
        /// Object Id.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Image url. This can be the path to the image resource (.jpg, .png, etc), or a base64 encoded asset.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Image path.
        /// </summary>
        [JsonIgnore]
        public string OriginalPath { get; set; }

        /// <summary>
        /// Image exists flag.
        /// </summary>
        [JsonIgnore]
        public bool Exists { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Image()
        {
            Uuid = Guid.NewGuid();
        }

        /// <summary>
        /// Encode image to base64.
        /// TODO: consider removing this to the example application.
        /// </summary>
        /// <param name="imgFile"></param>
        /// <returns></returns>
        public static string GetDataURL(string imgFile)
        {
            return "data:image/"
                        + Path.GetExtension(imgFile).Replace(".", "")
                        + ";base64,"
                        + Convert.ToBase64String(File.ReadAllBytes(imgFile));
        }
    }
}
