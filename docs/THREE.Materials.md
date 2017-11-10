## `IMaterial`

```csharp
public interface THREE.Materials.IMaterial

```

## `LineBasicMaterial`

```csharp
public class THREE.Materials.LineBasicMaterial
    : Material, IElement, IMaterial, IEquatable<Material>, IEquatable<LineBasicMaterial>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | Color | The material color. | 
| `String` | LineCap |  | 
| `String` | LineJoin |  | 
| `Single` | LineWidth | The curve linewidth. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`LineBasicMaterial` other) |  | 
| `Boolean` | Equals(`Material` other) |  | 


## `Material`

```csharp
public class THREE.Materials.Material
    : Element, IElement, IMaterial, IEquatable<Material>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | AlphaTest | Sets the alpha value to be used when running an alpha test. The material will not be renderered if the opacity is lower than this value. | 
| `Int32` | Blending | Which blending to use when displaying objects with this material. | 
| `Boolean` | ClipIntersections | Changes the behavior of clipping planes so that only their intersection is clipped, rather than their union. | 
| `List<Object>` | ClippingPlanes | User-defined clipping planes specified as THREE.Plane objects in world space. These planes apply to the objects this material is attached to. Points in space whose signed distance to the plane is negative are clipped (not rendered). | 
| `Boolean` | ClipShadows | Defines whether to clip shadows according to the clipping planes specified on this material. | 
| `Boolean` | ColorWrite | Whether to render the material's color. This can be used in conjunction with a mesh's  renderOrder property to create invisible objects that occlude other objects. | 
| `Boolean` | DepthTest |  | 
| `Boolean` | DepthWrite |  | 
| `Boolean` | Dithering | Whether to apply dithering to the color to remove the appearance of banding. | 
| `Boolean` | FlatShading |  | 
| `Boolean` | Fog | Whether the material is affected by fog. Default is true. | 
| `Boolean` | Lights | Whether the material is affected by lights. Default is true. | 
| `Single` | Opacity | Float in the range of 0.0 - 1.0 indicating how transparent the material is. A value of 0.0 indicates fully transparent, 1.0 is fully opaque.  If the material's transparent property is not set to true, the material will remain fully opaque and this value will only affect its color. | 
| `Single` | Overdraw | Amount of triangle expansion at draw time. This is a workaround for cases when gaps appear between triangles when using CanvasRenderer. 0.5 tends to give good results across browsers. | 
| `String` | Precision | Override the renderer's default precision for this material. Can be "highp", "mediump" or "lowp". | 
| `Boolean` | PremultipliedAlpha | Whether to premultiply the alpha (transparency) value. | 
| `Int32` | Side | Defines which side of faces will be rendered - front, back or both. | 
| `Boolean` | Transparent | Defines whether this material is transparent. This has an effect on rendering as transparent objects need special treatment and are rendered after non-transparent objects.  When set to true, the extent to which the material is transparent is controlled by setting it's opacity property. Default is false. | 
| `Dictionary<String, Dictionary<String, Object>>` | UserData | An object that can be used to store custom data about the Material. | 
| `Int32` | VertexColors | Defines whether vertex coloring is used. | 
| `Boolean` | Visible | Defines whether this material is visible. Default is true. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`Material` other) |  | 


## `MaterialCollection`

```csharp
public class THREE.Materials.MaterialCollection
    : Collection<Material>, IList<Material>, ICollection<Material>, IEnumerable<Material>, IEnumerable, IList, ICollection, IReadOnlyList<Material>, IReadOnlyCollection<Material>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Guid` | AddIfNew(`Material` item) | Add a geometry to this collection if it does not already exist. | 


## `MeshBasicMaterial`

```csharp
public class THREE.Materials.MeshBasicMaterial
    : Material, IElement, IMaterial, IEquatable<Material>, IEquatable<MeshBasicMaterial>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Texture` | AlphaMap | Material alpha map. | 
| `Nullable<Guid>` | AlphaMapUuid | AlphaMap Uuid. | 
| `Texture` | AoMap | Material ao map. | 
| `Nullable<Guid>` | AoMapUuid | ao Uuid. | 
| `Texture` | EnvironmentMap | Material environment map. | 
| `Nullable<Guid>` | EnvironmentMapUuid | Environment map Uuid. | 
| `Texture` | LightMap |  | 
| `Nullable<Guid>` | LightMapUuid | Light map Uuid. | 
| `Texture` | Map | Material diffuse map. | 
| `Nullable<Guid>` | MapUuid | The Uuid of the diffuse map. | 
| `Texture` | SpecularMap |  | 
| `Nullable<Guid>` | SpecularMapUuid | Specular map Uuid. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`MeshBasicMaterial` other) |  | 
| `Boolean` | Equals(`Material` other) |  | 


## `MeshLambertMaterial`

```csharp
public class THREE.Materials.MeshLambertMaterial
    : Material, IElement, IMaterial, IEquatable<Material>, IEquatable<MeshLambertMaterial>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Texture` | AlphaMap | Material alpha map. | 
