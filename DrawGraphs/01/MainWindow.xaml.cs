using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CreateDiagram(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                width: 1500,
                height: 1000,
                background: Brushes.LightCyan,
                foreground: Brushes.Green
                );
        }

        public void CreateDiagram(List<int> data, int width, int height, SolidColorBrush background, SolidColorBrush foreground)
        {
            mainCanvas.Width = width;
            mainCanvas.Height = height;
            mainCanvas.Background = background;

            float a;
            {
                List<int> list = new List<int>(data);
                list.Sort();
                int maxValue = list[list.Count - 1];
                a = (float)height / (float)maxValue;
            }

            for (int i = 0; i < data.Count; i++)
            {
                Line line = new Line();
                line.Stroke = foreground;
                line.StrokeEndLineCap = PenLineCap.Flat;
                line.StrokeThickness = (width / data.Count) - 2;

                line.X1 = width / data.Count * i + line.StrokeThickness / 2 + 4;
                line.Y1 = height;

                line.X2 = width / data.Count * i + line.StrokeThickness / 2 + 4;
                line.Y2 = (double)(height - data[i] * a);

                mainCanvas.Children.Add(line);
            }
        }
    }
}
