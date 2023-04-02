//listid on keerulised andmestruktuurid
//listid on paindlikumad kui massiivid, listis voivad olla ainult uhte tuupi andmed

string folderPath = @"C:\Users\Admin\Documents\Sigrit\Kool\teinekursus\Kevad\Programmeerimine\data"; //kuhu kausta soovid faili luua
string fileName = "shoppingList.txt"; //kirjutame loodava faili nime ja tuubi
string filePath = Path.Combine(folderPath, fileName); //faili asukoht
List<string> myShoppingList = new List<string>(); //deklareerib shoppingListi


if (File.Exists(filePath)) //kontrollib kas fail asub samal asukohal nagu filePath? kui fail eksisteerib siis tagastab "true" kui ei eksisteeri siis tagastab "false"
{
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);  //salvestan faili andmeid, mida salvestasin myShoppingListi
}
else 
{
    File.Create(filePath).Close(); //loob ise faili ja paneb selle hiljem kinni. kindlasti tuleb fail kinni panna, sest muidu ei saa hiljem sinna andmeid lisada!!!
    Console.WriteLine($"File {fileName} has been created.");
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}

ShowItemsFromList(myShoppingList);
static List<string> GetItemsFromUser() //funktsioon
{
    List<string> userList = new List<string>(); //roheline "List" on siin reas klass!

    while (true) //ilma vahemaluta ei saa andmeid sisestada/salvestada vms
    {
        Console.WriteLine("Add an item (add)/ Exit (exit):"); //kusime kasutaja kaest kas ta soovib midagi lisada voi soovib lahkuda
        string userChoice = Console.ReadLine(); //loeb kasutaja tehtud valikut ja salvestab selle valiku "userChoice" muutujasse

        if (userChoice == "add") //kontrollime kui kasutaja valik on lisada midagi ehk "add"
        {
            Console.WriteLine("Enter an item:"); //palume kasutajal sisestada item listi
            string userItem = Console.ReadLine();  //salvestame sisestatud itemi "userItem" muutujasse
            userList.Add(userItem); //lisab "userItem" shopping listi sisse
        }
        else
        {
            Console.WriteLine("Bye!"); //siis kui kasutaja valib "exit"
            break; //ei lase programmil faili sisse tagasi minna
        }
    }
    return userList; //andmed tuleb kindlasti tagastama vahemalusse, et saaks nendega hiljem tood teha
}

static void ShowItemsFromList(List<string> someList) //see funktsioon kuvab itemeid
{
    Console.Clear(); //kustutab tekstist konsoolist ara

    int listLength = someList.Count; //listi omadus, naitab mitu elementi on listis, listi pikkus?
    Console.WriteLine($"You have added {listLength} items to your shopping list."); //kirjutab valja, mitu itemit on listi lisatud

    int i = 1; //deklareerisime valjaspool "foreach", et see oleks vahemalus olemas enne kui "foreach" hakkab toole

    foreach (string item in someList) //igale elemendile, mis asuvad myShoppingListis rakendab jargmise kasu
    {
        Console.WriteLine($"{i}. {item}"); //kuvab, mis asjad listis on, nummerdatud kujul
        i++;
    }
}


