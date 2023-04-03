// See https://aka.ms/new-console-template for more information

// int[] first = {0,1,2,3,4,5,6,7,8,9};

// Console.WriteLine(first[7]);

string[] second = {"Tim", "Martin", "Nikki", "Sara"};

// Console.WriteLine(second[3]);

// bool[] arr3 = new bool[10]; 
// arr3[0] = true;
// arr3[1] = false;
// arr3[2] = true;
// arr3[3] = false;
// arr3[4] = true;
// arr3[5] = false;
// arr3[6] = true;
// arr3[7] = false;
// arr3[8] = true;
// arr3[9] = false;

List<string> iceCream = new List<string>();
iceCream.Add("Chocolate");
iceCream.Add("Vanilla");
iceCream.Add("Strawberry");
iceCream.Add("Cherry Garcia");
iceCream.Add("Butter Pecan");

// iceCream.RemoveAt(2);

// Console.WriteLine(iceCream.Count);

// Console.WriteLine(iceCream[2]);


Dictionary<string, string> dict = new Dictionary<string,string>();

for(int i = 0; i<second.Length; i++){
    Random randNum = new Random();
    dict.Add(second[i], iceCream[randNum.Next(0,4)]);
}
foreach(KeyValuePair<string,string> entry in dict){
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}
