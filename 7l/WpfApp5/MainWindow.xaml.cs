using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Line myLine = new Line();
        Ellipse myEllipse = new Ellipse();
        Polygon myPolygon = new Polygon();
        Path path = new Path();
        Rectangle myRect = new Rectangle();
        System.Windows.Threading.DispatcherTimer Timer;
        int currentFrame;
        int currentRow;
        Rectangle an = new Rectangle();

        public MainWindow()
        {
            InitializeComponent();

            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 100);

            Point pos = new Point(20, 80);
            //проверка, лежит ли точка внутри прямоугольника
            if (myRect.RenderedGeometry.Bounds.Contains(pos) == true)
            {
                MessageBox.Show("Точка входит в прямоугольник!");
            }
            //проверка, пересекаются ли прямоугольник и эллипс
            if (myRect.RenderedGeometry.Bounds.IntersectsWith(myEllipse.RenderedGeometry.Bounds) == true)
            {
                MessageBox.Show("Эллипс входит в прямоугольник!");
            }
        }

        private void line_Click(object sender, RoutedEventArgs e)
        {            
            //установка цвета линии
            myLine.Stroke = System.Windows.Media.Brushes.DarkOliveGreen;
            //координаты начала линии
            myLine.X1 = 1;
            myLine.Y1 = 1;
            //координаты конца линии
            myLine.X2 = 250;
            myLine.Y2 = 250;
            //параметры выравнивания в сцене
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.RenderTransform = new SkewTransform(60, 0);
            //толщина линии
            myLine.StrokeThickness = 2;
            //добавление линии в сцену
            scene.Children.Add(myLine);
        }

        private void ell_Click(object sender, RoutedEventArgs e)
        {
            //кисть для заполнения прямоугольника изображением
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            //загрузка изображения и назначение кисти
            ib.ImageSource = new BitmapImage(new Uri(@"D:\sib\WpfApp5\WpfApp5\img\jUUQ0lfsUM8.jpg", UriKind.Absolute));
            myEllipse.Fill = ib;
            //толщина и цвет обводки
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.DarkOliveGreen;
            //размеры овала
            myEllipse.Width = 100;
            myEllipse.Height = 100;
            myEllipse.RenderTransform = new ScaleTransform(2, 0.5);
            //позиция овала
            myEllipse.Margin = new Thickness(100, 1, 0, 0);
            //добавление овала в сцену
            scene.Children.Add(myEllipse);

        }

        private void pol_Click(object sender, RoutedEventArgs e)
        {            
            //установка цвета обводки, цвета заливки и толщины обводки
            myPolygon.Stroke = Brushes.DarkOliveGreen;
            myPolygon.StrokeThickness = 2;
            //кисть для заполнения прямоугольника изображением
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            //загрузка изображения и назначение кисти
            ib.ImageSource = new BitmapImage(new Uri(@"D:\sib\WpfApp5\WpfApp5\img\jUUQ0lfsUM8.jpg", UriKind.Absolute));
            myPolygon.Fill = ib;
            //позиционирование объекта
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            //создание точек многоугольника
            Point Point1 = new Point(300, 0);
            Point Point2 = new Point(400, 0);
            Point Point3 = new Point(400, 100);
            Point Point4 = new Point(350, 200);
            Point Point5 = new Point(300, 100);
            //создание и заполнение коллекции точек
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);
            //установка коллекции точек в объект многоугольник
            myPolygon.Points = myPointCollection;
            //добавление многоугольника в сцену
            scene.Children.Add(myPolygon);

        }

        private void pat_Click(object sender, RoutedEventArgs e)
        {
            path.Stroke = Brushes.DarkOliveGreen;
            path.StrokeThickness = 2;
            //кисть для заполнения прямоугольника изображением
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            //загрузка изображения и назначение кисти
            ib.ImageSource = new BitmapImage(new Uri(@"D:\sib\WpfApp5\WpfApp5\img\jUUQ0lfsUM8.jpg", UriKind.Absolute));
            path.Fill = ib;
            //создание двух сегментов пути при помощи кривых Безье
            //параметры - (первая контрольная точка, вторая контрольная точка, конец кривой)
            BezierSegment bezierCurve1 = new BezierSegment(new Point(400, 0), new Point(400, 50), new Point(450, 90),
            true);
            BezierSegment bezierCurve2 = new BezierSegment(new Point(500, 50), new Point(500, 0), new Point(450, 30), true);
            //создание коллекции сегментов и добавление к ней кривых
            PathSegmentCollection psc = new PathSegmentCollection();
            psc.Add(bezierCurve1);
            psc.Add(bezierCurve2);
            //создание объекта фигуры и установка начальной точки пути
            PathFigure pf = new PathFigure();
            pf.Segments = psc;
            pf.StartPoint = new Point(450, 30);            
            //создание коллекции фигур
            PathFigureCollection pfc = new PathFigureCollection();
            pfc.Add(pf);
            //создание геометрии пути
            PathGeometry pg = new PathGeometry();
            pg.Figures = pfc;
            //создание набора геометрий
            GeometryGroup pathGeometryGroup = new GeometryGroup();
            pathGeometryGroup.Children.Add(pg);
            //
            path.Data = pathGeometryGroup;
            //добавление объекта путь в сцену
            scene.Children.Add(path);

        }

        private void rect_Click(object sender, RoutedEventArgs e)
        {
            //Rectangle myRect = new Rectangle();
            myRect.MouseEnter += MyRect_MouseEnter;
            //установка цвета линии обводки и цвета заливки при помощи коллекции кистей
            myRect.Stroke = Brushes.DarkOliveGreen;
            myRect.StrokeThickness = 2;
            //кисть для заполнения прямоугольника изображением
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            //загрузка изображения и назначение кисти
            ib.ImageSource = new BitmapImage(new Uri(@"D:\sib\WpfApp5\WpfApp5\img\jUUQ0lfsUM8.jpg", UriKind.Absolute));
            myRect.Fill = ib;
            //параметры выравнивания
            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.VerticalAlignment = VerticalAlignment.Center;
            //размеры прямоугольника
            myRect.Height = 100;
            myRect.Width = 100;
            myRect.Margin = new Thickness(1, 100, 0, 0);
            myRect.RenderTransform = new RotateTransform(45, 50, 50);
            //добавление объекта в сцену
            scene.Children.Add(myRect);

        }

        private void MyRect_MouseEnter(object sender, MouseEventArgs e)
        {
            //создание новой кисти
            ImageBrush ib = new ImageBrush();
            //загрузка нового изображения и назначение кисти
            ib.ImageSource = new BitmapImage(new Uri(@"D:\sib\WpfApp5\WpfApp5\img\nItwdnZcGgM.jpg", UriKind.Absolute));
            myRect.Fill = ib;
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            scene.Children.Remove(myLine);
            scene.Children.Remove(myEllipse);
            scene.Children.Remove(myPolygon);
            scene.Children.Remove(path);
            scene.Children.Remove(myRect);
            scene.Children.Remove(an);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var frameCount = 56;
            var frameW = 100;
            var frameH = 100;

            if (currentFrame != 6)
            {
                if (currentRow == 8)
                {
                    currentFrame = 0;
                    currentRow = 0;
                }
                currentFrame = (currentFrame + 1 + frameCount) % frameCount;
            }
            else
            {
                currentFrame = 0;
                currentRow++;
            }

            var frameLeft = currentFrame * frameW;
            var frameTop = currentRow * frameH;
            (an.Fill as ImageBrush).Viewbox = new Rect(frameLeft, frameTop, frameLeft + frameW, frameTop + frameH);
        }

            private void ani_Click(object sender, RoutedEventArgs e)
        {
            an.Height = 100;
            an.Width = 100;

            ImageBrush ib = new ImageBrush();

            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;

            ib.Viewbox = new Rect(0, 0, 200, 100);
            ib.ViewboxUnits = BrushMappingMode.Absolute;

            currentFrame = 0;
            currentRow = 0;

            ib.ImageSource = new BitmapImage(new Uri(@"D:\sib\WpfApp5\WpfApp5\img\VictoriaSprites.gif", UriKind.Absolute));
            an.Fill = ib;

            an.Margin = new Thickness(400, 100, 0, 0);

            scene.Children.Add(an);
            Timer.Start();
        }
    }

    
}
