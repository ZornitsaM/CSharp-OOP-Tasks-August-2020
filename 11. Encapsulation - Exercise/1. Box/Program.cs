using System;

namespace PO1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(lenght, width,height);

                double surfaceArea = box.GetSurfaceArea();
                double lateralSurfaceArea = box.GetLateralSurfaceArea();
                double volume = box.GetVolume();

                Console.WriteLine($"Surface Area - {surfaceArea:f2}");
                Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
                Console.WriteLine($"Volume - {volume:f2}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
