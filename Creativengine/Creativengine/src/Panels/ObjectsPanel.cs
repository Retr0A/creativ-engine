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
    class ObjectsPanel
    {
        private MyGuiPanel objectsPanel = new MyGuiPanel(
            "Objects",
            new Size(200, 200),
            DockStyle.Left,
            Window.GetCurrentWindow());

        public static Timer timer;
        public static TreeView objectsView;

        public ObjectsPanel()
        {
            timer = new Timer();
            timer.Tick += Tick;
            timer.Interval = 1;
            timer.Start();

            objectsPanel.Init();

            objectsView = new TreeView() {
                Dock = DockStyle.Fill,
                Enabled = false,
                BorderStyle = BorderStyle.None,
                BackColor = Color.LightGray
            };

            objectsView.Nodes.Add("Test");

            objectsPanel.AddControl(objectsView);
        }

        public static void Tick(object sender, EventArgs e)
        {
            objectsView.Nodes.Clear();

            foreach (GameObject item in EntryPoint.GameObjects)
            {
                objectsView.Nodes.Add(item.Name);
            }
        }
    }
}
