using Megiro2D.Delegates;
using OpenTK;
using System;

namespace Megiro2D.Controllers
{
    public class WindowController
    {
        public event DelegateWindow Load;
        public event DelegateWindow Resize;
        public event DelegateWindow StartFrame;
        public event DelegateWindow UpdateFrame;
        public event DelegateWindow RenderFrame;
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
                Load?.Invoke();
        }

        public void OnResize(EventArgs e)
        {
            if (IsSingleton())
                Resize?.Invoke();
        }

        public void OnUpdateFrame(FrameEventArgs e)
        {
            if (IsSingleton())
            {
                StartFrame?.Invoke();
                StartFrame = (DelegateWindow)Delegate.RemoveAll(StartFrame, StartFrame);
                UpdateFrame?.Invoke();
            }
        }

        public void OnRenderFrame(FrameEventArgs e)
        {
            if (IsSingleton())
                RenderFrame?.Invoke();
        }

        public void OnClosing()
        {
            if (IsSingleton())
                Closing?.Invoke();
        }

        private bool IsSingleton()
        {
            if (Singleton != this)
                throw new Exception("you can't call this method, you can call this method only in Singleton");
            return true;
        }
    }
}
