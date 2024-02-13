namespace Library;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> BorrowedBooks { get; set; }

    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        BorrowedBooks = new List<Book>();
    }

    public void Borrow(Book book)
    {
        BorrowedBooks.Add(book);
        Console.WriteLine($"{book} is borrow");
    }
    
    public void Borrow(int id)
    {
        try
        {
            Book borrowedBook = DataBase.SearchById(id);
            BorrowedBooks.Add(borrowedBook);
        }
        catch (Exception e)
        {
            Console.WriteLine(e + ": Book doesn't found");
            throw;
        }
    }

    public void GiveBack(Book book)
    {
        BorrowedBooks.Remove(book);
    }
    
    public void GiveBack(int id)
    {
        try
        {
            Book searchedBook = DataBase.SearchById(id);
            while (BorrowedBooks.Contains(searchedBook))
                BorrowedBooks.Remove(searchedBook);
        }
        catch (Exception e)
        {
            Console.WriteLine(e + ": Book doesn't found in borrowed");
            throw;
        }
    }

    public override string ToString()
    {
        string str = "";
        for (int i = 0; i < BorrowedBooks.Count; i++)
        {
            str += BorrowedBooks[i].ToString();
            if (i < BorrowedBooks.Count)
                str += "\n";
        }

        return str;
    }
}