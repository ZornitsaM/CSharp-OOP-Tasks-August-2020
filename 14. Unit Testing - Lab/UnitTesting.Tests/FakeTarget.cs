

namespace Skeleton.Tests
{
    public class FakeTarget : ITarget
    {
        public const int DefaulthExpririence = 100;
        public int GiveExperience()
        {
            return DefaulthExpririence;
        }

        public bool IsDead()
        {
            return true;
        }

        public int TakeAttack(int attackPoint)
        {
            throw new System.NotImplementedException();
        }
    }
}
