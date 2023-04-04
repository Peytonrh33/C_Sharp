public class Enemy
{
    public string Name;
    public int Health;
    public List<Attack> AttackList = new List<Attack>();

    public Enemy(string name, int health = 100)
    {
        Name = name;
        Health = health;
    }

    public void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        Target.Health = Target.Health - ChosenAttack.DamageAmount;
    // Write some logic here to reduce the Targets health by your Attack's DamageAmount
    Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}!!");
    }

    public virtual void AddAttack(Attack attack)
    {
        AttackList.Add(attack);
    }

    public virtual void RandomAttack()
    {
        if(AttackList.Count > 0){
            Random RandAttack = new Random();
            int i = RandAttack.Next(0, AttackList.Count);
            Attack attack = AttackList[i];
            Console.WriteLine($"{Name} used {attack.Name} and done {attack.DamageAmount} damage");
        }
        else{
            Console.WriteLine("He missed gosh darnit");
        }
    }
}