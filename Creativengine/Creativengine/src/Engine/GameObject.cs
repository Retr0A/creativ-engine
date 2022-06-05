using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine
{
    class GameObject
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Scale { get; set; }
        public Color Color { get; set; }

        private Panel panel;

        public GameObject(string name, Vector3 position, Vector3 scale, Color color)
        {
            this.Position = position;
            this.Scale = scale;
            this.Color = color;
            this.Name = name;
        }

        public void Render()
        {
            panel = new Panel() {
                BackColor = Color,
                Location = new Point(Position.GetX(), Position.GetY()),
                Size = new Size(Scale.GetX(), Scale.GetY())
            };

            panel.MouseClick += OnMouseClick;
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            EntryPoint.SelectedObject = this;

            /*if (EntryPoint.SelectedObject != null)
            {
                EntryPoint.SelectedObject.Color = Color.FromArgb(255, 120, 120, 120);
            }*/

            PropertiesPanel.timer.Tick += PropertiesPanel.Tick;
        }

        public void RefreshProperties()
        {
            panel.BackColor = Color;
        }

        public Panel GetPanel()
        {
            return panel;
        }
    }
}
