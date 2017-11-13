---
title: Description
display-order: 0
---
.net Class Library written in c# for creating [Three.js](https://threejs.org/) compatible objects.

The scope of this project is focused on serialization (and later perhaps deserialization). Therefore the objects to be targeted should be those that can be read through one of the Three.js Loaders.

This library could be used to develop exporter plugins from 3d modelling software that support mono / .net.

This project started as project [Iris](http://mcneel.github.io/Iris/), a Three.js exporter for Rhino3d. ThreeLib is essentially the serialization library from that project recreated as an open source project and rewritten to be more like working with Three.js. ThreeLib is what allows Iris to write Rhino Objects to json.
