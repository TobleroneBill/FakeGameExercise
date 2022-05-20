//inital variables
int manitcoreHp = 10;
int cityHp = 15 ;
int round = 1;
int cannonDamage = 1;
Console.Title = "1V1";

//Gets P1 input Location
Console.Write("please input a distance 0-100: ");
int userDist = Convert.ToInt32(Console.ReadLine());
userDist = ValidCheck(userDist);                    //checks number is valid
Console.Clear();

Console.WriteLine("Player 2, Its your turn.");      //game loop
while (cityHp > 0 && manitcoreHp > 0) {
    Console.WriteLine("______________________________________________________________________________");
    Console.WriteLine($"STATUS: Round{round}    City:{cityHp}/15    Manticore:{manitcoreHp}/10");
    calculateDamage(round);
    Console.Write("Enter Desired Cannon Range: ");
    Fire(Convert.ToInt32(Console.ReadLine()), userDist);
    round++;
}


//End Sequence. checks who won.
if (manitcoreHp <= 0)
{
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.WindowWidth += 1;
    Console.WriteLine("Well Done! You destoryed the manticore and got all da bitches");
    Console.WriteLine($"It only took you {round} rounds to pwn this N00b #GAMER");
    Console.WindowWidth -= 1;
}
else {
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.WindowWidth += 1;
    Console.WriteLine("OH NO! You were destoryed by the manticore and now you GOT NO BITCHES");
    Console.WindowWidth -= 1;
}

//compares cannon location vs manticore location. deals damage if hits
void Fire(int location, int target) {
    ValidCheck(location);
    cityHp--;
    if (location < target)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Missed, Shot was too low!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    else if (location > target)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Missed, Shot was too high!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    else {
        manitcoreHp -= cannonDamage;
        Console.WindowWidth += 1;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine($"Nice! You did {cannonDamage} damage, leaving the enemy at {manitcoreHp}HP!");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WindowWidth -= 1;
    }
}

//Uses FizzBuzz to calculate the damage
void calculateDamage(int round) {
    if (round % 15 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        cannonDamage = 10;
    }
    else if (round % 5 == 0 || round % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        cannonDamage = 3;
    }
    else {
        Console.ForegroundColor = ConsoleColor.White;
        cannonDamage = 1; }
    Console.WindowWidth += 1;
    Console.WriteLine($"The Cannon is expected to deal {cannonDamage} damage this round.");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WindowWidth -= 1;
}

//checks input is in 0-100 range
int ValidCheck(int input)
{
    int check = input;
    while (check < 0 || check > 100) {
        Console.WriteLine($"{check} is not valid. Please input a valid number");
        check = Convert.ToInt32(Console.ReadLine());
    }
    return check;
}
