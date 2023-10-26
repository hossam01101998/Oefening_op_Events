using Oefening_op_Events;

class Program
{
    static void Main()
    {
        Stapel<string> stapel = new Stapel<string>();
        stapel.InhoudGewijzigd += (item, wijziging) =>
        {
            switch (wijziging)
            {
                case WijzigingType.Toevoeging:
                    Console.WriteLine($"Item toegevoegd: {item}");
                    break;
                case WijzigingType.Verwijdering:
                    Console.WriteLine($"Item verwijderd: {item}");
                    break;
                case WijzigingType.Leegmaking:
                    Console.WriteLine("Stapel geleegd");
                    break;
            }
        };
        //last in first out. Het gaat de laatste toegevoegde item verwijderen.

        stapel.Toevoegen("Volkswagen");
        stapel.Toevoegen("Mazda");
        stapel.Toevoegen("BMW");
        stapel.Verwijderen();
        stapel.Leegmaken();
    }
}
