using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static d3readtex.Level;

namespace d3readtex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("d3readtex v0.1, writes all Descent 3 textures as png files");
            Console.WriteLine();
        	if (args.Length == 0 || !File.Exists(args[0]))
        	{
        		Console.WriteLine("Specify the d3.hog file path as argument");
        		return;
            }
            int count = 0;
            Hog hog = Hog.OpenHog(args[0]);
            foreach (var entry in hog.Entries)
                if (entry.name.EndsWith(".ogf", StringComparison.InvariantCultureIgnoreCase))
                {
                    Bitmap.Read(new BinaryReader(hog.Open(entry.name))).WritePNG(entry.name.Substring(0, entry.name.Length - 4) + ".png");
                    count++;
                }
            Console.WriteLine("Wrote " + count + " png files");
        }
    }
}
