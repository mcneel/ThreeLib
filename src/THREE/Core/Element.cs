using System;

namespace THREE.Core
{

    public interface IElement { }

    /// <summary>
    /// Base class for objects which have a Uuid, Name, and Type.
    /// </summary>
    public class Element : IElement, IEquatable<Element>
    {
        /// <summary>
        /// Unique Guid.
        /// </summary>
        public Guid Uuid { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of object.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Element()
        {
            Uuid = Guid.NewGuid();
            Type = GetType().Name;
        }

        public bool Equals(Element other)
        {
            if (other.GetType() == typeof(Element)) return base.Equals(other);
            else return false;
        }
    }
}
