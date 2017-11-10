## `Camera`

Abstract base class for cameras. This class should always be inherited when you build a new camera.  Analogous to: https://threejs.org/docs/index.html#api/cameras/Camera  Original Source: https://github.com/mrdoob/three.js/blob/master/src/cameras/Camera.js
```csharp
public abstract class THREE.Cameras.Camera
    : Object3D, IElement

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Matrix4` | MatrixWorldInverse |  | 
| `Matrix4` | ProjectionMatrix |  | 


## `OrthographicCamera`

Camera that uses orthographic projection.  In this projection mode, an object's size in the rendered image stays constant regardless of its distance from the camera.  This can be useful for rendering 2D scenes and UI elements, amongst other things.  Analogous to: https://threejs.org/docs/index.html#api/cameras/OrthographicCamera  JS Source: https://github.com/mrdoob/three.js/blob/master/src/cameras/OrthographicCamera.js
```csharp
public class THREE.Cameras.OrthographicCamera
    : Camera, IElement

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | Bottom | Camera frustum bottom plane. | 
| `Single` | Far | Camera frustum far plane.  The valid range is between the current value of the near plane and infinity. | 
| `Single` | Left | Camera frustum left plane. | 
| `Single` | Near | Camera frustum near plane.  The valid range is between 0 and the current value of the far plane.Note that, unlike for the PerspectiveCamera, 0 is a valid value for an OrthographicCamera's near plane. | 
| `Single` | Right | Camera frustum right plane. | 
| `Single` | Top | Camera frustum top plane. | 
| `Single` | Zoom | Gets or sets the zoom factor of the camera. | 


## `PerspectiveCamera`

Camera that uses perspective projection.  This projection mode is designed to mimic the way the human eye sees.It is the most common projection mode used for rendering a 3D scene.  Analogous to : https://threejs.org/docs/index.html#api/cameras/PerspectiveCamera  JS Source: https://github.com/mrdoob/three.js/blob/master/src/cameras/PerspectiveCamera.js
```csharp
public class THREE.Cameras.PerspectiveCamera
    : Camera, IElement

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | Aspect | Camera frustum aspect ratio, usually the canvas width / canvas height. | 
| `Single` | Far | Camera frustum far plane.  The valid range is between the current value of the near plane and infinity. | 
| `Single` | FilmGauge | Film size used for the larger axis. Default is 35 (millimeters). This parameter does not influence the projection matrix unless .filmOffset is set to a nonzero value. | 
| `Single` | FilmOffset | Horizontal off-center offset in the same unit as FilmGauge. | 
| `Single` | Focus | Object distance used for stereoscopy and depth-of-field effects. This parameter does not influence the projection matrix unless a StereoCamera is being used. | 
| `Single` | Fov | Camera frustum vertical field of view, from bottom to top of view, in degrees. | 
| `Single` | Near | Camera frustum near plane.  The valid range is greater than 0 and less than the current value of the far plane.  Note that, unlike for the OrthographicCamera, 0 is not a valid value for a PerspectiveCamera's near plane. | 
| `Single` | Zoom | Gets or sets the zoom factor of the camera. | 


