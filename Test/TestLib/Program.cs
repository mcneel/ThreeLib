using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    class Program
    {
        static void Main(string[] args)
        {

            var scene = new IrisLib.Scene();

            var verts = new List<float[]>
            {
                new float[] { 0, 0, 0 },
                new float[] { 10, 0, 0 },
                new float[] { 10, 0, 10 },
                new float[] { 0, 0, 10 }
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

            var line = new IrisLib.Line
            {
                Geometry = new IrisLib.Geometry(vertices),
                Material = new IrisLib.LineBasicMaterial { Color = new IrisLib.Color(255,0,0).ToInt() },
                Name = "My Curves"
            };

            var points = new IrisLib.Points
            {
                Geometry = new IrisLib.Geometry(vertices),
                Material = new IrisLib.PointsMaterial { Color = new IrisLib.Color(255, 255, 255).ToInt() },
                Name = "My Points"
            };

            var pointLight = new IrisLib.PointLight
            {
                Color = new IrisLib.Color(100, 100, 100).ToInt(),
                Decay = 1,
                Intensity = 3,
                Name = "My PointLight"
            };

            scene.Add(mesh);
            scene.Add(line);
            scene.Add(points);
            scene.Add(pointLight);

            Console.WriteLine(scene.ToJSON());

            Console.ReadLine();

        }
    }
}
