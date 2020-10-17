﻿using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace DNoise
{
    public class Game : GameWindow
    {
        List<Cube> cubes = new List<Cube>();
        Camera camera;

        public Game(List<Vector3> coordinates, float cubeSize, int width, int height)
            : base(width,height,GraphicsMode.Default,"3D noise") {
            camera = new Camera(this);

            foreach (Vector3 v in coordinates) {
                if (v != null) cubes.Add(new Cube(v, cubeSize));
            }

            Run(60);
        }

        protected override void OnRenderFrame(FrameEventArgs e) {

            var view = Matrix4.LookAt(camera.position, camera.position + camera.front, camera.up);
            GL.LoadMatrix(ref view);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //GL.Rotate(1f, 0, 1, 0);

            foreach (Cube c in cubes) {
                c.Render();
            }

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e) {

            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 perspectiveMatrix =
                Matrix4.CreatePerspectiveFieldOfView(1, Width / Height, 1.0f, 1000.0f);
            GL.LoadMatrix(ref perspectiveMatrix);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.End();
            base.OnResize(e);
        }

        protected override void OnLoad(EventArgs e) {
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(0, 0, 0, 0);
            base.OnLoad(e);
        }
    }
}
