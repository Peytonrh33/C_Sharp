public class MeleeFighter : Enemy
{

    public MeleeFighter() : base("Barbarian", 100)
    {}

    public void RageAttack(Enemy Target, Attack ChosenAttack)
    {
        ChosenAttack.DamageAmount = ChosenAttack.DamageAmount + 10;
        Target.Health = Target.Health - ChosenAttack.DamageAmount;
        Console.WriteLine($"{Target.Name} takes critical hit {ChosenAttack.DamageAmount} and now has {Target.Health} health");
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