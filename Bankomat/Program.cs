

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
Karta kard5 = new Karta("ПриватБанк", "5249 0240 5487 5986", "0202", 58001, new DateOnly(24,11,01));
kard5.KartaPrint();