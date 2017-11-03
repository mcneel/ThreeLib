# ThreeLib
.net Class Library written in c# for creating [Three.js](https://github.com/mrdoob/three.js) compatible objects.

[![Build status](https://ci.appveyor.com/api/projects/status/7bh8wx2e74b6krrd?svg=true)](https://ci.appveyor.com/project/fraguada/ThreeLib)

The scope of this project is focused on serialization (and later perhaps deserialization). Therefore the objects to be targeted should be those that can be read through one of the Three.js [Loaders](https://github.com/mrdoob/three.js/tree/master/src/loaders).

This project started as project [Iris](http://mcneel.github.io/Iris/), a Three.js exporter for [Rhino3d](http://www.rhino3d.com/). ThreeLib is essentially the serialization library from that project recreated as an open source project and rewritten to be more like working with Three.js.

## Dependencies
- [Json.Net](https://github.com/JamesNK/Newtonsoft.Json)

## Usage
You can either clone this repo and build the ThreeLib.csproj or use the published [NuGet package](https://www.nuget.org/packages/ThreeLib/).

Check out the [Sample project](https://github.com/mcneel/ThreeLib/tree/master/Sample) to see how some of the API is coming along.

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
|[Cameras](https://github.com/mcneel/ThreeLib/tree/master/THREE/Cameras)		| Camera					 | WIP    |
|						| CubeCamera				 | -      |
|						| OrthographicCamera		 | WIP    |
|						| PerspectiveCamera			 | WIP    |
|						| StereoCamera				 | -      |
|Constants				| -							 | -      |
|[Core](https://github.com/mcneel/ThreeLib/tree/master/THREE/Core)			| BufferAttribute			 | WIP    |
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
|[Lights](https://github.com/mcneel/ThreeLib/tree/master/THREE/Lights)		| AmbientLight				 | WIP    |
|						| DirectionalLight			 | WIP    |
|						| HemisphereLight			 | WIP    |
|						| Light						 | WIP    |
|						| PointLight				 | WIP    |
|						| RectAreaLight				 | WIP    |
|						| SpotLight					 | WIP    |
|[Lights/Shadows](https://github.com/mcneel/ThreeLib/tree/master/THREE/Lights)		| DirectionalLightShadow	 | WIP    |
|						| LightShadow				 | WIP    |
|						| SpotLightShadow			 | WIP    |
|[Materials](https://github.com/mcneel/ThreeLib/tree/master/THREE/Materials)	| LineBasicMaterial			 | WIP    |
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
|[Math](https://github.com/mcneel/ThreeLib/tree/master/THREE/Math)			| Box2						 | -      |
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
|[Objects](https://github.com/mcneel/ThreeLib/tree/master/THREE/Objects)		| Bone						 | -      |
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
|[Scenes](https://github.com/mcneel/ThreeLib/tree/master/THREE/Scenes)		| Fog						 | -      |
|						| FogExp2					 | -      |
|						| Scene						 | WIP    |
|[Textures](https://github.com/mcneel/ThreeLib/tree/master/THREE/Textures)	| CompressedTexture			 | -      |
|						| CubeTexture				 | -      |
|						| DataTexture				 | -      |
|						| DepthTexture				 | -      |
|						| Texture					 | WIP    |
|						| VideoTexture				 | -      |
|Other					| Image						 | WIP    |









