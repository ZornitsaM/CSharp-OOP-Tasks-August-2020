

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int OrnamentComfort = 1;
        private const decimal OrnamentPrise = 5;

        public Ornament() 
            : base(OrnamentComfort, OrnamentPrise)
        {
            
        }
    }
}
