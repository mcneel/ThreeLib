namespace THREE
{
    /// <summary>
    /// Basic file metadata
    /// </summary>
    /// <remarks>
    /// This is used by scene and camera objects to define which format they are written in. 
    /// </remarks>
    public class Metadata
    {
        /// <summary>
        /// File version.
        /// </summary>
        public double Version { get; set; }

        /// <summary>
        /// File type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The application which generated this data.
        /// </summary>
        public string Generator { get; set; }
    }
}
