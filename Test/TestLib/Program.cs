using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TestLib
{
    class Program
    {
        static void Main(string[] args)
        {

            var scene = new ThreeLib.Scene
            {
                Background = new ThreeLib.Color(255,0,255).ToInt(),
                Name = "My Scene"
            };

            var verts = new List<float[]>
            {
                new float[] { 0, 0, 0 },
                new float[] { 0, 0, 10.1234f },
                new float[] { 10, 0, 10 },
                new float[] { 10, 0, 0 }
            };

            var norms = new List<float[]>
            {
                new float[] { 0, 1, 0 },
                new float[] { 0, 1, 0 },
                new float[] { 0, 1, 0 },
                new float[] { 0, 1, 0 }
            };

            var vertices = ThreeLib.Geometry.ProcessVertexArray(verts);

            var normals = ThreeLib.Geometry.ProcessNormalArray(norms);

            var face = new int[] { 0, 1, 2, 3 };

            var faces = ThreeLib.Geometry.ProcessFaceArray(new List<int[]> { { face } }, false, false);

            var geometry = new ThreeLib.Geometry(vertices, faces, normals);
            var material = ThreeLib.MeshStandardMaterial.Default();

            var mesh = new ThreeLib.Mesh
            {
                Geometry = geometry,
                Material = material,
                Name = "My Mesh"
            };

            scene.Add(mesh);

            var material2 = ThreeLib.MeshStandardMaterial.Default();
            material2.Roughness = 0.25;

            var mesh2 = new ThreeLib.Mesh
            {
                Geometry = geometry,
                Material = material2,
                Position = new ThreeLib.Vector3(20,20,20),
                Name = "My Mesh2"
            };

            scene.Add(mesh2);

            var material3 = ThreeLib.MeshStandardMaterial.Default();

            var mesh3 = new ThreeLib.Mesh
            {
                Geometry = geometry,
                Material = material3,
                Position = new ThreeLib.Vector3(30, 30, 30),
                Name = "My Mesh3"
            };

            scene.Add(mesh3);

            var line = new ThreeLib.Line
            {
                Geometry = new ThreeLib.Geometry(vertices),
                Material = new ThreeLib.LineBasicMaterial { Color = new ThreeLib.Color(255,0,0).ToInt(), LineWidth = 20 },
                Name = "My Curves"
            };

            scene.Add(line);

            var points = new ThreeLib.Points
            {
                Geometry = new ThreeLib.Geometry(vertices),
                Material = new ThreeLib.PointsMaterial { Color = new ThreeLib.Color(255, 255, 255).ToInt() },
                Name = "My Points"
            };

            scene.Add(points);

            #region Lights

            var pointLight = new ThreeLib.PointLight
            {
                Color = new ThreeLib.Color(100, 100, 100).ToInt(),
                Decay = 1,
                Intensity = 3,
                Name = "My PointLight",
                Position = new ThreeLib.Vector3(10, 10, 10)
            };

            scene.Add(pointLight);

            var ambientLight = new ThreeLib.AmbientLight
            {
                Color = new ThreeLib.Color(255, 0, 255).ToInt(),
                Intensity = 5,
                Name = "My AmbientLight"
            };

            scene.Add(ambientLight);

            var directionalLight = new ThreeLib.DirectionalLight
            {
                Target = new ThreeLib.Object3D { Position = new ThreeLib.Vector3(3, 0, 0) },
                Position = new ThreeLib.Vector3(-10,10,5),
                Name = "My DirectionalLight"
            };

            scene.Add(directionalLight);

            var spotLight = new ThreeLib.SpotLight
            {
                Target = new ThreeLib.Object3D { Position = new ThreeLib.Vector3(3, 0, 3) },
                Position = new ThreeLib.Vector3(20,20,0),
                Name = "My SpotLight"
            };

            scene.Add(spotLight);

            var hemiLight = new ThreeLib.HemisphereLight
            {
                SkyColor = new ThreeLib.Color(0,30,255).ToInt(),
                GroundColor = new ThreeLib.Color(30,30,30).ToInt(),
                Name = "My HemisphereLight"
            };

            scene.Add(hemiLight);

            #endregion

            //Console.WriteLine(geometry.ToJSON(true));

            Console.WriteLine(scene.ToJSON(true));

            Console.ReadLine();

        }
    }
}
