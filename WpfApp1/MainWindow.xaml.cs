using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1

{
    public partial class MainWindow : Window
    {
        private IShapeFactory currentFactory;

        public MainWindow()
        {
            InitializeComponent();
            ColorComboBox.SelectionChanged += OnColorChanged;
            currentFactory = new RedFactory();
            DrawShapes();
        }

        private void OnColorChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedColor = (ColorComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            currentFactory = selectedColor switch
            {
                "Красный" => new RedFactory(),
                "Чёрный" => new BlackFactory(),
                "Синий" => new BlueFactory(),
                _ => new RedFactory()
            };

            DrawShapes();
        }

        private void DrawShapes()
        {
            DrawingCanvas.Children.Clear();

            var circle = currentFactory.CreateCircle();
            var square = currentFactory.CreateSquare();
            var triangle = currentFactory.CreateTriangle();

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
    }

    public interface IShapeFactory
    {
        Shape CreateCircle();
        Shape CreateSquare();
        Shape CreateTriangle();
    }

    public class RedFactory : IShapeFactory
    {
        public Shape CreateCircle() => new Ellipse
        {
            Width = 100,
            Height = 100,
            Fill = Brushes.Red,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        public Shape CreateSquare() => new Rectangle
        {
            Width = 100,
            Height = 100,
            Fill = Brushes.Red,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        public Shape CreateTriangle() => new Polygon
        {
            Points = new PointCollection { new Point(50, 0), new Point(0, 100), new Point(100, 100) },
            Fill = Brushes.Red,
            Stroke = Brushes.Black,
            StrokeThickness = 2,
            Width = 100,
            Height = 100,
            Stretch = Stretch.Fill
        };
    }

    public class BlackFactory : IShapeFactory
    {
        public Shape CreateCircle() => new Ellipse
        {
            Width = 100,
            Height = 100,
            Fill = Brushes.Black,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        public Shape CreateSquare() => new Rectangle
        {
            Width = 100,
            Height = 100,
            Fill = Brushes.Black,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        public Shape CreateTriangle() => new Polygon
        {
            Points = new PointCollection { new Point(50, 0), new Point(0, 100), new Point(100, 100) },
            Fill = Brushes.Black,
            Stroke = Brushes.Black,
            StrokeThickness = 2,
            Width = 100,
            Height = 100,
            Stretch = Stretch.Fill
        };
    }

    public class BlueFactory : IShapeFactory
    {
        public Shape CreateCircle() => new Ellipse
        {
            Width = 100,
            Height = 100,
            Fill = Brushes.Blue,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        public Shape CreateSquare() => new Rectangle
        {
            Width = 100,
            Height = 100,
            Fill = Brushes.Blue,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        public Shape CreateTriangle() => new Polygon
        {
            Points = new PointCollection { new Point(50, 0), new Point(0, 100), new Point(100, 100) },
            Fill = Brushes.Blue,
            Stroke = Brushes.Black,
            StrokeThickness = 2,
            Width = 100,
            Height = 100,
            Stretch = Stretch.Fill
        };
    }
}