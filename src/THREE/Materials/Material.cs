using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using THREE.Core;

namespace THREE.Materials
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMaterial { }

    /// <summary>
    /// 
    /// </summary>
    public class Material: Element, IMaterial, IEquatable<Material>
    {

        #region Properties
        /// <summary>
        /// Sets the alpha value to be used when running an alpha test. The material will not be renderered if the opacity is lower than this value.
        /// </summary>
        public float AlphaTest { get; set; }

        /// <summary>
        /// Changes the behavior of clipping planes so that only their intersection is clipped, rather than their union. 
        /// </summary>
        public bool ClipIntersections { get; set; }

        /// <summary>
        /// User-defined clipping planes specified as THREE.Plane objects in world space. These planes apply to the objects this material is attached to. Points in space whose signed distance to the plane is negative are clipped (not rendered).
        /// </summary>
        public List<object> ClippingPlanes { get; set; }

        /// <summary>
        /// Defines whether to clip shadows according to the clipping planes specified on this material. 
        /// </summary>
        public bool ClipShadows { get; set; }

        /// <summary>
        /// Whether to render the material's color. This can be used in conjunction with a mesh's 
        /// renderOrder property to create invisible objects that occlude other objects. 
        /// </summary>
        public bool ColorWrite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool DepthTest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool DepthWrite { get; set; }

        /// <summary>
        /// Whether to apply dithering to the color to remove the appearance of banding.
        /// </summary>
        public bool Dithering { get; set; }

        /// <summary>
        /// Whether the material is affected by fog. Default is true.
        /// </summary>
        public bool Fog { get; set; }

        /// <summary>
        /// Whether the material is affected by lights. Default is true.
        /// </summary>
        public bool Lights { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FlatShading { get; set; }

        /// <summary>
        /// Defines whether this material is transparent. This has an effect on rendering as transparent objects need special treatment and are rendered after non-transparent objects.
        /// When set to true, the extent to which the material is transparent is controlled by setting it's opacity property. Default is false.
        /// </summary>
        public bool Transparent { get; set; }

        /// <summary>
        /// Defines whether this material is visible. Default is true.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Which blending to use when displaying objects with this material.
        /// </summary>
        public int Blending { get; set; }

        /// <summary>
        /// Defines whether vertex coloring is used.
        /// </summary>
        public VertexColors VertexColors { get; set; }

        /// <summary>
        /// Defines which side of faces will be rendered - front, back or both.
        /// </summary>
        public int Side { get; set; }

        /// <summary>
        /// Float in the range of 0.0 - 1.0 indicating how transparent the material is. A value of 0.0 indicates fully transparent, 1.0 is fully opaque.
        /// If the material's transparent property is not set to true, the material will remain fully opaque and this value will only affect its color. 
        /// </summary>
        public float Opacity { get; set; }

        /// <summary>
        /// Amount of triangle expansion at draw time. This is a workaround for cases when gaps appear between triangles when using CanvasRenderer. 0.5 tends to give good results across browsers.
        /// </summary>
        public float Overdraw { get; set; }

        /// <summary>
        /// Override the renderer's default precision for this material. Can be "highp", "mediump" or "lowp".
        /// </summary>
        public string Precision { get; set; }

        /// <summary>
        /// Whether to premultiply the alpha (transparency) value.
        /// </summary>
        public bool PremultipliedAlpha { get; set; }

        /// <summary>
        /// An object that can be used to store custom data about the Material.
        /// </summary>
        public Dictionary<string, Dictionary<string, object>> UserData { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(Material other)
        {
            if (other == null) return false;
            return AlphaTest.Equals(other.AlphaTest) &&
                   Blending.Equals(other.Blending) &&
                   ClipIntersections.Equals(other.ClipIntersections) &&
                   ClipShadows.Equals(other.ClipShadows) &&
                   ColorWrite.Equals(other.ColorWrite) &&
                   DepthTest.Equals(other.DepthTest) &&
                   DepthWrite.Equals(other.DepthWrite) &&
                   Dithering.Equals(other.Dithering) &&
                   FlatShading.Equals(other.FlatShading) &&
                   Fog.Equals(other.Fog) &&
                   Lights.Equals(other.Lights) &&
                   Opacity.Equals(other.Opacity) &&
                   Overdraw.Equals(other.Overdraw) &&
                   PremultipliedAlpha.Equals(other.PremultipliedAlpha) &&
                   Side.Equals(other.Side) &&
                   Transparent.Equals(other.Transparent) &&
                   VertexColors.Equals(other.VertexColors) &&
                   Visible.Equals(other.Visible) &&
                   UserData == other.UserData &&
                   ClippingPlanes == other.ClippingPlanes &&
                   string.Equals(Precision, other.Precision);
        }

        #endregion

    }

    /// <summary>
    /// 
    /// </summary>
    public class MaterialCollection: Collection<Material>
    {
        /// <summary>
        /// Add a geometry to this collection if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(Material item)
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
