using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ColorComboBox.SelectionChanged += OnColorChanged;
            OnColorChanged(null, null);
        }

        private void OnColorChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawingCanvas.Children.Clear();

            string selectedColor = (ColorComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();


            ShapeFactory circleFactory = CreateCircleFactory(selectedColor);
            ShapeFactory squareFactory = CreateSquareFactory(selectedColor);
            ShapeFactory triangleFactory = CreateTriangleFactory(selectedColor);


            var circle = circleFactory.CreateShape();
            var square = squareFactory.CreateShape();
            var triangle = triangleFactory.CreateShape();

            Canvas.SetLeft(circle, 50);
            Canvas.SetTop(circle, 50);
            Canvas.SetLeft(square, 200);
            Canvas.SetTop(square, 50);
            Canvas.SetLeft(triangle, 350);
            Canvas.SetTop(triangle, 50);

            DrawingCanvas.Children.Add(circle);
            DrawingCanvas.Children.Add(square);
            DrawingCanvas.Children.Add(triangle);
        }

        private ShapeFactory CreateCircleFactory(string color)
        {
            return color switch
            {
                "Красный" => new RedCircleFactory(),
                "Чёрный" => new BlackCircleFactory(),
                "Синий" => new BlueCircleFactory(),
                _ => new RedCircleFactory()
            };
        }

        private ShapeFactory CreateSquareFactory(string color)
        {
            return color switch
            {
                "Красный" => new RedSquareFactory(),
                "Чёрный" => new BlackCircleFactory(),
                "Синий" => new BlueCircleFactory(),
                _ => new RedSquareFactory()
            };
        }

        private ShapeFactory CreateTriangleFactory(string color)
        {
            return color switch
            {
                "Красный" => new RedTriangleFactory(),
                "Чёрный" => new BlackCircleFactory(),
                "Синий" => new BlueCircleFactory(),
                _ => new RedTriangleFactory()
            };
        }
    }

    public abstract class ShapeFactory
    {
        public abstract Shape CreateShape();
    }


    public abstract class CircleFactory : ShapeFactory
    {
        public override Shape CreateShape()
        {
            return new Ellipse
            {
                Width = 100,
                Height = 100,
                Fill = GetColor(),
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }
        protected abstract Brush GetColor();
    }
    public class RedCircleFactory : CircleFactory
    {
        protected override Brush GetColor() => Brushes.Red;
    }
    public class BlackCircleFactory : CircleFactory
    {
        protected override Brush GetColor() => Brushes.Black;
    }
    public class BlueCircleFactory : CircleFactory
    {
        protected override Brush GetColor() => Brushes.Blue;
    }


    public abstract class SquareFactory : ShapeFactory
    {
        public override Shape CreateShape()
        {
            return new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = GetColor(),
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }
        protected abstract Brush GetColor();
    }
    public class RedSquareFactory : SquareFactory
    {
        protected override Brush GetColor() => Brushes.Red;
    }
    public class BlackSquareFactory : SquareFactory
    {
        protected override Brush GetColor() => Brushes.Black;
    }
    public class BlueSquareFactory : SquareFactory
    {
        protected override Brush GetColor() => Brushes.Blue;
    }


    public abstract class TriangleFactory : ShapeFactory
    {
        public override Shape CreateShape()
        {
            return new Polygon
            {
                Points = new PointCollection { new Point(50, 0), new Point(0, 100), new Point(100, 100) },
                Fill = GetColor(),
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Width = 100,
                Height = 100,
                Stretch = Stretch.Fill
            };
        }
        protected abstract Brush GetColor();
    }
    public class RedTriangleFactory : TriangleFactory
    {
        protected override Brush GetColor() => Brushes.Red;
    }
    public class BlackTriangleFactory : TriangleFactory
    {
        protected override Brush GetColor() => Brushes.Black;
    }
    public class BlueTriangleFactory : TriangleFactory
    {
        protected override Brush GetColor() => Brushes.Blue;
    }
}