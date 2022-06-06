using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Creativengine.src.Engine
{
    internal class Camera : GameObject
    {
        public Camera(string name, Vector3 position, Vector3 scale) : base(name, position, scale, Color.Transparent)
        {
        }
    }
}
