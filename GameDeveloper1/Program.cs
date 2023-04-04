Attack Punch = new Attack("RoundHouse to the Face", 20);
Attack Kick = new Attack("Shin Kick", 15);
Attack Tackle = new Attack("Football Tackle", 25);

Attack ShootArrow = new Attack("Arrows Fire", 20);
Attack ThrowingKnife = new Attack("Throwing Knife", 15);

Attack Fireball = new Attack("Flaming Balls", 25);
Attack LightningBolt = new Attack("Smite", 20);
Attack StaffStrike = new Attack("Old fart slams Staff", 10);


MeleeFighter Batman = new MeleeFighter();

RangedFighter Bowman = new RangedFighter(10);

MagicCaster UncleGrandpa = new MagicCaster();

Batman.AddAttack(Punch);
Batman.AddAttack(Kick);
Batman.AddAttack(Tackle);

Bowman.AddAttack(ShootArrow);
Bowman.AddAttack(ThrowingKnife);

UncleGrandpa.AddAttack(Fireball);
UncleGrandpa.AddAttack(LightningBolt);
UncleGrandpa.AddAttack(StaffStrike);



Batman.PerformAttack(Bowman, Kick);
Batman.RageAttack(UncleGrandpa, Tackle);

Bowman.Dash(Bowman);
UncleGrandpa.PerformAttack(Batman, Fireball);
UncleGrandpa.Heal(Bowman);
UncleGrandpa.Heal(UncleGrandpa);





// Console.WriteLine(Batman.Name);
// Console.WriteLine(Batman.Health);

// Console.WriteLine(Bowman.Name);
// Console.WriteLine(Bowman.Health);
// Console.WriteLine(Bowman.Distance);

// Console.WriteLine(UncleGrandpa.Name);
// Console.WriteLine(UncleGrandpa.Health);



// Enemy DarthVader = new Enemy("Darth Vader", 200);

// DarthVader.AddAttack(Punch);
// DarthVader.AddAttack(Fireball);
// DarthVader.AddAttack(Flashbang);

// DarthVader.RandomAttack();


// Console.WriteLine( Punch.Name);
// Console.WriteLine(Punch.DamageAmount);
// Console.WriteLine(Fireball.Name);
// Console.WriteLine(Fireball.DamageAmount);
// Console.WriteLine(Flashbang.Name);
// Console.WriteLine(Flashbang.DamageAmount);