using System;
using System.Collections.Generic;

namespace TestLib
{
    class Program
    {
        static void Main(string[] args)
        {

            var scene = new IrisLib.Scene
            {
                Background = new IrisLib.Color(255,0,255).ToInt(),
                Name = "My Scene"
            };

            var verts = new List<float[]>
            {
                new float[] { 0, 0, 0 },
                new float[] { 0, 0, 10 },
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

            var vertices = IrisLib.Geometry.ProcessVertexArray(verts);

            var normals = IrisLib.Geometry.ProcessNormalArray(norms);

            var face = new int[] { 0, 1, 2, 3 };

            var faces = IrisLib.Geometry.ProcessFaceArray(new List<int[]> { { face } }, false, false);

            var geometry = new IrisLib.Geometry(vertices, faces, normals);
            var material = IrisLib.MeshStandardMaterial.Default();

            var mesh = new IrisLib.Mesh
            {
                Geometry = geometry,
                Material = material,
                Name = "My Mesh"
            };

            scene.Add(mesh);

            var line = new IrisLib.Line
            {
                Geometry = new IrisLib.Geometry(vertices),
                Material = new IrisLib.LineBasicMaterial { Color = new IrisLib.Color(255,0,0).ToInt(), LineWidth = 20 },
                Name = "My Curves"
            };

            scene.Add(line);

            var points = new IrisLib.Points
            {
                Geometry = new IrisLib.Geometry(vertices),
                Material = new IrisLib.PointsMaterial { Color = new IrisLib.Color(255, 255, 255).ToInt() },
                Name = "My Points"
            };

            scene.Add(points);

            #region Lights

            var pointLight = new IrisLib.PointLight
            {
                Color = new IrisLib.Color(100, 100, 100).ToInt(),
                Decay = 1,
                Intensity = 3,
                Name = "My PointLight",
                Position = new IrisLib.Vector3(10, 10, 10)
            };

            scene.Add(pointLight);

            var ambientLight = new IrisLib.AmbientLight
            {
                Color = new IrisLib.Color(255, 0, 255).ToInt(),
                Intensity = 5,
                Name = "My AmbientLight"
            };

            scene.Add(ambientLight);

            var directionalLight = new IrisLib.DirectionalLight
            {
                Target = new IrisLib.Object3D { Position = new IrisLib.Vector3(3, 0, 0) },
                Position = new IrisLib.Vector3(-10,10,5),
                Name = "My DirectionalLight"
            };


            scene.Add(directionalLight);

            var spotLight = new IrisLib.SpotLight
            {
                Target = new IrisLib.Object3D { Position = new IrisLib.Vector3(3, 0, 3) },
                Position = new IrisLib.Vector3(20,20,0),
                Name = "My SpotLight"
            };

            scene.Add(spotLight);

            #endregion

            Console.WriteLine(scene.ToJSON());

            Console.ReadLine();

        }
    }
}
