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
    class AssetsPanel
    {
        private MyGuiPanel viewportPanel = new MyGuiPanel(
            "Assets",
            new Size(200, 200),
            DockStyle.Bottom,
            Window.GetCurrentWindow());

        public static Timer timer;

        public AssetsPanel()
        {
            timer = new Timer();
            timer.Tick += Tick;
            timer.Interval = 1;
            timer.Start();

            viewportPanel.Init();

            // To Do: Assets View
        }

        public static void Tick(object sender, EventArgs e)
        {
        }
    }
}
