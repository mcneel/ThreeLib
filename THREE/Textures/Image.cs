using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Image url.
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
        /// Constructor.
        /// </summary>
        /// <param name="path"></param>
        public Image(string path) : this()
        {
            OriginalPath = path;
            //Url = "/img/" + Path.GetFileName(path);
            Url = GetDataURL(path);
        }

        /// <summary>
        /// Encode image to base64.
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
