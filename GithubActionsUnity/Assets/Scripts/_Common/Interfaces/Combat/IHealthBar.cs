namespace _Common.Interfaces.Combat
{
    public interface IHealthBar
    {
        void Setup(float maxHealth, float currentHealth);
        void SetMaxHealth(float maxHealth);
        void SetCurrentHealth(float currentHealth);
    }
}