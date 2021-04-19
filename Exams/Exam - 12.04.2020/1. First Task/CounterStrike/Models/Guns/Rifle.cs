

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        public Rifle(string name, int bulletsCount) : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            return 10;
        }
    }
}
