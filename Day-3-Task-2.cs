void Main(string[] args)
{
    Library library1 = new Library("library1", "somewhere");
    try { 
        while (true)
        {
            Console.WriteLine("\nMain Menu\n1)Add Book\n2)Remove Book\n3)Add Media-Item\n4)Remove Media-Item\n5)Display Catalogue\n6)Book Search By Title\n7)Media Search By Title");
            string choice = Console.ReadLine().Trim();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter the title:"); 
                    string title = Console.ReadLine().Trim();
                    Console.WriteLine("Enter the author:");
                    string author = Console.ReadLine().Trim(); 
                    Console.WriteLine("Enter the isbn:");
                    string isbn = Console.ReadLine().Trim();
                    Console.WriteLine("Enter the year it was published in:");
                    int yearPublished = Convert.ToInt32(Console.ReadLine().Trim());
                    Book  book = new Book(title, author , isbn, yearPublished);
                    library1.AddBook(book);
                    break;
                case "2":
                    Console.WriteLine("Enter the title:");
                    string remTitle = Console.ReadLine().Trim();
                    Console.WriteLine("Enter the author:");
                    string remAuthor = Console.ReadLine().Trim();
                    Console.WriteLine("Enter the isbn:");
                    string remIsbn = Console.ReadLine().Trim();
                    Console.WriteLine("Enter the year it was published in:");
                    int remYearPublished = Convert.ToInt32(Console.ReadLine().Trim());
                    Book book1 = new Book(remTitle, remAuthor, remIsbn, remYearPublished);
                    library1.RemoveBook(book1);
                    break;
                case"3":
                    Console.WriteLine("Enter the title:");
                    string mediaTitle = Console.ReadLine().Trim();
                    Console.WriteLine("Enter the type:");
                    string mediatType = Console.ReadLine().Trim();
                    Console.WriteLine("Enter the duration(in minutes):");
                    int mediaDuration = Convert.ToInt32(Console.ReadLine().Trim());
                    MediaItem mediaItem = new MediaItem(mediaTitle, mediatType, mediaDuration);
                    library1.AddMediaItem(mediaItem);
                    break;
                case"4":
                    Console.WriteLine("Enter the title:");
                    string remMediaTitle = Console.ReadLine().Trim();
                    Console.WriteLine("Enter the type:");
                    string remMediatType = Console.ReadLine().Trim();
                    Console.WriteLine("Enter the duration(in minutes):");
                    int remMediaDuration = Convert.ToInt32(Console.ReadLine().Trim());
                    MediaItem mediaItem1 = new MediaItem(remMediaTitle, remMediatType, remMediaDuration);
                    library1.RemoveMediaItem(mediaItem1);
                    break;
                case "5":
                    library1.PrintCatalog();
                    break;
                case "6":
                    Console.WriteLine("Enter the title of the book.");
                    string bookName = Console.ReadLine().Trim();
                    library1.BookSearchByTitle(bookName);
                    break;
                case "7":
                    Console.WriteLine("Enter the title of the media-item.");
                    string mediaName = Console.ReadLine().Trim();
                    library1.MediaSearchByTitle(mediaName);
                    break;
                default:
                    Console.WriteLine("Wrong Entry!!");
                    break;
            }
        
        }
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
        return;
    }
}
Main(args);


class MediaItem
{
    private string title;
    private string mediaType;
    private int duration;
    public MediaItem(string title, string mediaType, int duration)
    {
        this.title = title;
        this.mediaType = mediaType;
        this.duration = duration;
    }
    
    public string Title
    {
        set { title = value; }
        get { return title; }
    }
    public string MediaType
    {
        set { mediaType = value; } 
        get { return mediaType; }
    }
    public int Duration
    {
        set { duration = value; }
        get { return duration; }
    }
}

class Book
{
    private string title;
    private string author;
    private string isbn;
    private int publicationYear;
    
    public Book(string title, string author, string isbn, int publicationYear)
    {
        this.title=title;
        this.author=author;
        this.isbn=isbn;
        this.publicationYear = publicationYear;
    }
    public string Title
    {
        set { author = value; }
        get { return title; }
    }
    public string Author
    {
        set { author = value; }
        get { return author; }
    }
    public string Isbn
    {
        set { isbn = value; }
        get { return isbn; }
    }
    public int PublicationYear
    {
        set { publicationYear = value; }
        get { return publicationYear; }
    }
}

class Library
{
    private string name;
    private string address;
    private List<Book> books;
    private List<MediaItem> mediaItems;
    
    public Library(string name, string address)
    {
        this.name = name;
        this.address = address;
        books = new List<Book>();
        mediaItems = new List<MediaItem>();
    }
    public string Name
    {
        set { name = value; }
        get { return name; }
    }
    public string Address
    {
        set { address = value; }
        get { return address; }
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("The book is added successfully.");
    }
    
    public void RemoveBook(Book book)
    {
        foreach(Book b in books)
        {
            if (b.Title == book.Title && b.Isbn == book.Isbn && b.Author == book.Author && b.PublicationYear == book.PublicationYear)
            {
                books.Remove(b);
                Console.WriteLine("The book is removed successfully.");
                return;
            }
        }
        Console.WriteLine("The book does'nt exist in the library");
    }
    
    public void AddMediaItem(MediaItem item)
    {
        mediaItems.Add(item);
        Console.WriteLine("The media-item is added successfully.");
    }
    
    public void RemoveMediaItem(MediaItem item)
    {
        foreach (MediaItem m in mediaItems)
        {
            if (m.Title == item.Title && m.MediaType == item.MediaType && m.Duration == item.Duration)
            {
                mediaItems.Remove(m);
                Console.WriteLine("The media-item is removed successfully.");
                return;
            }
        }
        Console.WriteLine("The media-item doesn't exist in the library.");
    }
    
    public void PrintCatalog()
    {
        Console.WriteLine("LIST OF BOOKS IN THE LIBRARY:\t");
        foreach(Book book in books)
        {
            Console.Write(book.Title + " | ");
        }
        Console.WriteLine("");
        Console.WriteLine("\nLIST OF MEDIA-ITEMS IN THE LIBRARY: \t");
        foreach (MediaItem mediaItem in mediaItems)
        {
            Console.Write(mediaItem.Title + " | ");
        }
    }

    public void MediaSearchByTitle(string name)
    {
        Console.WriteLine("Media Search Result: \n");
        foreach (MediaItem m in mediaItems)
        {
            if (m.Title == name)
            {
                Console.WriteLine("Title: " + m.Title);
                Console.WriteLine("Type: " + m.MediaType);
                Console.WriteLine("Title: " + m.Duration + "\n");
            }
        }
    }
    public void BookSearchByTitle(string name)
    {
        Console.WriteLine("Book Search Result: \n");
        foreach (Book b in books)
        {
            if (b.Title == name)
            {
                Console.WriteLine("Title: " + b.Title);
                Console.WriteLine("Author: " + b.Author);
                Console.WriteLine("Isbn: " + b.Isbn);
                Console.WriteLine("Publication year: " + b.PublicationYear + "\n");
            }
        }
    }
}


