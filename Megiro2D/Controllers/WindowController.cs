using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megiro2D.Controllers
{
    public class WindowController
    {
        public event DelegateWindow Load;
        public event DelegateWindow Resize;
        public event DelegateWindow UpdateFrame;
        public event DelegateWindow RenderFrame;

        public delegate void DelegateWindow();

        public void OnLoad(object o, EventArgs e)
           => Load?.Invoke();

        public void OnResize(object o, EventArgs e)
           => Resize?.Invoke();

        public void OnUpdateFrame(object o, EventArgs e)
           => UpdateFrame?.Invoke();

        public void OnRenderFrame(object o, EventArgs e)
           => RenderFrame?.Invoke();
    }
}
