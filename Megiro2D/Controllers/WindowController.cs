using Megiro2D.Delegates;
using OpenTK;
using System;

namespace Megiro2D.Controllers
{
    public class WindowController
    {
        public event DelegateWindow Load;
        public event DelegateWindow Resize;
        public event DelegateFrame UpdateFrame;
        public event DelegateFrame RenderFrame;
        public event DelegateWindow Closing;

        public delegate void DelegateWindow();

        public static WindowController Singleton;

        public WindowController()
        {
            if (Singleton == null)
                Singleton = this;
        }

        public void OnLoad(EventArgs e)
        {
            if(IsSingleton())
                Singleton.Load?.Invoke();
        }

        public void OnResize(EventArgs e)
        {
            if (IsSingleton())
                Singleton.Resize?.Invoke();
        }

        public void OnUpdateFrame(FrameEventArgs e)
        {
            if (IsSingleton())
                Singleton.UpdateFrame?.Invoke(e);
        }

        public void OnRenderFrame(FrameEventArgs e)
        {
            if (IsSingleton())
                Singleton.RenderFrame?.Invoke(e);
        }

        public void OnClosing()
        {
            if (IsSingleton())
                Singleton.Closing?.Invoke();
        }

        private bool IsSingleton()
        {
            if (Singleton != this)
                throw new Exception("you can't call this method, you can call this method only in Singleton");
            return true;
        }
    }
}
