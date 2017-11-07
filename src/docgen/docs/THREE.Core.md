## `BufferAttribute`

```csharp
public class THREE.Core.BufferAttribute

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object[]` | Array |  | 
| `Int32` | Count |  | 
| `String` | Name |  | 
| `Guid` | Uuid |  | 


## `BufferGeometry`

```csharp
public class THREE.Core.BufferGeometry
    : IGeometry

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<BufferAttribute>` | Attributes |  | 
| `BufferGeometryBoundingSphere` | BoundingSphere |  | 
| `String` | Name |  | 
| `String` | Type |  | 
| `Guid` | Uuid |  | 


## `BufferGeometryBoundingSphere`

Data for the bounding sphere.
```csharp
public class THREE.Core.BufferGeometryBoundingSphere

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single[]` | Center | Center position of the bounding sphere. | 
| `Single` | Radius | Radius of the bounding sphere. | 


## `Element`

Base class for objects which have a Uuid, Name, and Type.
```csharp
public class THREE.Core.Element
    : IElement

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name | Name. | 
| `String` | Type | Type of object. | 
| `Guid` | Uuid | Unique Guid. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | SetUuid(`Guid` uuid) |  | 


## `Geometry`

Base class for all geometries.  Analogous to https://threejs.org/docs/index.html#api/core/Geometry  Design based on need for Three.js Loaders.
```csharp
public class THREE.Core.Geometry
    : Object3D, IElement, IGeometry, IEquatable<Geometry>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<Int32>` | Colors |  | 
| `List<Int32>` | Faces |  | 
| `List<Single>` | Normals |  | 
| `List<List<Single>>` | Uvs | The list of UVs associated with this geometry. | 
| `List<Single>` | Vertices |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`Geometry` other) | Check if one Geometry equals another.  TODO: Check if base.Equals(other)? Object3D would need to be IEquatable. | 
| `Boolean` | Equals(`Object` other) | Check if one Geometry equals another.  TODO: Check if base.Equals(other)? Object3D would need to be IEquatable. | 
| `Int32` | GetHashCode() |  | 
| `Boolean` | ShouldSerializeData() |  | 
| `String` | ToJSON(`Boolean` format) |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<Int32>` | ProcessFaceArray(`List<Int32[]>` faces, `Boolean` vertexColors, `Boolean` uvs) | Utility method for processing faces.  TODO: Extend for all types of faces and switches. | 
| `List<Single>` | ProcessNormalArray(`List<Single[]>` normals) |  | 
| `List<Single>` | ProcessVertexArray(`List<Single[]>` vertices) |  | 


## `GeometryCollection`

```csharp
public class THREE.Core.GeometryCollection
    : Collection<Geometry>, IList<Geometry>, ICollection<Geometry>, IEnumerable<Geometry>, IEnumerable, IList, ICollection, IReadOnlyList<Geometry>, IReadOnlyCollection<Geometry>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Guid` | AddIfNew(`Geometry` item) | Add a geometry to this collection if it does not already exist. | 


## `IElement`

```csharp
public interface THREE.Core.IElement

```

## `IGeometry`

```csharp
public interface THREE.Core.IGeometry

```

## `Object3D`

Base class for all objects. Analogous to https://threejs.org/docs/index.html#api/core/Object3D
```csharp
public class THREE.Core.Object3D
    : Element, IElement

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | CastShadow | Flag for determining if object casts shadow. | 
| `List<IElement>` | Children | List with object's children. | 
| `Matrix4` | Matrix | Object matrix. | 
| `IEnumerable<Object>` | MatrixArray |  | 
| `Object3D` | Parent |  | 
| `Vector3` | Position | The object's local position. | 
| `Quaternion` | Quaternion |  | 
| `Boolean` | ReceiveShadow | Flag for determining if object receives shadow. | 
| `Euler` | Rotation |  | 
| `Vector3` | Scale |  | 
| `Object3DSerializationAdaptor` | SerializationAdaptor |  | 
| `Dictionary<String, Dictionary<String, Object>>` | UserData | Object user data. | 
| `Boolean` | Visible | Object visibility. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Add(`IElement` obj) | Adds an object as a child of this object. | 
| `void` | AddRange(`List<IElement>` objs) | Adds a list of objects as children of this object. | 
| `void` | ProcessChildren(`Group` group = null) |  | 
| `Boolean` | ShouldSerializeChildren() |  | 
| `String` | ToJSON(`Boolean` format) | Convert the object to JSON format. | 
| `void` | UpdateMatrix() |  | 


