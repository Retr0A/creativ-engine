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
    class WorldSettingsPanel
    {
        private MyGuiPanel myGuiPanel = new MyGuiPanel(
            "Properties",
            new Size(100, 100),
            DockStyle.Bottom,
            Window.GetCurrentWindow());

        public static Timer timer;
        private static Panel objectColorPanel;
        private static Label skyColorLabel;
        private static Panel skyColorPanel;


        public WorldSettingsPanel()
        {
            timer = new Timer();
            timer.Tick += Tick;
            timer.Interval = 1;
            timer.Start();

            myGuiPanel.Init();

            objectColorPanel = new Panel() {
                Dock = DockStyle.Top,
                Size = new Size(220, 60)
            };

            skyColorLabel = new Label() {
                Dock = DockStyle.Left,
                Size = new Size(50, 50),
                Font = new Font("Verdana", 10),
                Text = "Sky Color"
            };
            
            skyColorPanel = new Panel() {
                Dock = DockStyle.Left,
                Size = new Size(20, 20)
            };

            objectColorPanel.Controls.Add(skyColorLabel);
            objectColorPanel.Controls.Add(skyColorPanel);

            skyColorPanel.MouseClick += OnObjectBackgroundColorPanelMouseClick;

            myGuiPanel.AddControl(objectColorPanel);
        }

        private void OnObjectBackgroundColorPanelMouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK && EntryPoint.SelectedObject != null)
            {
                skyColorPanel.BackColor = colorDialog.Color;
                EntryPoint.SelectedObject.Color = colorDialog.Color;
                EntryPoint.SelectedObject.RefreshProperties();
            }
        }

        public static void Tick(object sender, EventArgs e)
        {
            if (EntryPoint.SelectedObject != null)
            {
                skyColorPanel.BackColor = EntryPoint.SelectedObject.Color;

                timer.Tick -= Tick;
            }
            else
            {
                skyColorPanel.BackColor = Color.DarkGray;
            }
        }
    }
}
