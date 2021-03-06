using Megiro2D.Controllers;
using Megiro2D.Engine;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Megiro2D
{
    public class Window : GameWindow
    {
        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.DepthTest);
            Input.Initialize(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            WindowController.Singleton.OnLoad(e);

            GL.ClearColor(Color.LightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            WindowController.Singleton.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 150);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Time.DeltaTime = (float)e.Time * Time.TimeScale;

            base.OnUpdateFrame(e);
            
            WindowController.Singleton.OnUpdateFrame(e);

            if (Input.KeyPress(Key.Escape))
                Exit();

            Input.Update();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (Camera.camera == null)
                return;

            Camera.camera.ApplyTransform(Width, Height);

            WindowController.Singleton.OnRenderFrame(e);

            SwapBuffers();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            WindowController.Singleton.OnClosing();
        }
    }
}
