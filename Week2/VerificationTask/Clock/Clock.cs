using System;

public class Clock
{
    private int MinuteCounter;  
    private int SecondCounter; 

    public Clock()
    {
        MinuteCounter = 0;
        SecondCounter = 0;
    }

    
    public void Tick()
    {
        SecondCounter++;  

        
        if (SecondCounter == 60)
        {
            SecondCounter = 0;
            MinuteCounter++;
        }
    }

    public void Display()
    {
        Console.WriteLine("Minutes: " + MinuteCounter + " Seconds: " + SecondCounter);
    }
}
