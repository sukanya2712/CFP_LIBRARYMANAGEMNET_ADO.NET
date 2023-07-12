﻿namespace LibraryManagementAdo
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
                                   "\n12.Exit : "
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
                    case 12:
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