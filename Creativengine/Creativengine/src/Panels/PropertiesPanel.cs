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
    class PropertiesPanel
    {
        private MyGuiPanel propertiesPanel = new MyGuiPanel(
            "Properties",
            new Size(300, 300),
            DockStyle.Right,
            Window.GetCurrentWindow());

        public static Timer timer;
        private static TextBox objectName;
        private static Panel spacingPanel;
        private static Panel objectColorPanel;
        private static Label objectColorLabel;
        private static Panel objectBackgroundColorPanel;


        public PropertiesPanel()
        {
            timer = new Timer();
            timer.Tick += Tick;
            timer.Interval = 1;
            timer.Start();

            propertiesPanel.Init();

            objectName = new TextBox() {
                Dock = DockStyle.Top,
                Size = new Size(100, 100),
                BorderStyle = BorderStyle.None,
                Font = new Font("Verdana", 15)
            };

            spacingPanel = new Panel() {
                Size = new Size(10, 10),
                Dock = DockStyle.Top
            };

            objectColorPanel = new Panel() {
                Dock = DockStyle.Top,
                Size = new Size(100, 20)
            };

            objectColorLabel = new Label() {
                Dock = DockStyle.Right,
                Size = new Size(50, 50),
                Font = new Font("Verdana", 10),
                Text = "Color"
            };
            
            objectBackgroundColorPanel = new Panel() {
                Dock = DockStyle.Left,
                Size = new Size(20, 20)
            };

            objectColorPanel.Controls.Add(objectColorLabel);
            objectColorPanel.Controls.Add(objectBackgroundColorPanel);

            objectName.TextChanged += OnObjectNameTextChanged;
            objectBackgroundColorPanel.MouseClick += OnObjectBackgroundColorPanelMouseClick;

            propertiesPanel.AddControl(objectColorPanel);
            propertiesPanel.AddControl(spacingPanel);
            propertiesPanel.AddControl(objectName);
        }

        private void OnObjectBackgroundColorPanelMouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK && EntryPoint.SelectedObject != null)
            {
                objectBackgroundColorPanel.BackColor = colorDialog.Color;
                EntryPoint.SelectedObject.Color = colorDialog.Color;
                EntryPoint.SelectedObject.RefreshProperties();
            }
        }

        private void OnObjectNameTextChanged(object sender, EventArgs e)
        {
            EntryPoint.SelectedObject.Name = objectName.Text;
        }

        public static void Tick(object sender, EventArgs e)
        {
            if (EntryPoint.SelectedObject != null)
            {
                objectName.Text = EntryPoint.SelectedObject.Name;
                objectName.Enabled = true;

                objectBackgroundColorPanel.BackColor = EntryPoint.SelectedObject.Color;

                timer.Tick -= Tick;
            }
            else
            {
                objectName.Enabled = false;

                objectBackgroundColorPanel.BackColor = Color.DarkGray;
            }
        }
    }
}
