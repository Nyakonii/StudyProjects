// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
int randomizer = DateTime.Now.Second;

Console.WriteLine("Insert Minimum");
string? minS = Console.ReadLine();
Console.WriteLine("Insert Maximum:");
string? maxS = Console.ReadLine();

int MIN = Convert.ToInt32(minS);
int MAX = Convert.ToInt32(maxS);

int output = 1;
int rounds = 5;

int LowerOut()
{
    int valLowered = output;
    int mod = DateTime.Now.Millisecond;
    string modS = Convert.ToString(mod);
    int remove = Convert.ToInt32(modS);
    while (valLowered > MAX)
    {
        valLowered = valLowered - 2 * remove;
        Console.WriteLine($"Lowering to {valLowered} by {2 * remove}");
    }
    
    return valLowered;
}

int RaiseOut()
{
    int valRaised = output;
    int mod = DateTime.Now.Millisecond;
    var modS = Convert.ToString(mod);
    int add = Convert.ToInt32(modS);
    while (valRaised < MAX)
    {
        valRaised = valRaised + 2 * add;
        Console.WriteLine($"Raising to {valRaised} by {2 * add}");
    }
    return valRaised;
}

for (int i = rounds; i > 0; i--)
{
    rounds = i;

    output += output + rounds + randomizer;

    if (output > MAX)
    {
        output = LowerOut();
    }

    if (output < MIN)
    {
        output = RaiseOut();
    }
    
    if (rounds == 0)
    {
        break;
    }
}

while (output > MAX)
{
    output = LowerOut();
    while (output < MIN)
    {
        output = RaiseOut();
    }
}

Random number = new Random();

Console.WriteLine($"Built-In: {number.Next(MIN, MAX)}");
Console.WriteLine($"My Implementation: {output}");