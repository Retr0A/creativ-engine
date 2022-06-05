using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine
{
    class Window
    {
        private static Form form;

        public const int WIDTH = 1080;
        public const int HEIGHT = 720;
        public const string TITLE = "Creativengine";

        public static void Create()
        {
            form = new Form() {
                Width = WIDTH,
                Height = HEIGHT,
                Text = TITLE
            };

            Application.Run(form);
        }

        public static Form GetCurrentWindow()
        {
            return form;
        }
    }
}
