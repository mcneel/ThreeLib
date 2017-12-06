using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        //public bool Equals(Element other)
        //{
        //    if (other.GetType() == typeof(Element)) return base.Equals(other);
        //    else return false;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Element other)
        {
            if (other == null) return false;
            else
                return Name.Equals(other.Name) &&
                       Type.Equals(other.Type);
        }
    }

    public class ElementCollection : Collection<Element>
    {

        public void AddRange(IEnumerable<Element> elements)
        {
            foreach (var element in elements)
                Add(element);
        }

        /// <summary>
        /// Add a geometry to this collection if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(Element item)
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
