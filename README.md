# ThreeLib
.net Class Library for creating [Three.js](https://github.com/mrdoob/three.js) compatible objects.

[![Build status](https://ci.appveyor.com/api/projects/status/7bh8wx2e74b6krrd?svg=true)](https://ci.appveyor.com/project/fraguada/ThreeLib)

## Dependencies
- [Json.Net](https://github.com/JamesNK/Newtonsoft.Json)

## Usage
You can either clone this repo and build the ThreeLib.csproj or use the published [NuGet package](https://www.nuget.org/packages/ThreeLib/).

## Docs
- [LICENSE](https://github.com/mcneel/ThreeLib/blob/master/LICENSE)
- [CODE OF CONDUCT](https://github.com/mcneel/ThreeLib/blob/master/CODE_OF_CONDUCT.md)
- [CONTRIBUTING](https://github.com/mcneel/ThreeLib/blob/master/CONTRIBUTING.md)

## Current Status

Three.js Objects

| Category				| Object                     | Status |
|:------------------	|:---------------------------|:-------|
|Animation				| -							 | -      |
|Animation / Tracks		| -							 | -      |
|Audio					| -							 | -      |
|[Cameras](Cameras)		| Camera					 | WIP    |
|						| CubeCamera				 | -      |
|						| OrthographicCamera		 | WIP    |
|						| PerspectiveCamera			 | WIP    |
|						| StereoCamera				 | -      |
|Constants				| -							 | -      |
|[Core](Core)			| BufferAttribute			 | WIP    |
|						| BufferGeometry			 | WIP    |
|						| Clock						 | -      |
|						| DirectGeometry			 | -      |
|						| EventDispatcher			 | -      |
|						| Face3						 | -      |
|						| Geometry					 | WIP    |
|						| InstancedBufferAttribute   | -      |
|						| InstancedBufferGeometry    | -      |
|						| InstancedInterleavedBuffer | -      |
|						| InterleavedBuffer          | -      |
|						| InterleavedBufferAttribute | -      |
|						| Layers					 | -      |
|						| Object3D					 | WIP    |
|						| Raycaster					 | -      |
|						| Uniform					 | -      |
|Core/BufferAttributes	| -							 | -      |
|Geometries				| -							 | -      |
|[Lights](Lights)		| AmbientLight				 | WIP    |
|						| DirectionalLight			 | WIP    |
|						| HemisphereLight			 | WIP    |
|						| Light						 | WIP    |
|						| PointLight				 | WIP    |
|						| RectAreaLight				 | WIP    |
|						| SpotLight					 | WIP    |
|[Lights/Shadows](Lights/Shadows)		| DirectionalLightShadow	 | WIP    |
|						| LightShadow				 | WIP    |
|						| SpotLightShadow			 | WIP    |
|[Materials](Materials)	| LineBasicMaterial			 | WIP    |
|						| LineDashedMaterial		 | -      |
|						| Material					 | WIP    |
|						| MeshBasicMaterial			 | WIP    |
|						| MeshDepthMaterial			 | WIP    |
|						| MeshLambertMaterial		 | WIP    |
|						| MeshNormalMaterial		 | WIP    |
|						| MeshPhongMaterial			 | WIP    |
|						| MeshPhysicalMaterial		 | WIP    |
|						| MeshStandardMaterial		 | WIP    |
|						| MeshToonMaterial			 | -	  |
|						| PointsMaterial			 | WIP    |
|						| RawShaderMaterial			 | -	  |
|						| ShaderMaterial			 | -	  |
|						| ShadowMaterial			 | -	  |
|						| SpriteMaterial			 | -	  |
|[Math](Math)			| Box2						 | -      |
|						| Box3						 | -      |
|						| Color						 | WIP    |
|						| Cylindrical				 | -      |
|						| Euler						 | WIP    |
|						| Frustum					 | -      |
|						| Interpolant				 | -      |
|						| Line3						 | -      |
|						| Math						 | -      |
|						| Matrix3					 | -      |
|						| Matrix4					 | WIP    |
|						| Plane						 | -      |
|						| Quaternion				 | WIP    |
|						| Ray						 | -      |
|						| Sphere					 | -      |
|						| Spherical					 | -      |
|						| Triangle					 | -	  |
|						| Vector2					 | -      |
|						| Vector3					 | WIP    |
|						| Vector4					 | -      |
|[Objects](Objects)		| Bone						 | -      |
|						| Group						 | WIP    |
|						| LensFlare					 | -      |
|						| Line						 | WIP    |
|						| LineLoop					 | -      |
|						| LineSegments				 | -      |
|						| LOD						 | -      |
|						| Mesh						 | WIP    |
|						| Points					 | WIP    |
|						| Skeleton					 | -      |
|						| SkinnedMesh				 | -      |
|						| Sprite					 | -      |
|[Scenes](Scenes)		| Fog						 | -      |
|						| FogExp2					 | -      |
|						| Scene						 | WIP    |
|[Textures](Textures)	| CompressedTexture			 | -      |
|						| CubeTexture				 | -      |
|						| DataTexture				 | -      |
|						| DepthTexture				 | -      |
|						| Texture					 | WIP    |
|						| VideoTexture				 | -      |
|Other					| Image						 | WIP    |

[Cameras]: https://github.com/mcneel/ThreeLib/tree/master/THREE/Cameras
[Core]:https://github.com/mcneel/ThreeLib/tree/master/THREE/Core
[Lights]: https://github.com/mcneel/ThreeLib/tree/master/THREE/Lights
[Lights/Shadows]:https://github.com/mcneel/ThreeLib/tree/master/THREE/Lights
[Materials]: https://github.com/mcneel/ThreeLib/tree/master/THREE/Materials
[Math]: https://github.com/mcneel/ThreeLib/tree/master/THREE/Math
[Objects]: https://github.com/mcneel/ThreeLib/tree/master/THREE/Objects
[Scenes]: https://github.com/mcneel/ThreeLib/tree/master/THREE/Scenes
[Textures]: https://github.com/mcneel/ThreeLib/tree/master/THREE/Textures









