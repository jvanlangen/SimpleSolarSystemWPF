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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SolarSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _sunSize = 70;
        private double _earthSize = 20;
        private double _moonSize = 10;

        public MainWindow()
        {
            InitializeComponent();

            var sphere = MeshPrimitives.Sphere(2, 1);


            // sun
            var sunMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.Yellow));


            var sunScaleRotate = new Transform3DGroup();

            var sunRotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            sunScaleRotate.Children.Add(new ScaleTransform3D(new Vector3D(_sunSize, _sunSize, _sunSize)));
            sunScaleRotate.Children.Add(new RotateTransform3D(sunRotation));

            var sunModel = new GeometryModel3D
            {
                Material = sunMaterial,
                Geometry = sphere,
                Transform = sunScaleRotate
            };
            var sunGroup = new Model3DGroup();

            sunGroup.Children.Add(sunModel);

            var visual = new ModelVisual3D { Content = sunGroup };
            Viewport3D.Children.Add(visual);


            // earth

            var earthMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.Blue));

            var earthScaleRotate = new Transform3DGroup();

            var earthRotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            earthScaleRotate.Children.Add(new ScaleTransform3D(new Vector3D(_earthSize, _earthSize, _earthSize)));
            earthScaleRotate.Children.Add(new RotateTransform3D(earthRotation));

            var earthModel = new GeometryModel3D
            {
                Material = earthMaterial,
                Geometry = sphere,
                Transform = earthScaleRotate 
            };

            var earthGroup = new Model3DGroup();
            earthGroup.Children.Add(earthModel);

            var earthArroundSunRotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);

            var transformGroup = new Transform3DGroup();
            transformGroup.Children.Add(new TranslateTransform3D(150, 0, 0));
            transformGroup.Children.Add(new RotateTransform3D(earthArroundSunRotation));

            earthGroup.Transform = transformGroup;

            sunGroup.Children.Add(earthGroup);




            // moon

            var moonMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.Gray));

            var moonScaleRotate = new Transform3DGroup();

            var moonRotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            moonScaleRotate.Children.Add(new ScaleTransform3D(new Vector3D(_moonSize, _moonSize, _moonSize)));
            moonScaleRotate.Children.Add(new RotateTransform3D(moonRotation));


            var moonModel = new GeometryModel3D
            {
                Material = moonMaterial,
                Geometry = sphere,
                Transform = moonScaleRotate
            };
            var moonGroup = new Model3DGroup();
            moonGroup.Children.Add(moonModel);

            var moonArroundEarthRotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);

            var moonTransformGroup = new Transform3DGroup();
            moonTransformGroup.Children.Add(new TranslateTransform3D(40, 0, 0));
            moonTransformGroup.Children.Add(new RotateTransform3D(moonArroundEarthRotation));

            moonGroup.Transform = moonTransformGroup;

            earthGroup.Children.Add(moonGroup);

            CompositionTarget.Rendering += (s, ee) =>
            { 
                earthRotation.Angle -= 2.0;
                earthArroundSunRotation.Angle += 1.0;

                moonRotation.Angle -= 4.0;
                moonArroundEarthRotation.Angle += 2.0;

                sunRotation.Angle -= 1.0;
            };

        }
    }
}
