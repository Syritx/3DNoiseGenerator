using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace DNoise
{
    public class Cube
    {
        Vector3 position;
        float size;

        public Cube(Vector3 position, float size) {
            this.position = position;
            this.size = size;
        }

        public void Render()
        {
            GL.Begin(BeginMode.Quads);
            GL.Color3(1.0, 1.0, 1.0);

            // Front
            GL.Vertex3(-size + position.X,  size + position.Y, size + position.Z);
            GL.Vertex3( size + position.X,  size + position.Y, size + position.Z);
            GL.Vertex3( size + position.X, -size + position.Y, size + position.Z);
            GL.Vertex3(-size + position.X, -size + position.Y, size + position.Z);

            GL.Color3(1.0, 0.0, 0.0);

            // Back
            GL.Vertex3(-size + position.X,  size + position.Y, -size + position.Z);
            GL.Vertex3( size + position.X,  size + position.Y, -size + position.Z);
            GL.Vertex3( size + position.X, -size + position.Y, -size + position.Z);
            GL.Vertex3(-size + position.X, -size + position.Y, -size + position.Z);

            GL.Color3(0.0, 1.0, 0.0);

            // Left
            GL.Vertex3(-size + position.X,  size + position.Y, -size + position.Z);
            GL.Vertex3(-size + position.X,  size + position.Y,  size + position.Z);
            GL.Vertex3(-size + position.X, -size + position.Y,  size + position.Z);
            GL.Vertex3(-size + position.X, -size + position.Y, -size + position.Z);

            GL.Color3(0.0, 0.0, 1.0);

            // Right
            GL.Vertex3(size + position.X,  size + position.Y, -size + position.Z);
            GL.Vertex3(size + position.X,  size + position.Y,  size + position.Z);
            GL.Vertex3(size + position.X, -size + position.Y,  size + position.Z);
            GL.Vertex3(size + position.X, -size + position.Y, -size + position.Z);

            GL.Color3(1.0, 1.0, 0.0);

            // Top
            GL.Vertex3(-size + position.X, size + position.Y, -size + position.Z);
            GL.Vertex3(-size + position.X, size + position.Y,  size + position.Z);
            GL.Vertex3( size + position.X, size + position.Y,  size + position.Z);
            GL.Vertex3( size + position.X, size + position.Y, -size + position.Z);

            GL.Color3(1.0, 0.5, 0.0);

            // Bottom
            GL.Vertex3(-size + position.X, -size + position.Y, -size + position.Z);
            GL.Vertex3(-size + position.X, -size + position.Y,  size + position.Z);
            GL.Vertex3( size + position.X, -size + position.Y,  size + position.Z);
            GL.Vertex3( size + position.X, -size + position.Y, -size + position.Z);
            GL.End();
        }
    }
}
