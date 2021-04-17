

namespace Skeleton.Tests
{
    public class FakeWeapon : IWeapon
    {
        public void Attack(ITarget target)
        {
            throw new System.NotImplementedException();
        }
    }
}
