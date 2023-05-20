using Spectre.Console;
using System.ComponentModel.Design;
using System.Net;
using System.Threading.Channels;

class ProjektKveten
{
    public static void Main()
    {
        try
        {
            var moznost = new List<string>();
            var launcher = new List<string>();
            launcher.Clear();
            //Přidání launcherů
            launcher.Add("Steam");
            launcher.Add("Discord");
            launcher.Add("Spotify");
            launcher.Add("XBOX");
            launcher.Add("Playstation");
            launcher.Add("Origin");
            launcher.Add("Ubisoft");
            launcher.Add("BattleNet");
            launcher.Add("Zpět");

            Console.Clear();
            //Přídání možností - práce s lounchery
            moznost.Add("1. Přidat / změnit launcher login");
            moznost.Add("2. Vypsat určitý launcher login");
            moznost.Add("3. Vypsat všechny launcher loginy");

            bool opakovani = true;
            while (opakovani)
            {
            Zpet:
            //Vypíše možnosti - práce s lounchery
                Console.Clear();
                Console.WriteLine("Launcher Login Saver");
                Console.WriteLine("----------------------");
                Console.WriteLine("Vyber možnost");
                var vyber = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .PageSize(10)
                        .AddChoices(moznost));

                if (vyber == "1. Přidat / změnit launcher login")
                {
                    bool opakovaniZadani = true;

                    while (opakovaniZadani)
                    {
                    //Vypíše launchery
                        Console.Clear();
                        var vyberLauncher = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("Vyber jaký launcher chceš přidat/změnit.")
                                .PageSize(10)
                                .MoreChoicesText("[grey](Vyber šipkami)[/]")
                                .AddChoices(launcher));

                        if (vyberLauncher == "Zpět")
                        {
                            opakovaniZadani = false;
                            goto Zpet;
                        }
                        if (launcher.Contains(vyberLauncher))
                        {
                            //Zadání údajů launcheru
                            Console.WriteLine("Zadej nové údaje:");
                            Console.WriteLine("----------------------");
                            var jmeno = AnsiConsole.Ask<string>("Jméno: ");
                            var heslo = AnsiConsole.Ask<string>("Heslo: ");
                            //Zadá údaje do souboru
                            File.WriteAllText(vyberLauncher + ".txt", "JMÉNO: "+ jmeno +", HESLO: "+ heslo);
                        }
                    }
                }
                else if (vyber == "2. Vypsat určitý launcher login")
                {
                    bool opakovaniProdukt = true;
                    while (opakovaniProdukt)
                    {
                    //Vypíše launchery
                        Console.Clear();
                        var vyberLauncher = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("Vyber jaký launcher chceš vypsat")
                                .Title("----------------------")
                                .PageSize(10)
                                .MoreChoicesText("[grey](Vyber šipkami)[/]")
                                .AddChoices(launcher));

                        try
                        {
                            if (vyberLauncher == "Zpět")
                            {
                                opakovaniProdukt = false;
                                break;
                            }
                            if (launcher.Contains(vyberLauncher))
                            {
                                //Vypíše launcher a údaje
                                string obsahSouboru = File.ReadAllText(vyberLauncher + ".txt");
                                Console.Write(vyberLauncher + " - " + obsahSouboru);
                                Console.ReadKey();
                            }
                        }
                        catch
                        {
                            //Pokud vybere uživatel launcher bez údajů, vypíše program -NEZADÁNO-
                            Console.WriteLine("-NEZADÁNO-");
                            Console.ReadKey();
                        }
                    }
                }
                if (vyber == "3. Vypsat všechny launcher loginy")
                {
                    Console.Clear();
                    //Pro každý launcher vypíše: Launcher a údaje
                    foreach (var vyberLauncher in launcher)
                        try
                        {
                            string obsahSouboru = File.ReadAllText(vyberLauncher + ".txt");
                            Console.Write(vyberLauncher + " - " + obsahSouboru);
                        }
                        catch
                        {
                            //Pokud nejsou zadány údaje u jednoho z launcherů, vypíše program -LAUNCHER NEZADÁN-
                            Console.WriteLine("");
                            Console.WriteLine("-LAUNCHER NEZADÁN-");
                        }
                    Console.ReadLine();
                }
            }
        }
        catch
        {
            Console.WriteLine("Něco se pokazilo!");
        }
    }
}
