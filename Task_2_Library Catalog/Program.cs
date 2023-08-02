class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("WELCOME TO ABREHOT LIBRARY");
        Console.WriteLine("Please follow the following Instructions");
        Console.WriteLine("***********************************************");

        Library libraryObject = new Library("Abrehot", "4Kilo, Addis Abeba" );

        List<Book> currentBooks = new List<Book>
        {
            new Book() { Author = "bealu girma", PublicationYear = 1990, ISBN="lorem...", Title = "Oromay"} ,
            new Book() { Author = "Albert Einstein", PublicationYear = 1945, ISBN="lorem...", Title = "universe"} ,

        };
        List<MediaItem> currentItems = new List<MediaItem> { 
            new MediaItem() { Title = "astronomy", Duration = 12, MediaType = "DVD"},
            new MediaItem() { Title = "graphics design", Duration = 2, MediaType = "CD"},
        };

        foreach (Book book in currentBooks)
        {
            libraryObject.AddBook(book);
        }
        foreach (MediaItem mediaItem in currentItems)
        {
            libraryObject.AddMediaItem(mediaItem);
        }


        handleUserInput(libraryObject);
    }

    private static void handleUserInput(Library libraryObject)
    {
        int userChooise;

        Console.WriteLine("\n1.Get List of Books and Media Items\n2.Add new Book\n3.Search a Book\n4.Search a Media Item\n TO CANCEL ENTER X");

        var input = Console.ReadLine().ToLower();
        while (input != "x")
        {
            if (!int.TryParse(input, out userChooise) & (userChooise < 1 || userChooise > 4))
            {
                Console.WriteLine("Please enter a valid number and , try again.");

            }
            else
            {
                switch (userChooise)
                {
                    case 1:
                        
                        libraryObject.PrintCatalog();
                        break;
                    case 2:
                        int year;
                        Book newBook = new Book();

                        Console.Write("Author : ");
                        var author = Console.ReadLine();

                        Console.Write("PublicationYear : ");
                        if (!int.TryParse(Console.ReadLine()!, out year))
                        {
                            Console.WriteLine("You made an error, please re-try");
                            break;
                        }

                        Console.Write("ISBN : ");
                        var isbn = Console.ReadLine();
                        Console.Write("Title : ");
                        var title = Console.ReadLine();

                        newBook.Author = author;
                        newBook.PublicationYear = year;
                        newBook.ISBN = isbn;
                        newBook.Title = title;

                        libraryObject.AddBook(newBook);
                        Console.WriteLine("added successfully");
                        break;
                    case 3:
                        Console.Write("Enter the title of the book : ");
                        var keyWord = Console.ReadLine();
                        Console.WriteLine("________________________________________");
                        bool flag = false;
                        foreach (Book book in libraryObject.Books)
                        {
                            if (book.Title == keyWord)
                            {
                                Console.WriteLine($"Title : {book.Title}\nAuthor : {book.Author}\nISBN : {book.ISBN}\nPublicationYear : {book.PublicationYear}\n");
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            Console.WriteLine("Unable to get the book");

                        }
                        break;
                    case 4:
                        Console.Write("Enter the title of the media : ");
                        var keyWord2 = Console.ReadLine();
                        Console.WriteLine("________________________________________");
                        bool flag2 = false;
                        foreach (MediaItem media in libraryObject.MediaItems)
                        {
                            if (media.Title == keyWord2)
                            {
                                Console.WriteLine($"Title : {media.Title}\nMediaType : {media.MediaType}\nDuration : {media.Duration}\n");
                                flag2 = true;
                                break;
                            }
                        }
                        if (flag2 == false)
                        {
                            Console.WriteLine("Unable to get the media");

                        }
                        break;

                }

            }
            Console.WriteLine("\n1.Get List of Books and Media Items\n2.Add new Book\n3.Search a Book\n4.Search a Media Item\n\tTO CANCEL ENTER X");
            input = Console.ReadLine().ToLower();
        }

       
    }

    
}















