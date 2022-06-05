using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creativengine
{
    class Vector3
    {
        private int x, y;

        public Vector3(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector3(int x)
        {
            this.x = x;
            this.y = 0;
        }

        public Vector3()
        {
            this.x = 0;
            this.y = 0;
        }

        public int GetX()
        {
            return x;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public int GetY()
        {
            return y;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public void AddX(int x)
        {
            this.x += x;
        }

        public void AddY(int y)
        {
            this.y += y;
        }

        public void RemoveX(int x)
        {
            this.x -= x;
        }

        public void RemoveY(int y)
        {
            this.y -= y;
        }
    }
}
