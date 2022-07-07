Console.WriteLine("##########################################################");
Console.WriteLine("###################   Szkoła Dotneta   ###################");
Console.WriteLine("####################    Algorytm #3   ####################");
Console.WriteLine("##########################################################");

Console.WriteLine("Enter number to be checked: ");

var input = Console.ReadLine();

if (!int.TryParse(input, out var number))
{
    Console.Write("Invalid input!");
    Environment.Exit(0);
}

if(IsStrobogrammatic(input))
{
    Console.WriteLine("Number is strobogrammatic!");
    Console.WriteLine(isPrime(number)
        ? $"{number} is prime!"
        : $"{number} is not prime!");
}
else
    Console.WriteLine("Number is not strobogrammatic!");


Console.WriteLine("##########################################################");

Console.ReadKey();

bool isPrime(int number)
{
    for (var i = 2; i < number; i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}

bool IsStrobogrammatic(string s)
{
    var rotationMap = new Dictionary<string, string> {{"0", "0"}, {"1", "1"}, {"8", "8"}, {"6", "9"}, {"9", "6"}};

    var left = 0;
    var right = s.Length - 1;

    var check = false;
    while (left <= right)
    {
        if (!rotationMap.ContainsKey(s[left].ToString()) || !rotationMap.ContainsKey(s[right].ToString()))
            return false;
        
        if (!rotationMap.ContainsKey(s[left].ToString()) && s[left].ToString() != rotationMap[s[right].ToString()])
            return true;

        left++;
        right--;
        check = true;
    }

    return check;
}