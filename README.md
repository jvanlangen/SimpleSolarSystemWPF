Just a simple solar system in WPF Viewport3D

![Screenshot of SolarSystem](https://github.com/jvanlangen/SimpleSolarSystemWPF/blob/main/Images/SolarSystemImage.png?raw=true)

    sunGroup : Model3DGroup
     |
     +- Children
         |
         +- sunModel : GeometryModel3D
 	     |	 |
 	     |	 +- Geometry = sphere : MeshGeometry3D
 	     |	 |
 	     |	 +- Material = sunMaterial : DiffuseMaterial
 	     |	 |
 	     |	 +- Transform = sunScaleRotate : Transform3DGroup
 	     |	                 |
 	     |	                 +- ScaleTransform : ScaleTransform3D
 	     |	                 |
 	     |	                 +- sunRotation : AxisAngleRotation3D
 	     |	
         +- earthGroup : Model3DGroup
             |
             +- Transform = earthTransformGroup : Transform3DGroup
             |               |
             |               +- ScaleTransform : ScaleTransform3D
             |               |
             |               +- earthArroundSunRotation : AxisAngleRotation3D
             |
             +- Children
                 |
                 +- earthModel : GeometryModel3D
 	             |	 |
 	             |	 +- Geometry = sphere : MeshGeometry3D
 	             |	 |
 	             |	 +- Material = earthMaterial : DiffuseMaterial
 	             |	 |
 	             |	 +- Transform = earthScaleAndRotate : Transform3DGroup
 	             |	                 |
 	             |	                 +- ScaleTransform : ScaleTransform3D
 	             |	                 |
 	             |	                 +- earthRotation : AxisAngleRotation3D
                 |
                 +- moonGroup : Model3DGroup
                     |
                     +- Transform = moonTransformGroup : Transform3DGroup
                     |               |
                     |               +- ScaleTransform : ScaleTransform3D
                     |               |
                     |               +- moonArroundEarthRotation : AxisAngleRotation3D
                     |
                     +- Children
                         |
                         +- moonModel : GeometryModel3D
 	                  	     |
 	                  	     +- Geometry = sphere : MeshGeometry3D
 	                  	     |
 	                  	     +- Material = moonMaterial : DiffuseMaterial
 	                  	     |
 	                  	     +- Transform = moonScaleAndRotate : Transform3DGroup
 	                  	                     |
 	                  	                     +- ScaleTransform : ScaleTransform3D
 	                  	                     |
 	                  	                     +- moonRotation : AxisAngleRotation3D
