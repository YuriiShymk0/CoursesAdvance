using System;

namespace CodForRefactoring
{
    class KeyEvent
    {
        public event EventHandler<MyEventArgs> KeyDown;
        public void OnKeyDown(char ch)
        {
            MyEventArgs c = new MyEventArgs();

            if (KeyDown != null)
            {
                c.ch = ch;
                KeyDown(this, c);
            }
        }
    }
}
