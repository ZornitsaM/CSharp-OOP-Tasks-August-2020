namespace Computers
{
    public class Part
    {
        //OK
        public Part(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
