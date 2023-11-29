namespace Factory.FactoryPattern
{
    public enum CoordinateSystem{
        Cartesian,
        Polar
    }



    public class Point{
        private double x,y;
        public Point(double a, double b)
        {
            this.x = a;
            this.y = b;
        }
        
        public override string ToString()
        {
            return $"My coordinates are x:{x};y{y};";
        }
    }


    public static class PointFactory{
        public static Point NewCartesianPoint(double a,double b){
            return new Point(a,b);
        }
        public static Point NewPolarPoint(double rho, double theta){
            
            return new Point(rho * Math.Cos(theta),rho * Math.Sin(theta));
        }
    }
}