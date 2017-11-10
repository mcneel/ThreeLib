## `SphereGeometry`

A class for generating sphere geometries.  Analagous to: https://threejs.org/docs/index.html#api/geometries/SphereGeometry  JS Source: https://github.com/mrdoob/three.js/blob/master/src/geometries/SphereGeometry.js
```csharp
public class THREE.Geometries.SphereGeometry
    : Geometry, IElement, IGeometry, IEquatable<Geometry>, IEquatable<SphereGeometry>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | HeightSegments | Number of vertical segments. Minimum value is 2. | 
| `Single` | PhiLength | Specify horizontal sweep angle size (in radians). | 
| `Single` | PhiStart | Specify horizontal starting angle (in radians). | 
| `Single` | Radius | Sphere radius. | 
| `Single` | ThetaLength | Specify vertical sweep angle size (in radians). | 
| `Single` | ThetaStart | Specify horizontal sweep angle size (in radians). | 
| `Int32` | WidthSegments | Number of horizontal segments. Minimum value is 3. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`SphereGeometry` other) | Check if this is equal to another geometry of this type. | 


