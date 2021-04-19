

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            //todo
            //this.bulletsCount -= 1;
            return 1;
        }
    }
}
