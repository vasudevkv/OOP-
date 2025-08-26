// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace ShapeDrawing
{
    class Program
    {
        static void Main()
        {
            // Step 1: Create a Shape object
            Shape myShape = new Shape(319); 

            // Step 2: Draw the shape
            myShape.Draw();

            // Step 3: Check if a point is inside the shape
            Console.WriteLine("Is point (50, 50) inside the shape? " + myShape.IsAt(50, 50));
            Console.WriteLine("Is point (200, 200) inside the shape? " + myShape.IsAt(200, 200));

            

        }
    }
}

