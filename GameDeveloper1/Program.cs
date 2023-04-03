Attack Punch = new Attack("IDK", 7);
Attack Fireball = new Attack("IDFK", 15);
Attack Flashbang = new Attack("FLASHBANG", 10);



Enemy DarthVader = new Enemy("Darth Vader", 200);

DarthVader.AddAttack(Punch);
DarthVader.AddAttack(Fireball);
DarthVader.AddAttack(Flashbang);

DarthVader.RandomAttack();


// Console.WriteLine( Punch.Name);
// Console.WriteLine(Punch.DamageAmount);
// Console.WriteLine(Fireball.Name);
// Console.WriteLine(Fireball.DamageAmount);
// Console.WriteLine(Flashbang.Name);
// Console.WriteLine(Flashbang.DamageAmount);