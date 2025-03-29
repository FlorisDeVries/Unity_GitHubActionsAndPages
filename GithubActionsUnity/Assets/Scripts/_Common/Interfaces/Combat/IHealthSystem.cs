using _Common.Abilities;
using Combat;

namespace _Common.Interfaces.Combat
{
    public interface IHealthSystem
    {
        void Hit(AbilityInfo ability);
    }
}