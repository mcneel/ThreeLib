## `Color`

```csharp
public class THREE.Math.Color

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Byte` | B | Blue channel, 0-256. | 
| `Byte` | G | Green channel, 0-256. | 
| `Byte` | R | Red channel, 0-256. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | ToInt() | Convert color to 8-bit integer. | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | ToInt(`Byte` r, `Byte` g, `Byte` b) | Convert color to 8-bit integer. | 


## `Euler`

```csharp
public class THREE.Math.Euler

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `RotationOrders` | Order |  | 
| `Single` | X | The x value of the Euler. | 
| `Single` | Y | The y value of the Euler. | 
| `Single` | Z | The z value of the Euler. | 


## `Matrix4`

A class representing a 4x4 matrix.  Analogous to: https://threejs.org/docs/index.html#api/math/Matrix4  JS Source: https://github.com/mrdoob/three.js/blob/master/src/math/Matrix4.js
```csharp
public class THREE.Math.Matrix4

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single[]` | Elements | A column-major list of matrix values. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Compose(`Vector3` position, `Quaternion` quaternion, `Vector3` scale) |  | 
| `Vector3` | GetPosition() |  | 
| `void` | MakeRotationFromQuaternion(`Quaternion` q) |  | 
| `void` | Scale(`Vector3` v) |  | 
| `void` | SetPosition(`Vector3` vector) |  | 
| `Single[]` | ToArray() |  | 
| `IEnumerable<Object>` | ToObjectList() |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Matrix4` | Identity() |  | 


## `Quaternion`

```csharp
public class THREE.Math.Quaternion

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | W | The z value of the Quaternion. | 
| `Single` | X | The x value of the Quaternion. | 
| `Single` | Y | The y value of the Quaternion. | 
| `Single` | Z | The z value of the Quaternion. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | SetFromEuler(`Euler` euler) |  | 


## `Vector3`

Class representing a 3D vector.  Analogous to: https://threejs.org/docs/index.html#api/math/Vector3  JS Source: https://github.com/mrdoob/three.js/blob/master/src/math/Vector3.js
```csharp
public class THREE.Math.Vector3

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | X | The x value of the vector. | 
| `Single` | Y | The y value of the vector. | 
| `Single` | Z | The z value of the vector. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single[]` | ToArray() | An array representation of this vector. | 


