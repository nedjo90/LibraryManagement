using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace Library;

public static class DataBase
{
    public static List<Book> Library { get; set; }
    public static string Path = "../../../../BooksDB.csv";
    public static string PathTemp = "../../../../temp.csv";
    public static int Id = 1;

    static DataBase()
    {
        string[] readDB = File.ReadAllLines(Path);
        Library = new List<Book>();
        foreach (string str in readDB)
        {
            string[] tab = str.Split(";");
            Genre categoryOfBook = MatchGenre(tab[0]);
            int numberOfPages = Convert.ToInt32(tab[3]);
            Book newBook = new Book(categoryOfBook, tab[1], tab[2], numberOfPages);
            Library.Add(newBook);
        }
    }

    public static Genre MatchGenre(string str)
    {
        switch (str)
        {
            case "Fiction":
                return Genre.Fiction;
            case "ScienceFiction":
                return Genre.ScienceFiction;
            case "Thriller":
                return Genre.Thriller;
            case "RomanHistorique":
                return Genre.RomanHistorique;
            case "Fantasy":
                return Genre.Fantasy;
            case "Drame":
                return Genre.Drame;
            case "Horreur":
                return Genre.Horreur;
            default:
                return Genre.NoCategory;
        }
    }

    public static void Display(Genre genre)
    {
        foreach (Book book in Library)
        {
            if(book.Genre == genre)
                Console.WriteLine(book.ToString());
        }
    }

    public static void Display(string author)
    {
        foreach (Book book in Library)
        {
            if (book.Author.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0)
                Console.WriteLine(book.ToString());
        }
    }

    public static void DisplayTitle(string title)
    {
        foreach (Book book in Library)
        {
            if (book.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                Console.WriteLine(book.ToString());
        }
    }
    
    public static void Display()
    {
        foreach (Book book in Library)
        {
            Console.WriteLine(book.ToString());
        }
    }

    public static void AddBook(Book book)
    {
        if (!Library.Contains(book))
        {
            Library.Add(book);
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.Write($"\n{book.Genre};" +
                         $"{book.Title};" +
                         $"{book.Author};" +
                         $"{book.NumberOfPages}");
            }

            Console.WriteLine($"The book :\n" +
                              $"{book}" +
                              $" is add");
        }
        else
        {
            Console.WriteLine("Already in the library");
        }
    }

    public static void RemoveBook(Book book)
    {
      
            List<Book> toRemove = new List<Book>();
            foreach (Book bookInList in Library)
            {
                if (bookInList.Equals(book))
                {
                    toRemove.Add(bookInList);
                }
            }
            foreach (Book bookToRemove in toRemove)
            {
                Library.Remove(bookToRemove);
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(File.OpenWrite(PathTemp)))
                {
                    for (int i = 0; i < Library.Count; i++)
                    {
                        sw.Write($"{Library[i].Genre};" +
                                 $"{Library[i].Title};" +
                                 $"{Library[i].Author};" +
                                 $"{Library[i].NumberOfPages}");
                        if(i != Library.Count - 1)
                            sw.Write("\n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'écriture dans le fichier temporaire" + e);
                throw;
            }

            try
            {
                File.Delete(Path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la suppression du fichier BooksDB " + e);
                throw;
            }

            try
            {
                File.Move(PathTemp, Path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Errerur lors du renommage du fichier temporaire " + e);
                throw;
            }
    }

    public static Book SearchById(int id)
    {
        foreach (Book book in Library)
        {
            if (book.BookId == id)
                return book;
        }
        return null;
    }
}