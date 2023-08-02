public class Library
{
    public string Name { get; set; }
    public string Address { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();

    public List<MediaItem> MediaItems { get; set; } = new List<MediaItem>();

    public Library(String name, String address)
    {
        Name = name;
        Address = address;
    }
    public void AddBook(Book book)
    {
        Books.Add(book);
    }


    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        if (Books.Count > 0)
        {
            Console.WriteLine("________________________________________");
            Console.WriteLine("Books Catalog.........");
            foreach (Book book in Books)
            {
                Console.WriteLine($"Title : {book.Title}\nAuthor : {book.Author}\nISBN : {book.ISBN}\nPublicationYear : {book.PublicationYear}\n");
            }
        }
        else
        {
            Console.WriteLine("No book is found");
        }
        
        if (MediaItems.Count > 0)
        {
            Console.WriteLine("________________________________________");

            Console.WriteLine("Media Items Catalog.........");
            foreach (MediaItem media in MediaItems)
            {
                Console.WriteLine($"Title : {media.Title}\nMediaType : {media.MediaType}\nDuration : {media.Duration}\n");
            }
        }
        else
        {
            Console.WriteLine("No Media is found");
        }

    }

}



