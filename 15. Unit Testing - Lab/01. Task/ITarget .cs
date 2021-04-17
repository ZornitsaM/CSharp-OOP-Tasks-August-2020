

namespace Skeleton
{
    public interface ITarget
    {
        bool IsDead();

        int GiveExperience();

        int TakeAttack(int attackPoint);

    }
}
