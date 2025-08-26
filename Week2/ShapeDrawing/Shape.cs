using System;

namespace ShapeDrawing
{
    public class Shape
    {
        private string _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;

    
        public Shape(int param)
        {
            
            _color = "Color.Chocolate"; 
            _x = 0.0f;
            _y = 0.0f;
            _width = 100 + param;
            _height = 100 + param;
        }

        
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }


        public void Draw()
        {
            Console.WriteLine($"Shape Details:");
            Console.WriteLine($"Color: {_color}");
            Console.WriteLine($"Position: ({_x}, {_y})");
            Console.WriteLine($"Width: {_width}, Height: {_height}");
        }

        public bool IsAt(int xInput, int yInput)
        {
            return (xInput > _x && xInput < _x + _width) &&
                   (yInput > _y && yInput < _y + _height);
        }
    }
}
