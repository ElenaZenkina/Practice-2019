using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public delegate void EventGameOver();
    public delegate void EventAddScore();
    public delegate void EventUpdateView(List<string> objects);

    public enum EDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}
