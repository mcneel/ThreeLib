---
layout: default
---
## `Metadata`

Basic file metadata
```csharp
public class THREE.Metadata

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `String` | Generator | The application which generated this data. |
| `String` | Type | File type. |
| `Double` | Version | File version. |


## `Scene`

Scenes allow you to set up what and where is to be rendered by three.js. This is where you place objects, lights and cameras.  Analogous to https://threejs.org/docs/index.html#api/scenes/Scene
```csharp
public class THREE.Scene
    : Object3D, IElement

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `Int32` | Background | Background color for the scene. |
| `SceneSerializationAdaptor` | SerializationAdaptor |  |


Methods

| Type | Name | Summary |
| --- | --- | --- |
| `String` | ToJSON(`Boolean` format) | Converts this Scene to a compatible JSON format. |
