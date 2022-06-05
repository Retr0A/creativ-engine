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
        private static Panel topPanel;
        private static TextBox objectName;
        private static Panel objectSendToFront;
        private static Panel spacingPanel;
        private static Panel objectLocationPanel;
        private static NumericUpDown objectLocationXNum;
        private static NumericUpDown objectLocationYNum;
        private static Panel objectScalePanel;
        private static NumericUpDown objectScaleXNum;
        private static NumericUpDown objectScaleYNum;
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

            topPanel = new Panel() {
                Dock = DockStyle.Top,
                Size = new Size(20, 20)
            };

            objectName = new TextBox() {
                Dock = DockStyle.Fill,
                Size = new Size(100, 100),
                BorderStyle = BorderStyle.None,
                Font = new Font("Verdana", 13)
            };

            objectSendToFront = new Panel() {
                Dock = DockStyle.Right,
                BackColor = Color.LightBlue,
                Size = new Size(20, 20)
            };

            spacingPanel = new Panel() {
                Size = new Size(10, 10),
                Dock = DockStyle.Top
            };

            objectLocationPanel = new Panel() {
                Dock = DockStyle.Top,
                Size = new Size(100, 20)
            };

            objectLocationXNum = new NumericUpDown() {
                Dock = DockStyle.Left,
                Maximum = 999999,
                Minimum = -999999
            };
            objectLocationXNum.ValueChanged += OnObjectLocationXNumValueChanged;

            objectLocationYNum = new NumericUpDown() {
                Dock = DockStyle.Right,
                Maximum = 999999,
                Minimum = -999999
            };
            objectLocationYNum.ValueChanged += OnObjectLocationYNumValueChanged;

            objectScalePanel = new Panel() {
                Dock = DockStyle.Top,
                Size = new Size(100, 20)
            };

            objectScaleXNum = new NumericUpDown() {
                Dock = DockStyle.Left,
                Maximum = 999999,
                Minimum = -999999
            };
            objectScaleXNum.ValueChanged += OnObjectScaleXNumValueChanged;

            objectScaleYNum = new NumericUpDown() {
                Dock = DockStyle.Right,
                Maximum = 999999,
                Minimum = -999999
            };
            objectScaleYNum.ValueChanged += OnObjectScaleYNumValueChanged;

            objectColorPanel = new Panel() {
                Dock = DockStyle.Top,
                Size = new Size(20, 20)
            };

            objectColorLabel = new Label() {
                Dock = DockStyle.Left,
                Size = new Size(50, 50),
                Font = new Font("Verdana", 10),
                Text = "Color"
            };
            
            objectBackgroundColorPanel = new Panel() {
                Dock = DockStyle.Left,
                Size = new Size(20, 20)
            };

            topPanel.Controls.Add(objectName);
            topPanel.Controls.Add(objectSendToFront);

            objectColorPanel.Controls.Add(objectColorLabel);
            objectColorPanel.Controls.Add(objectBackgroundColorPanel);

            objectScalePanel.Controls.Add(objectScaleYNum);
            objectScalePanel.Controls.Add(objectScaleXNum);
            objectLocationPanel.Controls.Add(objectLocationYNum);
            objectLocationPanel.Controls.Add(objectLocationXNum);

            objectName.TextChanged += OnObjectNameTextChanged;
            objectBackgroundColorPanel.MouseClick += OnObjectBackgroundColorPanelMouseClick;

            objectSendToFront.MouseClick += OnObjectSendToFrontMouseClick;

            propertiesPanel.AddControl(objectColorPanel);
            propertiesPanel.AddControl(objectScalePanel);
            propertiesPanel.AddControl(objectLocationPanel);
            propertiesPanel.AddControl(spacingPanel);
            propertiesPanel.AddControl(topPanel);
        }

        private void OnObjectSendToFrontMouseClick(object sender, MouseEventArgs e)
        {
            if (EntryPoint.SelectedObject != null)
            {
                EntryPoint.SelectedObject.GetPanel().BringToFront();
            }
        }

        private void OnObjectScaleYNumValueChanged(object sender, EventArgs e)
        {
            EntryPoint.SelectedObject.Scale.SetY((int) objectScaleYNum.Value);

            EntryPoint.SelectedObject.RefreshProperties();
        }

        private void OnObjectScaleXNumValueChanged(object sender, EventArgs e)
        {
            EntryPoint.SelectedObject.Scale.SetX((int) objectScaleXNum.Value);

            EntryPoint.SelectedObject.RefreshProperties();
        }

        private void OnObjectLocationYNumValueChanged(object sender, EventArgs e)
        {
            EntryPoint.SelectedObject.Position.SetY((int) objectLocationYNum.Value);

            EntryPoint.SelectedObject.RefreshProperties();
        }

        private void OnObjectLocationXNumValueChanged(object sender, EventArgs e)
        {
            EntryPoint.SelectedObject.Position.SetX((int) objectLocationXNum.Value);

            EntryPoint.SelectedObject.RefreshProperties();
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

                objectLocationXNum.Value = EntryPoint.SelectedObject.Position.GetX();
                objectLocationYNum.Value = EntryPoint.SelectedObject.Position.GetY();
                objectScaleXNum.Value = EntryPoint.SelectedObject.Scale.GetX();
                objectScaleYNum.Value = EntryPoint.SelectedObject.Scale.GetY();

                objectLocationXNum.Enabled = true;
                objectLocationYNum.Enabled = true;
                objectScaleXNum.Enabled = true;
                objectScaleYNum.Enabled = true;

                timer.Tick -= Tick;
            }
            else
            {
                objectName.Enabled = false;

                objectBackgroundColorPanel.BackColor = Color.DarkGray;
                
                objectLocationXNum.Value = 0;
                objectLocationXNum.Enabled = false;
                objectLocationYNum.Value = 0;
                objectLocationYNum.Enabled = false;
                objectScaleXNum.Value = 0;
                objectScaleXNum.Enabled = false;
                objectScaleYNum.Value = 0;
                objectScaleYNum.Enabled = false;
            }
        }
    }
}
