using System;
namespace DNoise
{
    public class PerlinNoise
    {
        struct vector2 {
            public float x, y;
        }

        public float noise(float x, float y) {
            int fx = (int)x,
                fx1 = fx+1;

            int fy = (int)y,
                fy1 = fy+1;

            float sx = x - (float)fx,
                  sy = y - (float)fy;

            return interpolate(interpolate(dotGridGraident(fx, fy, x, y),
                                           dotGridGraident(fx1, fy, x, y),
                                           sx), interpolate(
                                           dotGridGraident(fx, fy1, x, y),
                                           dotGridGraident(fx1, fy1, x, y),
                                           sx), sy);
        }

        float dotGridGraident(int ix, int iy, float x, float y) {
            vector2 grad = gradient(ix,iy);

            float xDistance = x - (float)ix;
            float yDistance = y - (float)iy;

            return (xDistance*grad.x + yDistance*grad.y);
        }

        float interpolate(float a, float b, float w) {
            return (float)Math.Pow(w, 2) * (3 - 2 * w) * (b - a) + a;
        }

        vector2 gradient(int ix, int iy) {

            float rand = (float)(2920 * Math.Sin(ix*21942+iy*171324+8912) * Math.Cos(ix*23157*iy*217832+6758));
            vector2 grad = new vector2();
            grad.x = (float)Math.Sin(rand);
            grad.y = (float)Math.Cos(rand);
            return grad;
        }
    }
}
