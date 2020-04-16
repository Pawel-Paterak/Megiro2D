using Megiro2D.Controllers;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;

namespace Megiro2D
{
    public class Window : GameWindow
    {
        public KeyboardController KeyboardController { get; private set; } = new KeyboardController();
        public WindowController WindowController { get; private set; } = new WindowController();

        const int num_lists = 13;
        int[] lists = new int[num_lists];


        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            KeyboardController.Singleton.OnKeyDown(e);
        }

        protected override void OnKeyPress(OpenTK.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            KeyboardController.Singleton.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e)
        {
            base.OnKeyUp(e);
            KeyboardController.Singleton.OnKeyUp(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            WindowController.Singleton.OnLoad(e);

            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            WindowController.Singleton.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            WindowController.Singleton.OnUpdateFrame(e);


            var keyboard = Keyboard.GetState();
            if (keyboard[Key.Escape])
                base.Exit();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            WindowController.Singleton.OnRenderFrame(e);

            this.SwapBuffers();
            Thread.Sleep(1);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            WindowController.Singleton.OnClosing();
        }
    }
}
