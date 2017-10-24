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

            var vertices = IrisLib.Geometry.ProcessVertexArray(verts);

            var face = new int[] { 0, 1, 2, 3 };

            var faces = IrisLib.Geometry.ProcessFaceArray(new List<int[]> { { face } }, false, false);

            var geometry = new IrisLib.Geometry(vertices, faces);
            var material = IrisLib.MeshStandardMaterial.Default();

            var mesh = new IrisLib.Mesh
            {
                Geometry = geometry,
                Material = material
            };

            scene.Add(mesh);

            Console.WriteLine(scene.ToJSON());

            Console.ReadLine();

        }
    }
}
