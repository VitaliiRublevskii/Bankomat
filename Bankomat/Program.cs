

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

Console.WriteLine(  "\tПривіт !!!");
Console.WriteLine( "\tВи замовляли карту. Вона готова!" );
Karta kard5 = new Karta("ПриватБанк", "5249 0240 5487 5986", "0202", 0, new DateOnly(27, 11, 01));
kard5.KartaPrint();
Console.WriteLine(  );
Console.ReadLine();

Console.WriteLine(" Хочете покласти гроші на карту в касі  або  скористатися банкоматом?");
int choice1 = 0;
while(choice1 != 1 || choice1 != 2)
{
    Console.Write(" ( 1 - так,  2 - ні )\t");
    choice1 = int.Parse(Console.ReadLine());  // доробити виключення на букви та символи
    if (choice1 != 1 && choice1 != 2)
        Console.WriteLine("Некоректний вибір");
    else { break; }
}


switch (choice1)
{
    case 1:
        Console.Write(" Введіть суму поповнення карти:\t");
        int sumBalance = int.Parse( Console.ReadLine());
        kard5.Balans += sumBalance;
        Console.ReadKey();
        Console.WriteLine($" Ваш рахунок поповнений на {sumBalance}, баланс Вашої карти становить {kard5.Balans} грн. ");
        break;
    case 2:
        Console.WriteLine( " Раді були допомогти! Звертайтесь в разі потреби." );
        break;
}

Console.WriteLine( "Хочете скористатись банкоматом?" );
int choice2 = 0;
while (choice2 != 1 || choice2 != 2)
{
    Console.Write(" ( 1 - так,  2 - ні )\t");
    choice2 = int.Parse(Console.ReadLine());     // доробити виключення на букви та символи
    if (choice2 != 1 && choice2 != 2)
        Console.WriteLine("Некоректний вибір");
    else { break; }
}

int choiceMenu = 0;

switch (choice2)
{
    case 1:
        while(choiceMenu != 4)
        {
            while (choiceMenu != 1 || choiceMenu != 2 || choiceMenu != 3 || choiceMenu != 4)
            {
                Console.WriteLine(" \tМЕНЮ:");
                Console.WriteLine(" 1. Подивитися баланс по картці.");
                Console.WriteLine(" 2. Зняти готівку с картки.");
                Console.WriteLine(" 3. Покласти готівку на картковий рахунок.");
                Console.WriteLine(" 4. Вихід.");

                choiceMenu = int.Parse(Console.ReadLine());     // доробити виключення на букви та символи
                if (choiceMenu != 1 && choiceMenu != 2 && choiceMenu != 3 && choiceMenu != 4)
                    Console.WriteLine("Некоректний вибір");
                else { break; }
            }

            switch (choiceMenu)
            {
                case 1:
                    Console.WriteLine(" Баланс по поточній картці:");
                    Console.WriteLine($" На Вашому рахунку {kard5.Balans} грн.");
                    break;
                case 2:
                    Console.WriteLine(" Зняття готівки");
                    Console.Write("Вкажіть сумму, яку Ви хочете зняти\t");
                    int cash = int.Parse(Console.ReadLine());

                    if (kard5.Balans < cash)
                        Console.WriteLine(" На Вашому рахунку не вистачає грошей для зняття відповідної суми");

                    break;
                case 3:
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine(" Дякуємо за співпрацю! Гарного дня!");
                    break;
            }
            
        }
        break;


    case 2:
        Console.WriteLine(" Раді були допомогти! Звертайтесь в разі потреби.");
        break;
}

