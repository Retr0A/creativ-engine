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
        public static List<GameObject> gameObjects { get; set; } = new List<GameObject>();

        public static GameObject SelectedObject { get; set; } = null;

        private static ToolStrip toolBar;
        private static ToolStripDropDownButton fileDropDown;
        private static ToolStripDropDownButton objectDropDown;

        public static void Main(string[] args)
        {
            Window.Create();

            GameObject test1Object = new GameObject("Test 1", new Vector3(10, 10), new Vector3(100, 100), Color.Green);
            gameObjects.Add(test1Object);

            GameObject test2Object = new GameObject("Test 2", new Vector3(120, 10), new Vector3(100, 100), Color.Blue);
            gameObjects.Add(test2Object);

            ViewportPanel viewportPanel = new ViewportPanel(Color.Black);
            viewportPanel.DrawContent();

            AssetsPanel assetsPanel = new AssetsPanel();
            PropertiesPanel propertiesPanel = new PropertiesPanel();
            ObjectsPanel objectsPanel = new ObjectsPanel();

            toolBar = new ToolStrip() {
                Dock = DockStyle.Top,
                GripStyle = ToolStripGripStyle.Hidden,
                BackColor = Color.LightGray
            };
            fileDropDown = new ToolStripDropDownButton() {
                Text = "File",
                ShowDropDownArrow = false
            };
            objectDropDown = new ToolStripDropDownButton() {
                Text = "Object",
                ShowDropDownArrow = false
            };
            fileDropDown.DropDownItems.Add("Save As").Click += FileMenuOnClick;
            fileDropDown.DropDownItems.Add("Open").Click += FileMenuOnClick;
            fileDropDown.DropDownItems.Add("Exit Program").Click += FileMenuOnClick;
            fileDropDown.DropDownItems.Add("About").Click += FileMenuOnClick;
            objectDropDown.DropDownItems.Add("New Object").Click += ObjectMenuOnClick;
            toolBar.Items.Add(fileDropDown);
            toolBar.Items.Add(objectDropDown);
            Window.GetCurrentWindow().Controls.Add(toolBar);

            Application.Run(Window.GetCurrentWindow());
        }

        private static void ObjectMenuOnClick(object sender, EventArgs e)
        {
            if (((ToolStripItem)sender).Text == "New Object")
            {
                GameObject instantiatedObject = new GameObject("New Object",
                    new Vector3(),
                    new Vector3(50, 50),
                    Color.White);

                gameObjects.Add(instantiatedObject);
            }
        }

        private static void FileMenuOnClick(object sender, EventArgs e)
        {
            if (((ToolStripItem)sender).Text == "Save As")
            {
                // To Do: Save System
            }
            else if (((ToolStripItem)sender).Text == "Open")
            {
                // To Do: Open System
            }
            else if (((ToolStripItem)sender).Text == "Exit Program")
            {
                Application.Exit();
            }
            else if (((ToolStripItem)sender).Text == "About")
            {
                MessageBox.Show("Creativengine v0.1 Pre-Release", "About", MessageBoxButtons.OK);
            }
        }
    }
}
