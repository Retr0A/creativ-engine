using MyGui;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine
{
    class EntryPoint
    {
        public static void Main(string[] args)
        {
            Window.Create();

            MyGuiPanel viewportPanel = new MyGuiPanel("Viewport", new Size(500, 500), DockStyle.Fill, Window.GetCurrentWindow());
            viewportPanel.Init();

            Application.Run(Window.GetCurrentWindow());
        }
    }
}
