

/*
 4) Сделать симуляцию работы АТС Банкомата
Он должен уметь
Авторизировать карточку (16 цифр + пароль на 4) 
Выводить состояние баланса на вставленной карте
Выдавать наличку в нац купюрах (в зависимости от наличия таковых в сейфе терминала) расчитывая наиболее оптимальный пул выдачи
Общей доступный баланс банкомата и наличие конкретных банкнот хранить в файле
Пул карт хранить в отдельном файле так же

Помимо самого банкомата описать классы
Банкнота
Карточка
 */


using System;
using System.IO;
using Bankomat;
using Bankomat.Banknots;

/*
Banknot b100 = new Banknot100();
b100.BanknotPrint();
Banknot b200 = new Banknot200();
b200.BanknotPrint();
Banknot b500 = new Banknot100();
b500.BanknotPrint();
Banknot b1000 = new Banknot100();
b1000.BanknotPrint();


Karta kard1 = new Karta();
kard1.KartaPrint();
Karta kard2 = new Karta();
kard2.KartaPrint();
Karta kard3 = new Karta();
kard3.KartaPrint();
Karta kard4 = new Karta();
kard4.KartaPrint();
Console.WriteLine(  );
*/



using (Terminal term = new Terminal())
{

    int countBanknot = 100;  //  кількість банкнот кожного номіналу в ячійці при загрузці банкомата 
    int countCards = 200;    //  кількість карток  в пам'яті  банкомату 

    string pathB100 = "myB100.txt";
    List<Banknot100> b100 = new List<Banknot100>();  // List банкнот по 100 грн.

    for (int i = 0; i < countBanknot; i++)
    {
        b100.Add(new Banknot100());
        b100[i].AddBankToFile(pathB100);
    }

    string pathB200 = "myB200.txt";
    List<Banknot200> b200 = new List<Banknot200>();   // List банкнот по 200 грн.

    for (int i = 0; i < countBanknot; i++)
    {
        b200.Add(new Banknot200());
        b200[i].AddBankToFile(pathB200);
    }

    string pathB500 = "myB500.txt";
    List<Banknot500> b500 = new List<Banknot500>();   // List банкнот по 500 грн.

    for (int i = 0; i < countBanknot; i++)
    {
        b500.Add(new Banknot500());
        b500[i].AddBankToFile(pathB500);
    }

    string pathB1000 = "myB1000.txt";
    List<Banknot1000> b1000 = new List<Banknot1000>();  // List банкнот по 1000 грн.

    for (int i = 0; i < countBanknot; i++)
    {
        b1000.Add(new Banknot1000());
        b1000[i].AddBankToFile(pathB1000);
    }
        


    string pathKartas = "myKartas.txt";

    List<Karta> kartas = new List<Karta>();     // List карт.
    for (int i = 0; i < countCards; i++)
    {
        kartas.Add(new Karta());
        kartas[i].AddToFile(pathKartas);
    }

    //  Додаємо нову видану карту у List та файл
    Karta kard5 = new Karta("ПриватБанк", "5249-0240-5487-5986", "0202", 20000, new DateOnly(27, 11, 01));
    

    















    Console.WriteLine("\tПривіт !!!");
    Console.WriteLine("\tРаді вітати Вас у відділенні нашого банку !!!");
    Console.WriteLine("\tВи замовляли карту. Вона готова!");
    
    kard5.KartaPrint();
    Console.WriteLine();
    Console.ReadLine();


    //  ВИДАЧА  КАРТИ

    Console.WriteLine(" Хочете покласти гроші на карту в касі ?");
    string choice1 = "";
    while (choice1 != "1" || choice1 != "2")
    {
        Console.Write(" ( 1 - так,  2 - ні )\t");
        choice1 = Console.ReadLine();  // доробити виключення на букви та символи
        if (choice1 == "1" || choice1 == "2")
            break;
            
        else { Console.WriteLine("Некоректний вибір"); }
    }
    switch (choice1)
    {
        case "1":
            Console.Write(" Введіть суму поповнення карти:\t");
            int sumBalance = int.Parse(Console.ReadLine());
            kard5.Balans += sumBalance;
            Console.ReadKey();
            Console.WriteLine($" Ваш рахунок поповнений на {sumBalance}, баланс Вашої карти становить {kard5.Balans} грн. ");
            Console.WriteLine();
            break;
        case "2":
            Console.WriteLine(" Раді були допомогти! Звертайтесь в разі потреби.");
            Console.WriteLine();
            break;
    }

    //kartas.Add(kard5);
    kard5.AddToFile(pathKartas);

    //  Створюємо термінал
    // Terminal terminal = new Terminal(555, "просп. Гагаріна, 74", b100, b200, b500, b1000, kartas);
    Terminal terminal = new Terminal(555, "просп. Гагаріна, 74", pathB100, pathB200, pathB500, pathB1000, pathKartas);

    //  КОРИСТАННЯ  БАНКОМАТОМ

    Console.WriteLine("Хочете скористатись банкоматом?");
    string choice2 = "";
    while (choice2 != "1" || choice2 != "2")
    {
        Console.Write(" ( 1 - так,  2 - ні )\t");
        choice2 = Console.ReadLine();  
        if (choice2 == "1" || choice2 == "2")
            break;

        else { Console.WriteLine("Некоректний вибір"); }
    }

    string choiceMenu = "";

    switch (choice2)
    {
        case "1":
            Console.WriteLine(" Найближчий до Вас термінал наступний:");
            terminal.TerminalInfo();
            Console.WriteLine();
            Console.WriteLine("OK");
            Console.ReadKey();
                


            while (choiceMenu != "4")
            {
                while (choiceMenu != "1" || choiceMenu != "2" || choiceMenu != "3" || choiceMenu != "4")
                {
                    Console.Clear();
                    Console.WriteLine(" \tМЕНЮ:");
                    Console.WriteLine(" 1. Перевірити баланс по картці.");
                    Console.WriteLine(" 2. Зняти готівку с карткового рахунку.");
                    Console.WriteLine(" 3. Покласти готівку на картковий рахунок.");
                    Console.WriteLine(" 4. Вихід.");

                    choiceMenu = Console.ReadLine();     // доробити виключення на букви та символи
                    if (choiceMenu == "1" || choiceMenu == "2" || choiceMenu == "3" || choiceMenu == "4")
                        break;
                        
                    else { Console.WriteLine("Некоректний вибір"); }
                }

                switch (choiceMenu)
                {
                    case "1":

                        Console.Clear();
                        Console.Write(" Введіть номер картки:");
                        var num = Console.ReadLine();
                        var res = terminal.Kards.FindAll(x => x.Number.Contains(num));  //  шукаємо карту в Терміналі

                        if (num.Length != 19)
                        {
                            Console.WriteLine(" Номер картки замалий ( завеликий ) ");
                            Console.ReadKey();
                            break;
                        }
                        if ((terminal.Kards.FindIndex(x => x.Number.Contains(num)) < 0))
                        {
                            Console.WriteLine(" Поточної карти не знайдено");
                            Console.ReadKey();
                            break;
                        }
                                                
                        bool ch = true;
                        //  перевірка  PIN
                        while (ch)
                        {
                            try
                            {
                                Console.Write(" Введіть PIN ");
                                var pin = Console.ReadLine();
                                if (pin.Length == 4)
                                {
                                    foreach (var x in res)
                                    {
                                        if (x.Pin == pin)
                                        {
                                            Console.WriteLine(" PIN прийнятий");
                                            ch = false;
                                            break;
                                        }
                                        else Console.WriteLine( "Неправильний PIN");
                                    }
                                }
                                else
                                {
                                    throw new MyExc();                                    
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        
                        foreach (var x in res) x.KartaShow();
                        Console.WriteLine();                     
                        Console.Write(" БАЛАНС  ПО  ПОТОЧНІЙ  КАРТЦІ:");                        
                        foreach (var x in res) Console.WriteLine($"\t{x.Balans} грн.");
                        Console.WriteLine();
                        Console.WriteLine("OK");
                        Console.ReadKey();
                        break;


                    case "2":
                        Console.Clear();

                        Console.Write(" Введіть номер картки:");
                        var num2 = Console.ReadLine();
                        var res2 = terminal.Kards.FindAll(x => x.Number.Contains(num2));  //  шукаємо карту в Терміналі

                        if (num2.Length != 19)
                        {
                            Console.WriteLine(" Номер картки замалий ( завеликий ) ");
                            Console.ReadKey();
                            break;
                        }
                        if ((terminal.Kards.FindIndex(x => x.Number.Contains(num2)) < 0))
                        {
                            Console.WriteLine(" Поточної карти не знайдено");
                            Console.ReadKey();
                            break;
                        }

                        bool ch2 = true;
                        //  перевірка  PIN
                        while (ch2)
                        {
                            try
                            {
                                Console.Write(" Введіть PIN ");
                                var pin = Console.ReadLine();
                                if (pin.Length == 4)
                                {
                                    foreach (var x in res2)
                                    {
                                        if (x.Pin == pin)
                                        {
                                            Console.WriteLine(" PIN прийнятий");
                                            ch2 = false;
                                            break;
                                        }
                                        else Console.WriteLine("Неправильний PIN");
                                    }
                                }
                                else
                                {
                                    throw new MyExc();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        Console.WriteLine(" ЗНЯТТЯ  ГОТІВКИ");

                        Console.Write("Вкажіть сумму, яку Ви хочете зняти (кратно 100 грн.)\t");
                        int cash = int.Parse(Console.ReadLine());  //  доробити перевірку на кратно 100
                        if (cash % 100 != 0)
                        {
                            Console.WriteLine(" Вказана сума не кратна 100");
                        }
                        else
                        {
                            //  Списання коштів з рахунку
                            foreach (var x in res2)
                            {
                                if (x.Balans < cash) Console.WriteLine(" На Вашому рахунку не вистачає грошей для зняття відповідної суми");
                                else
                                {
                                    x.Balans -= cash;
                                    Console.WriteLine($"Ви зняли {cash} грн.");
                                    Console.WriteLine($" Залишок на Вашому рахунку {x.Balans} грн.");
                                }
                            }
                            int choice = 0;

                            //  Видача купюр
                            //  5249-0240-5487-5986
                            if (cash >= 1000) //3900
                            {
                                choice = cash / 1000;
                                var res1000 = terminal.B1000.Take(choice); // 3 банкноти по 1000
                                Console.WriteLine(" Вам видано наступні купюри: ");
                                foreach (var x in res1000)
                                {
                                    x.BanknotPrint();
                                    terminal.B1000.Remove(x);  // видалили банкноти зі списку
                                }

                                if (cash % 1000 > 0)  // якщо є остаток для видачі після  видачі 3000
                                {
                                    int ost = cash - choice * 1000;  //  3600 - 3000
                                    if (ost >= 500)  // 600
                                    {
                                        var res500 = terminal.B500.Take(1);  // видали 1 банкноту 500
                                        foreach (var x in res500)
                                        {
                                            x.BanknotPrint();
                                            terminal.B500.Remove(x);  // видалили банкноти зі списку
                                        }
                                        int ost1 = ost - 500;  //  остаток 100
                                        if (ost1 >= 200)
                                        {
                                            int ost2 = ost1 / 200;
                                            var res200 = terminal.B200.Take(ost2);
                                            foreach (var x in res200)
                                            {
                                                x.BanknotPrint();
                                                terminal.B200.Remove(x);  // видалили банкноти зі списку
                                            }
                                            if (ost1 % 200 > 0)
                                            {
                                                var res100 = terminal.B100.Take(1);
                                                foreach (var x in res100)
                                                {
                                                    x.BanknotPrint();
                                                    terminal.B100.Remove(x);  // видалили банкноти зі списку
                                                }
                                            }
                                        }
                                        else
                                        {
                                            var res100 = terminal.B100.Take(1);
                                            foreach (var x in res100)
                                            {
                                                x.BanknotPrint();
                                                terminal.B100.Remove(x);  // видалили банкноти зі списку
                                            }
                                        }
                                    }
                                    else
                                    {
                                        int ost1 = cash - choice * 1000;  //  3400 - 3000  //  остаток 400
                                        if (ost1 >= 200)
                                        {
                                            int ost2 = ost1 / 200;
                                            var res200 = terminal.B200.Take(ost2);
                                            foreach (var x in res200)
                                            {
                                                x.BanknotPrint();
                                                terminal.B200.Remove(x);  // видалили банкноти зі списку
                                            }
                                            if (ost1 % 200 > 0)
                                            {
                                                var res100 = terminal.B100.Take(1);
                                                foreach (var x in res100)
                                                {
                                                    x.BanknotPrint();
                                                    terminal.B100.Remove(x);  // видалили банкноти зі списку
                                                }
                                            }
                                        }
                                        else
                                        {
                                            var res100 = terminal.B100.Take(1);
                                            foreach (var x in res100)
                                            {
                                                x.BanknotPrint();
                                                terminal.B100.Remove(x);  // видалили банкноти зі списку
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {

                                if (cash >= 500)  // 600
                                {
                                    var res500 = terminal.B500.Take(1);  // видали 1 банкноту 500
                                    foreach (var x in res500)
                                    {
                                        x.BanknotPrint();
                                        terminal.B500.Remove(x);  // видалили банкноти зі списку
                                    }
                                    int ost1 = cash - 500;  //  остаток 100
                                    if (ost1 >= 200)
                                    {
                                        int ost2 = ost1 / 200;
                                        var res200 = terminal.B200.Take(ost2);
                                        foreach (var x in res200)
                                        {
                                            x.BanknotPrint();
                                            terminal.B200.Remove(x);  // видалили банкноти зі списку
                                        }
                                        if (ost1 % 200 > 0)
                                        {
                                            var res100 = terminal.B100.Take(1);
                                            foreach (var x in res100)
                                            {
                                                x.BanknotPrint();
                                                terminal.B100.Remove(x);  // видалили банкноти зі списку
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var res100 = terminal.B100.Take(1);
                                        foreach (var x in res100)
                                        {
                                            x.BanknotPrint();
                                            terminal.B100.Remove(x);  // видалили банкноти зі списку
                                        }
                                    }
                                }
                                else
                                {
                                    if (cash >= 200)
                                    {
                                        int ost2 = cash / 200;
                                        var res200 = terminal.B200.Take(ost2);
                                        foreach (var x in res200)
                                        {
                                            x.BanknotPrint();
                                            terminal.B200.Remove(x);  // видалили банкноти зі списку
                                        }
                                        if (cash % 200 > 0)
                                        {
                                            var res100 = terminal.B100.Take(1);
                                            foreach (var x in res100)
                                            {
                                                x.BanknotPrint();
                                                terminal.B100.Remove(x);  // видалили банкноти зі списку
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var res100 = terminal.B100.Take(1);
                                        foreach (var x in res100)
                                        {
                                            x.BanknotPrint();
                                            terminal.B100.Remove(x);  // видалили банкноти зі списку
                                        }
                                    }
                                }
                            }
                            terminal.TerminalInfo();
                            // записати в файли
                            Console.WriteLine("OK");
                            Console.ReadKey();
                        }
                        
                        break;


                    case "3":
                        Console.Clear();

                        Console.Write(" Введіть номер картки:");
                        var num3 = Console.ReadLine();
                        var res3 = terminal.Kards.FindAll(x => x.Number.Contains(num3));  //  шукаємо карту в Терміналі

                        if (num3.Length != 19)
                        {
                            Console.WriteLine(" Номер картки замалий ( завеликий ) ");
                            Console.ReadKey();
                            break;
                        }
                        if ((terminal.Kards.FindIndex(x => x.Number.Contains(num3)) < 0))
                        {
                            Console.WriteLine(" Поточної карти не знайдено");
                            Console.ReadKey();
                            break;
                        }

                        bool ch3 = true;
                        //  перевірка  PIN
                        while (ch3)
                        {
                            try
                            {
                                Console.Write(" Введіть PIN ");
                                var pin = Console.ReadLine();
                                if (pin.Length == 4)
                                {
                                    foreach (var x in res3)
                                    {
                                        if (x.Pin == pin)
                                        {
                                            Console.WriteLine(" PIN прийнятий");
                                            ch3 = false;
                                            break;
                                        }
                                        else Console.WriteLine("Неправильний PIN");
                                    }
                                }
                                else
                                {
                                    throw new MyExc();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        Console.WriteLine(" ПОПОВНЕННЯ  КАРТКИ");
                        Console.Write(" Введіть суму поповнення карти:\t");
                        int sumBalance = int.Parse(Console.ReadLine());
                        foreach(var x in res3)
                        {
                            x.Balans += sumBalance;                            
                            Console.WriteLine($" Ваш рахунок поповнений на {sumBalance}, баланс Вашої карти становить {x.Balans} грн. ");
                        }                           
                        
                        Console.WriteLine();
                        Console.WriteLine("OK");
                        Console.ReadKey();
                        break;


                    case "4":
                        Console.WriteLine(" Дякуємо за співпрацю! Гарного дня!");
                        break;
                }

            }
            break;


        case "2":
            Console.WriteLine(" Раді були допомогти! Звертайтесь в разі потреби.");
            break;
    }



}




