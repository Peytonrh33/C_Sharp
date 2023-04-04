public class RangedFighter : Enemy 
{
    public int Distance;

    public RangedFighter(int distance =5) : base("Bowman", 80)
    {
        Distance = distance;
    }

    public void Dash(RangedFighter Target)
    {
        Target.Distance = Target.Distance + 10;
        Console.WriteLine($"{Target.Name} used dash and distance is now {Target.Distance}");
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