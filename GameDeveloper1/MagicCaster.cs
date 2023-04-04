public class MagicCaster : Enemy
{

    public MagicCaster() : base("Mage", 80)
    {

    }

    public void Heal(Enemy Target)
    {
        Target.Health = Target.Health + 40;
        Console.WriteLine($"{Target.Name} was healed by Mage and now has {Target.Health} health");
    }

    public override void AddAttack(Attack attack)
    {
        base.AddAttack(attack);
    }

    public override void RandomAttack()
    {
        base.RandomAttack();
    }
}