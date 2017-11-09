---
layout: default
---
## `AmbientLight`

This light globally illuminates all objects in the scene equally.  Analogous to: https://threejs.org/docs/index.html#api/lights/AmbientLight  Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/AmbientLight.js
```csharp
public class THREE.Lights.AmbientLight
    : Light, IElement, ILight

```

## `DirectionalLight`

A light that gets emitted in a specific direction.  Analogous to: https://threejs.org/docs/index.html#api/lights/DirectionalLight  Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/DirectionalLight.js
```csharp
public class THREE.Lights.DirectionalLight
    : Light, IElement, ILight

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `DirectionalLightShadow` | Shadow |  |
| `Object3D` | Target | The Spotlight points from its position to target.position. |


## `DirectionalLightShadow`

Analogous to: https://threejs.org/docs/index.html#api/lights/shadows/DirectionalLightShadow  Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/DirectionalLightShadow.js
```csharp
public class THREE.Lights.DirectionalLightShadow
    : LightShadow

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `OrthographicCamera` | Camera |  |


## `HemisphereLight`

A light source positioned directly above the scene, with color fading from the sky color to the ground color.  This light cannot be used to cast shadows.  Analogous to: https://threejs.org/docs/index.html#api/lights/HemisphereLight  Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/HemisphereLight.js
```csharp
public class THREE.Lights.HemisphereLight
    : Light, IElement, ILight

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `Int32` | GroundColor | Color of the ground. |
| `Int32` | SkyColor | Color of the sky. |


## `ILight`

Base interface for light objects.
```csharp
public interface THREE.Lights.ILight
    : IElement

```

## `Light`

Abstract base class for lights - all other light types inherit the properties and methods described here.  Analogous to: https://threejs.org/docs/index.html#api/lights/Light  Original source: https://github.com/mrdoob/three.js/blob/master/src/lights/Light.js
```csharp
public abstract class THREE.Lights.Light
    : Object3D, IElement, ILight

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `Int32` | Color | Light color. |
| `Single` | Intensity | Light intensity. |


## `LightShadow`

Analogous to: https://threejs.org/docs/index.html#api/lights/shadows/LightShadow  Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/LightShadow.js
```csharp
public class THREE.Lights.LightShadow

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `Single` | Bias | Shadow map bias, how much to add or subtract from the normalized depth when deciding whether a surface is in shadow. |
| `Camera` | Camera | The light's view of the world. |
| `Single` | Radius | Setting this to values greater than 1 will blur the edges of the shadow. |


## `PointLight`

A light that gets emitted from a single point in all directions. A common use case for this is to replicate the light emitted from a bare lightbulb.  Analogous to: https://threejs.org/docs/index.html#api/lights/PointLight  Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/PointLight.js
```csharp
public class THREE.Lights.PointLight
    : Light, IElement, ILight

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `Single` | Decay | Light decay. |
| `Single` | Distance | Light distance. |


## `RectAreaLight`

This light gets emitted uniformly across the face a rectangular plane. This can be used to simulate things like bright windows or strip lighting.  Analogous to: https://threejs.org/docs/index.html#api/lights/RectAreaLight  Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/RectAreaLight.js
```csharp
public class THREE.Lights.RectAreaLight
    : Light, IElement, ILight

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `Single` | Height | Height of the light. |
| `Single` | Width | Width of the light. |


## `SpotLight`

his light gets emitted from a single point in one direction, along a cone that increases in size the further from the light it gets.  Analogous to: https://threejs.org/docs/index.html#api/lights/SpotLight  Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/SpotLight.js
```csharp
public class THREE.Lights.SpotLight
    : Light, IElement, ILight

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `Single` | Angle | Maximum extent of the spotlight, in radians, from its direction. Should be no more than Math.PI/2. The default is Math.PI/3. |
| `Single` | Decay | The amount the light dims along the distance of the light. |
| `Single` | Distance | If non-zero, light will attenuate linearly from maximum intensity at the light's position down to zero at this distance from the light. |
| `Single` | Penumbra | Percent of the spotlight cone that is attenuated due to penumbra. Takes values between zero and 1. |
| `Single` | Power | The light's power. |
| `SpotLightShadow` | Shadow |  |
| `Object3D` | Target | The Spotlight points from its position to target.position. |


## `SpotLightShadow`

Analogous to: https://github.com/mrdoob/three.js/blob/master/src/lights/SpotLightShadow.js  Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/SpotLightShadow.js
```csharp
public class THREE.Lights.SpotLightShadow
    : LightShadow

```

Properties

| Type | Name | Summary |
| --- | --- | --- |
| `PerspectiveCamera` | Camera |  |
