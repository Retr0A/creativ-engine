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
    class ViewportPanel
    {
        private MyGuiPanel viewportPanel = new MyGuiPanel(
            "Viewport",
            new Size(500, 500),
            DockStyle.Fill,
            Window.GetCurrentWindow());

        private static Timer timer;
        private static Panel canvas;
        private Color skyColor;

        public ViewportPanel(Color skyColor)
        {
            timer = new Timer();
            timer.Tick += Tick;
            timer.Interval = 1;
            timer.Start();

            this.skyColor = skyColor;

            viewportPanel.Init();
        }

        public void DrawContent()
        {
            canvas = new Panel() {
                BackColor = skyColor,
                Dock = DockStyle.Fill
            };

            canvas.MouseClick += OnCanvasMouseClick;

            viewportPanel.AddControl(canvas);
        }

        public static void Tick(object sender, EventArgs e)
        {
            foreach (GameObject item in EntryPoint.gameObjects)
            {
                item.Render();
                canvas.Controls.Add(item.GetPanel());
            }
        }

        private void OnCanvasMouseClick(object sender, MouseEventArgs e)
        {
            EntryPoint.SelectedObject = null;
        }
    }
}
