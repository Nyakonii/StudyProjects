// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");
long randomizer = DateTime.Now.Second;

Console.WriteLine("Insert Minimum");
string? minS = Console.ReadLine();
Console.WriteLine("Insert Maximum:");
string? maxS = Console.ReadLine();

int MIN = Convert.ToInt32(minS);
int MAX = Convert.ToInt32(maxS);

long output = 1;
int rounds = 5;

long LowerOut()
{
    long valLowered = output;
    while (valLowered > MAX)
    {
        long remove = DateTime.Now.Second;
        valLowered = valLowered / remove;
        Console.WriteLine($"Lowering to {valLowered} by {2 * remove}");
    }
    
    return valLowered;
}

long RaiseOut()
{
    long valRaised = output;
    while (valRaised < MIN)
    {
        long add = DateTime.Now.Second;
        valRaised = valRaised * add;
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