namespace Library;

public class Book
{
    public int BookId { get; }
    public Genre Genre { get; set; }
    public string Title { get; }
    public string Author { get; set; }
    public int NumberOfPages { get; set; }
    

    public Book( Genre genre, string title, string author, int numberOfPages)
    {
        BookId = DataBase.Id;
        DataBase.Id++;
        Genre = genre;
        Title = title;
        Author = author;
        NumberOfPages = numberOfPages;
    }

    public override bool Equals(object? obj)
    {
        if (this == obj)
            return true;
        if (obj == null || !GetType().Equals(obj.GetType()))
            return false;
        Book compared = (Book)obj;
        return (compared.Genre == Genre
                && compared.Title == Title
                && compared.Author == Author
                && compared.NumberOfPages == NumberOfPages);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode() + BookId;
    }


    public override string ToString()
    {
        return $"{BookId}:\tTitle: {Title} -> Author: {Author} -> Category: {Genre} -> Number of pages: {NumberOfPages}";
    }

}