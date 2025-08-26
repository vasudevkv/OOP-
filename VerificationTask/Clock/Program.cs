using System;

class Program
{
    static void Main()
    {
        
        Clock myClock = new Clock();

        
        for (int i = 0; i < 100; i++) 
        {
            myClock.Tick();   
            myClock.Display(); 
        }
    }
}
