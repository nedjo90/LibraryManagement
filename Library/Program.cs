// See https://aka.ms/new-console-template for more information

using Library;
using static Library.DataBase;

Display();
Console.WriteLine("*****************");
Display(Genre.Drame);
Console.WriteLine("*****************");
Display("kIen");
Console.WriteLine("*****************");
Book newBook = new Book(Genre.ScienceFiction, "Fondation et Empire", "Isaac Asimov", 289);
Console.WriteLine("*****************");
AddBook(newBook);
Console.WriteLine("*****************");
Display();
Console.WriteLine("*****************");
RemoveBook(newBook);
Console.WriteLine("*****************");
Display();
Console.WriteLine("*****************");
AddBook(newBook);
Console.WriteLine("*****************");
Display();
Console.WriteLine("*****************");
Console.WriteLine("*****************");
Console.WriteLine("*****************");

User newUser = new User("necati", "han");
Random random = new Random();
int sizeOfLibrary = DataBase.Library.Count;
int nborrow = random.Next(sizeOfLibrary);
for (int i = 0; i < nborrow; i++)
{
    newUser.Borrow(random.Next(sizeOfLibrary));
}

Console.WriteLine(newUser);
Console.WriteLine("*****************");
for (int i = 0; i < nborrow; i++)
{
    newUser.GiveBack(random.Next(sizeOfLibrary));
}

Console.WriteLine(newUser);

