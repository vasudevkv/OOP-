using SplashKitSDK;
using System;
using System.IO;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;

            int lineCount = 0;
            int maxLines = 5;

            do
            {
                SplashKit.ProcessEvents();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                    lineCount = 0;
                }
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape? newShape = null;
                    float mouseX = SplashKit.MouseX();
                    float mouseY = SplashKit.MouseY();

                    switch (kindToAdd)
                    {
                        case ShapeKind.Rectangle:
                            newShape = new MyRectangle();
                            break;

                        case ShapeKind.Circle:
                            newShape = new MyCircle();
                            break;

                        case ShapeKind.Line:
                            if (lineCount < maxLines)
                            {
                                newShape = new MyLine(Color.Red, mouseX, mouseY, mouseX + 100, mouseY + 20 * lineCount);
                                lineCount++;
                            }
                            break;
                    }

                    if (newShape != null)
                    {
                        newShape.X = mouseX;
                        newShape.Y = mouseY;
                        myDrawing.AddShape(newShape);
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape shape in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    try
                    {
                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string filePath = Path.Combine(desktopPath, "TestDrawing.txt");
                        myDrawing.Save(filePath);
                        Console.WriteLine("Drawing saved to " + filePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saving file: " + ex.Message);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string filePath = Path.Combine(desktopPath, "TestDrawing.txt");
                        myDrawing.Load(filePath);
                        Console.WriteLine("Drawing loaded from " + filePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading file: " + ex.Message);
                    }
                }

    
                if (SplashKit.KeyTyped(KeyCode.AKey))
                {
                    Random random = new Random();
                    int shapeCount = random.Next(5, 15);

                    for (int i = 0; i < shapeCount; i++)
                    {
                        Shape? newShape = null;
                        float randomX = random.Next(50, window.Width - 100);
                        float randomY = random.Next(50, window.Height - 100);
                        Color randomColor = SplashKit.RandomColor();

                        int shapeType = random.Next(0, 3);
                        switch (shapeType)
                        {
                            case 0:
                                newShape = new MyRectangle(randomColor, randomX, randomY,
                                    random.Next(20, 100), random.Next(20, 100));
                                break;
                            case 1:
                                newShape = new MyCircle(randomColor, randomX, randomY,
                                    random.Next(10, 50));
                                break;
                            case 2:
                                float endX = randomX + random.Next(-100, 100);
                                float endY = randomY + random.Next(-100, 100);
                                newShape = new MyLine(randomColor, randomX, randomY, endX, endY);
                                break;
                        }

                        if (newShape != null)
                        {
                            myDrawing.AddShape(newShape);
                        }
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.NKey))
                {
                    DrawFirstName(myDrawing, 100, 200, SplashKit.RandomColor());
                }

                if (SplashKit.KeyTyped(KeyCode.ZKey))
                {
                    ScaleDownShapes(myDrawing);
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
private static void DrawFirstName(Drawing drawing, float x, float y, Color letterColor)
{
    int letterSpacing = 65;
    int lineThickness = 8;

    int height = 150;
    int width = 50;
    float currentX = x;

    int vThickness = 7; 
    int vSpacing = 2;  

    for (int t = -vThickness / 2; t <= vThickness / 2; t++)
    {
        float offset = t * vSpacing;
        drawing.AddShape(new MyLine(letterColor, currentX + 5 + offset, y, currentX + width / 2 + offset, y + height));
        drawing.AddShape(new MyLine(letterColor, currentX + width - 5 + offset, y, currentX + width / 2 + offset, y + height));
    }
    currentX += letterSpacing;

    drawing.AddShape(new MyRectangle(letterColor, currentX, y + 30, lineThickness, height - 30));
    drawing.AddShape(new MyRectangle(letterColor, currentX + width, y + 30, lineThickness, height - 30));
    drawing.AddShape(new MyRectangle(letterColor, currentX, y + 30, width + lineThickness, lineThickness));
    drawing.AddShape(new MyRectangle(letterColor, currentX, y + 90, width + lineThickness, lineThickness));
    currentX += letterSpacing;

    drawing.AddShape(new MyRectangle(letterColor, currentX, y, width, lineThickness)); 
    drawing.AddShape(new MyRectangle(letterColor, currentX, y + height / 2 - 8, width, lineThickness)); 
    drawing.AddShape(new MyRectangle(letterColor, currentX, y + height - lineThickness, width, lineThickness)); 
    drawing.AddShape(new MyRectangle(letterColor, currentX, y, lineThickness, height / 2)); 
    drawing.AddShape(new MyRectangle(letterColor, currentX + width - lineThickness, y + height / 2, lineThickness, height / 2)); 
    currentX += letterSpacing;

    drawing.AddShape(new MyRectangle(letterColor, currentX, y, lineThickness, height - 10));
    drawing.AddShape(new MyRectangle(letterColor, currentX + width, y, lineThickness, height - 10));
    drawing.AddShape(new MyRectangle(letterColor, currentX, y + height - 10, width + lineThickness, lineThickness));
    currentX += letterSpacing;

    drawing.AddShape(new MyRectangle(letterColor, currentX, y, lineThickness, height));
    drawing.AddShape(new MyRectangle(letterColor, currentX, y, width, lineThickness));
    drawing.AddShape(new MyRectangle(letterColor, currentX, y + height - lineThickness, width, lineThickness));
    drawing.AddShape(new MyRectangle(letterColor, currentX + width, y + 10, lineThickness, height - 20));
    currentX += letterSpacing;

    drawing.AddShape(new MyRectangle(letterColor, currentX, y, lineThickness, height));
    drawing.AddShape(new MyRectangle(letterColor, currentX, y, width, lineThickness));
    drawing.AddShape(new MyRectangle(letterColor, currentX, y + height / 2 - 8, width, lineThickness));
    drawing.AddShape(new MyRectangle(letterColor, currentX, y + height - lineThickness, width, lineThickness));
    currentX += letterSpacing;

    for (int t = -vThickness / 2; t <= vThickness / 2; t++)
    {
        float offset = t * vSpacing;
        drawing.AddShape(new MyLine(letterColor, currentX + 5 + offset, y, currentX + width / 2 + offset, y + height));
        drawing.AddShape(new MyLine(letterColor, currentX + width - 5 + offset, y, currentX + width / 2 + offset, y + height));
    }

}

                private static void ScaleDownShapes(Drawing drawing)
        {
            foreach (Shape shape in drawing.AllShapes)
            {
                if (shape is MyRectangle rect)
                {
                    rect.Width = (int)(rect.Width * 0.8);
                    rect.Height = (int)(rect.Height * 0.8);
                }
                else if (shape is MyCircle circle)
                {
                    circle.Radius = (int)(circle.Radius * 0.8);
                }
                else if (shape is MyLine line)
                {
                    float midX = (line.X + line.EndX) / 2;
                    float midY = (line.Y + line.EndY) / 2;

                    line.X = line.X + (midX - line.X) * 0.2f;
                    line.Y = line.Y + (midY - line.Y) * 0.2f;
                    line.EndX = line.EndX + (midX - line.EndX) * 0.2f;
                    line.EndY = line.EndY + (midY - line.EndY) * 0.2f;
                }
            }
        }
    }
}