// See https://aka.ms/new-console-template for more information
using Develop;
using System.Text;

List<Cars> Main()
{
    string workingDirectory = Environment.CurrentDirectory;
    string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, "mtcars.csv");
    StreamReader reader = new StreamReader(path);
    List<Cars> list = new List<Cars>();
    bool f = true;
    int t = 1;
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var values = line.Split(',');

        if (f == false)
        {
            Cars temp = new Cars(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11]);
            list.Add(temp);
        } else
        {
            f = false;
            foreach (var c in values)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine("");
        }
    }
    foreach (Cars item in list)
    {
        Console.WriteLine("Entry " + t + ": " + item.model + " " + item.mpg + " " + item.cyl + " " + item.disp + " " + item.hp + " " + item.drat + " " + item.wt + " " + item.qsec + " " + item.vs + " " + item.am + " " + item.gear + " " + item.carb);
        t++;
    }
    reader.Close();
    return list;
}

List<Cars> Edit(List<Cars> c)
{
    Console.WriteLine("What Entry do you want to edit? ");
    try
    {
        int a = Int32.Parse(Console.ReadLine());
        if (a <= 32)
        {
            if (a == 32)
            {
                Console.WriteLine("0");
            } else
            {
                Cars item = c[a-1];
                Console.WriteLine("Here is Entry " + a + ": " + item.model + " " + item.mpg + " " + item.cyl + " " + item.disp + " " + item.hp + " " + item.drat + " " + item.wt + " " + item.qsec + " " + item.vs + " " + item.am + " " + item.gear + " " + item.carb);
                Console.WriteLine("What do you want to edit this row?");
                Console.WriteLine("Please Edit it like this: " + item.model + "," + item.mpg + "," + item.cyl + "," + item.disp + "," + item.hp + "," + item.drat + "," + item.wt + "," + item.qsec + "," + Convert.ToInt32(item.vs) + "," + Convert.ToInt32(item.am) + "," + item.gear + "," + item.carb);
                string input = Console.ReadLine();
                int num = 0;
                foreach (char l in input)
                if (l == ',')
                    {
                        num++;
                    }
                if(num == 11)
                {
                    SaveCSVListEdit(c, a, input);
                } else
                {
                    //error
                }
            }
        }
    } catch {
        //error
    }
    return c;
}

void SaveCSVListEdit(List<Cars> c, int a, string input)
{
    string workingDirectory = Environment.CurrentDirectory;
    string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, "mtcars.csv");
    var str = new StreamWriter(path);
    var text = "model,mpg,cyl,disp,hp,drat,wt,qsec,vs,am,gear,carb";
    str.WriteLine(text);
    str.Flush();
    int i = 1;
    foreach (Cars item in c)
    {
        if (i == a)
        {
            text = input;
            str.WriteLine(text);
        }
        else
        {
            text = $"{item.model},{item.mpg},{item.cyl},{item.disp},{item.hp},{item.drat},{item.wt},{item.qsec},{Convert.ToInt32(item.vs)},{Convert.ToInt32(item.am)},{item.gear},{item.carb}";
            str.WriteLine(text);
        }
        str.Flush();
        i++;
    }
    str.Close();
}

void SaveCSVListSort(List<Cars> c)
{
    string workingDirectory = Environment.CurrentDirectory;
    string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, "mtcars.csv");
    var str = new StreamWriter(path);
    string text = "model,mpg,cyl,disp,hp,drat,wt,qsec,vs,am,gear,carb";
    str.WriteLine(text);
    str.Flush();
    foreach (Cars item in c)
    {
        text = $"{item.model},{item.mpg},{item.cyl},{item.disp},{item.hp},{item.drat},{item.wt},{item.qsec},{Convert.ToInt32(item.vs)},{Convert.ToInt32(item.am)},{item.gear},{item.carb}";
        str.WriteLine(text);
        str.Flush();
    }
    str.Close();
}

bool b = true;
while (b == true)
{
    List<Cars> a = Main();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("\tE - Edit List");
    Console.WriteLine("\tS - Sort");
    Console.WriteLine("\tC - Close Console");
    Console.Write("Select an Option: ");

    switch (Console.ReadLine().ToUpper())
    {
        case "C":
            Console.WriteLine("Closing Console");
            b = false;
            break;
        case "E":
            a = Edit(a);
            break;
        case "S":
            a = Sort(a);
            break;
    }
}

List<Cars> Sort(List<Cars> a)
{
    Console.WriteLine("What do you want to sort? 1-Model 2-Mpg 3-Hp");
    string responce = Console.ReadLine();
    List<Cars>  newlist = new List<Cars>();
    switch (responce)
    {
        case "1":
            newlist = a.OrderBy(o => o.model).ToList();
            break;
        case "2":
            newlist = a.OrderBy(o => o.mpg).ToList();
            break;
        case "3":
            newlist = a.OrderBy(o => o.hp).ToList();
            break;
    }
    a = newlist;
    SaveCSVListSort(a);
    return a;
}