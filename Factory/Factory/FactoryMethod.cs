namespace Factory.FactoryMethod
{
    public enum CoordinateSystem{
        Cartesian,
        Polar
    }



    public class Point{
        private double x,y;
        private Point(double a, double b)
        {
            this.x = a;
            this.y = b;
        }
        public static Point NewCartesianPoint(double a,double b){
            return new Point(a,b);
        }
        public static Point NewPolarPoint(double rho, double theta){
            
            return new Point(rho * Math.Cos(theta),rho * Math.Sin(theta));
        }
        public override string ToString()
        {
            return $"My coordinates are x:{x};y{y};";
        }
    }



    
}