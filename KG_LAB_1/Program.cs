using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace KG_LAB_1
{
    internal struct Vertex
    {
        public double X { set; get; }
        public double Y { set; get; }
        public double Z { set; get; }

        public Vertex(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            //Parsing .obj file to get vertices coordinates
            var lines = File.ReadAllLines(@"cube.obj");
            var vertices = (from line in lines
                where line.ToLower().StartsWith("v ")
                select line.Split(' ')
                    .Skip(1)
                    .Select(v => double.Parse(v.Replace('.', ',')))
                    .ToArray()
                into vx
                select new Vertex(vx[0], vx[1], vx[2])).ToList();
            foreach (var v in vertices)
            {
                Console.WriteLine(v.X+"\t"+v.Y+"\t"+v.Z+"\n");
            }

            

            Console.ReadLine();
        }
    }
}