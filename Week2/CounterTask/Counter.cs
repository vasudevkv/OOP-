using System;

namespace CounterTask
{
    public class Counter
    {
        private long _count;  
        private string _name; 
    

        public Counter(string name)
        {
            _name = name;
           
        }

        public void Increment()
        {
            _count += 1;
        }

        public void Reset()
        {
            _count = 0; 
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public long Ticks
        {
            get { return _count; } 
        }

        public void ResetByDefault()
{
    _count = 21474836319; 
}

    }
}
