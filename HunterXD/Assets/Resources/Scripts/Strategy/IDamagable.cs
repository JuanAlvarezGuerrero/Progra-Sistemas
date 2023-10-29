
public interface IDamagable
{
    int MaxLife { get; }
    int CurrentLife { get; }
    void TakeDamage(int damage);
}
