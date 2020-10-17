using System;
using System.Collections.Generic;
using OpenTK;

namespace DNoise
{
    public class Launcher
    {
        static PerlinNoise noise;
        static int dimensions = 100;

        static List<Vector3> heightMaps;
        static float amplitude = -10,
                     frequency = 10,
                     minimum = .6f,
                     cubeSize = 10;

        public static void Main() {

            noise = new PerlinNoise();
            heightMaps = new List<Vector3>();

            for (int x = 0; x < dimensions; x++) {
                for (int y = 0; y < dimensions; y++) {
                    for (int z = 0; z < dimensions; z++) {

                        float nx = (float)x/dimensions,
                              ny = (float)y/dimensions,
                              nz = (float)z/dimensions;

                        float ns = Generate3DNoise(nx*frequency,
                                                   ny*frequency,
                                                   nz*frequency)*amplitude;
                        if (ns > minimum) { 
                            //Console.WriteLine(ns);
                            heightMaps.Add(new Vector3(x*cubeSize,y*cubeSize,z*cubeSize));
                        }
                    }
                }
            }

            new Game(heightMaps, cubeSize, 1000, 1000);
        }

        static float Generate3DNoise(float x, float y, float z) {

            float xy = noise.noise(x,y),
                  yz = noise.noise(y,z),
                  xz = noise.noise(x,z);

            float yx = noise.noise(y,x),
                  zy = noise.noise(z,y),
                  zx = noise.noise(z,x);

            return (xy+yz+xz+yx+zy+zx)/6;
        }
    }
}