| `Nullable<Guid>` | AlphaMapUuid | AlphaMap Uuid. | 
| `Texture` | BumpMap | Material bump map. | 
| `Nullable<Guid>` | BumpMapUuid | BumpMap Uuid. | 
| `Texture` | EnvironmentMap | Material environment map. | 
| `Nullable<Guid>` | EnvironmentMapUuid | Environment map Uuid. | 
| `Texture` | Map | Material diffuse map. | 
| `Nullable<Guid>` | MapUuid | The Uuid of the diffuse map. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`MeshLambertMaterial` other) |  | 
| `Boolean` | Equals(`Material` other) |  | 


## `MeshPhongMaterial`

```csharp
public class THREE.Materials.MeshPhongMaterial
    : Material, IElement, IMaterial, IEquatable<Material>, IEquatable<MeshPhongMaterial>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Texture` | AlphaMap | Material alpha map. | 
| `Nullable<Guid>` | AlphaMapUuid | AlphaMap Uuid. | 
| `Texture` | BumpMap | Material bump map. | 
| `Nullable<Guid>` | BumpMapUuid | BumpMap Uuid. | 
| `Texture` | EnvironmentMap | Material environment map. | 
| `Nullable<Guid>` | EnvironmentMapUuid | Environment map Uuid. | 
| `Texture` | Map | Material diffuse map. | 
| `Nullable<Guid>` | MapUuid | The Uuid of the diffuse map. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`MeshPhongMaterial` other) |  | 
| `Boolean` | Equals(`Material` other) |  | 


## `MeshStandardMaterial`

Analogous to: https://github.com/mrdoob/three.js/blob/dev/src/materials/MeshStandardMaterial.js  TODO: Add roughness and metalness maps.
```csharp
public class THREE.Materials.MeshStandardMaterial
    : Material, IElement, IMaterial, IEquatable<Material>, IEquatable<MeshStandardMaterial>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Texture` | AlphaMap | Material alpha map. | 
| `Nullable<Guid>` | AlphaMapUuid | AlphaMap Uuid. | 
| `Int32` | Ambient | Material ambient color. | 
| `Texture` | AoMap | Material ao map. | 
| `Nullable<Guid>` | AoMapUuid | ao Uuid. | 
| `Texture` | BumpMap | Material bump map. | 
| `Nullable<Guid>` | BumpMapUuid | BumpMap Uuid. | 
| `Int32` | Color | Material diffuse color. | 
| `Texture` | DisplacementMap | The displacement map affects the position of the mesh's vertices. Unlike other maps which only affect the light and shade of the material the displaced vertices can cast shadows, block other objects, and otherwise act as real geometry. The displacement texture is an image where the value of each pixel (white being the highest) is mapped against, and repositions, the vertices of the mesh. | 
| `Nullable<Guid>` | DisplacementMapUuid | Displacement map Uuid. | 
| `Int32` | Emissive | Material emissive color. | 
| `Texture` | EmissiveMap | Set emisssive (glow) map. The emissive map color is modulated by the emissive color and the emissive intensity. If you have an emissive map, be sure to set the emissive color to something other than black. | 
| `Nullable<Guid>` | EmissiveMapUuid | Emissive map Uuid. | 
| `Texture` | EnvironmentMap | Material environment map. | 
| `Nullable<Guid>` | EnvironmentMapUuid | Environment map Uuid. | 
| `Texture` | LightMap |  | 
| `Nullable<Guid>` | LightMapUuid | Light map Uuid. | 
| `Texture` | Map | Material diffuse map. | 
| `Nullable<Guid>` | MapUuid | The Uuid of the diffuse map. | 
| `Double` | Metalness | Material metalness. | 
| `Texture` | MetalnessMap | Material metalness map. | 
| `Nullable<Guid>` | MetalnessMapUuid | The Uuid of the metalness map. | 
| `Texture` | NormalMap | Material normal map. | 
| `Nullable<Guid>` | NormalMapUuid | The Uuid of the normal map. | 
| `Double` | Roughness | Material roughness. | 
| `Texture` | RoughnessMap | Material roughness map. | 
| `Nullable<Guid>` | RoughnessMapUuid | The Uuid of the roughness map. | 
| `Dictionary<String, Texture>` | Textures |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`MeshStandardMaterial` other) | Test to see if this material is equal to another. | 
| `Boolean` | Equals(`Material` other) | Test to see if this material is equal to another. | 
| `Dictionary<String, Texture>` | GetTextures() | Returns material textures as a dictionary. | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `MeshStandardMaterial` | Default() | Creates a MeshStandardMaterial with some default settings. | 


## `PointsMaterial`

Analogous to https://github.com/mrdoob/three.js/blob/master/src/materials/PointsMaterial.js
```csharp
public class THREE.Materials.PointsMaterial
    : Material, IElement, IMaterial, IEquatable<Material>, IEquatable<PointsMaterial>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | Color | Material color. | 
| `Texture` | Map | The diffuse map texture. | 
| `Nullable<Guid>` | MapUuid | Material diffuse color map. | 
| `Double` | Size | Point size. | 
| `Boolean` | SizeAttenuation | Size attenuation flag. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`PointsMaterial` other) |  | 
| `Boolean` | Equals(`Material` other) |  | 


