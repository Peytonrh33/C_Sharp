class Enemy
{
    public string Name;
    public int Health;
    public List<Attack> AttackList = new List<Attack>();

    public Enemy(string name, int health = 100)
    {
        Name = name;
        Health = health;
    }

    public void AddAttack(Attack attack)
    {
        AttackList.Add(attack);
    }

    public void RandomAttack()
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