// ovdje napisati kod
void Izracun(int broj, out int zbrojDjeljivihsa3, out int zbrojDjeljivihsa7)
{
    if (broj < 1 || broj > 1000)
        throw new ArgumentOutOfRangeException("Broj je izvan raspona");
    zbrojDjeljivihsa3 = 0;
    zbrojDjeljivihsa7 = 0;
    for (int i = 1; i <= broj; i++)
    {
        if(i % 3 == 0)
            zbrojDjeljivihsa3 += i;
        if(i % 7 == 0)
            zbrojDjeljivihsa7 += i;
    }
}

bool nastavi = true;
do
{
    try
    {
        Console.Write("Unesi broj (1-1000): ");
        string unos = Console.ReadLine();
        if(string.IsNullOrEmpty(unos))
            nastavi = false;
        else
        {
            bool ok = int.TryParse(unos, out int broj);
            if(!ok)
            {
                Console.WriteLine("Pogrešan format broja");
                continue;
            }
            Izracun(broj, out int zbroj3, out int zbroj7);
            Console.WriteLine($"Zbroj brojeva djeljivih sa 3 je {zbroj3} a zbroj brojeva djeljivih sa 7 je {zbroj7}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Pogreška: {ex.Message}");
    }
}
while (nastavi);