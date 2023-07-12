namespace LibraryManagementAdo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libray Operations = new Libray();

            while (true)
            {
                Console.WriteLine("\n1.Add Books To Library : " +
                                  "\n2.Get Total Books :" +
                                  "\n3.Get Book list" + 
                                  "\n4.Total no of availble books:"+
                                  "\n5.Get no of Borrowed books"+
                                  "\n6.Get Books by Author"+ 
                                  "\n7.Get Books by Genre"+
                                  "\n8.Borrow Books from Library"+
                                  "\n9.Return Book to Library"+
                                  "\n10.Get Books Details" +
                                   "\n11.Exit : "
                   );


                Console.Write("\nEnter option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (option)
                {
                    case 1:
                        {

                            Console.WriteLine("title");
                            string title = Console.ReadLine();
                            Console.WriteLine("Author");
                            string author = Console.ReadLine();
                            Console.WriteLine("Gener");
                            string genre = Console.ReadLine();
                            Book book = new()
                            {

                                Title = title,
                                Author = author,
                                Genre = genre,
                                Borrowed = 0
                            };

                            bool Result = Operations.AddBooktoLibrary(book);
                            if (Result)
                            {
                                Console.WriteLine("Added Sucessfully");
                            }
                            else
                            {
                                Console.WriteLine("NOT ADDED");
                            }
                            break;
                        }
                    case 2:
                        {
                            int result = Operations.GetTotalNoofBooks();
                            Console.WriteLine($"Total no of books are: {result}");
                            break;
                        }
                    case 3:
                        {
                            Operations.GetBookList();
                            break;
                        }
                    case 4:
                        {
                            int result = Operations.get_total_no_availble_books();
                            Console.WriteLine($"Total no of availble books are: {result}");
                            break;
                        }
                    case 5:
                        {
                            int result = Operations.NoofBorrowedBooks();
                            Console.WriteLine($"Total no of Borrowed books are: {result}");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter the author name : ");
                            string AuthorName = Console.ReadLine();
                            bool result = Operations.GetBooksbyAuthor(AuthorName);
                            if (result)
                            {
                                Console.WriteLine("list has been displayed");
                            }
                            else
                            {
                                Console.WriteLine("something went wrong");
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Enter the genre name : ");
                            string GenreName = Console.ReadLine();
                            bool result = Operations.GetBooksbyGenre(GenreName);
                            if (result)
                            {
                                Console.WriteLine("list has been displayed");
                            }
                            else
                            {
                                Console.WriteLine("something went wrong");
                            }
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Enter the name of the book you want to borrow : ");
                            string BookName = Console.ReadLine();
                            bool result = Operations.BorrowebookfromLibrary(BookName);
                            if (result)
                            {
                                Console.WriteLine("Book has been borrowed");
                            }
                            else
                            {
                                Console.WriteLine("Book not found or already borrowed.");
                            }
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Enter the name of the book you want to return : ");
                            string BookName = Console.ReadLine();
                            int result = Operations.ReturnBookToLibrary(BookName);
                            if (result > 0)
                            {
                                Console.WriteLine("Book has been returned");
                            }
                            else
                            {
                                Console.WriteLine("Book is already non-borrowed or returned");
                            }
                            break;
                        }
                    case 10:
                        {
                            Console.WriteLine("Enter the name of the book you want to get details : ");
                            string BookName = Console.ReadLine();
                            bool result = Operations.GetBookDetails(BookName);
                            if (result)
                            {
                                Console.WriteLine("Books details has been printed");
                            }
                            else
                            {
                                Console.WriteLine("Book details cant be found or it doesnt exist");
                            }
                            break;
                        }
                    case 11:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }

            }
        }
    }
}