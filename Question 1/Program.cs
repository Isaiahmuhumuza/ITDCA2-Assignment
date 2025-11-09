namespace ITDCA_Assignment
{
    internal class Program
    {
        public class q1_Books
        {
            public string Title;
            public string Author;
            public int Year;

            public q1_Books(string title, string author, int year)
            {
                Title = title;
                Author = author;
                Year = year;
            }
        }

        public class q1_AVLTree
        {

            public Node Root;
            public void Insert(q1_Books book)
            {
                Root = Insert(Root, book);
            }
            public q1_Books BinarySearchByYear(Node node, int targetYear)
            {
                while (node != null)
                {
                    if (targetYear < node.Data.Year)
                        node = node.Left;
                    else if (targetYear > node.Data.Year)
                        node = node.Right;
                    else
                        return node.Data;
                }
                return null;
            }
            public q1_Books GetMostRecentBook()
            {
                Node current = Root;
                if (current == null) return null;

                while (current.Right != null)
                {
                    current = current.Right;
                }
                return current.Data;
            }

            public int CountBooks(Node node)
            {
                if (node == null) return 0;
                return 1 + CountBooks(node.Left) + CountBooks(node.Right);
            }

            private int Height(Node node)
            {
                if (node == null)
                    return 0;
                return node.Height;
            }

            private int GetBalanceFactor(Node node)
            {
                if (node == null)
                    return 0;
                return Height(node.Left) - Height(node.Right);
            }

            private Node RightRotate(Node y)
            {
                Node x = y.Left;
                Node T2 = x.Right;

                x.Right = y;
                y.Left = T2;

                y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
                x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

                return x;
            }
            private Node LeftRotate(Node x)
            {
                Node y = x.Right;
                Node T2 = y.Left;

                y.Left = x;
                x.Right = T2;

                x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
                y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

                return y;
            }

            public Node Insert(Node node, q1_Books book)
            {

                if (node == null)
                    return new Node(book);

                if (book.Year < node.Data.Year)
                    node.Left = Insert(node.Left, book);
                else if (book.Year > node.Data.Year)
                    node.Right = Insert(node.Right, book);
                else
                    return node;

                node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

                int balance = GetBalanceFactor(node);

                // Rotation Balances

                // LL Rotation
                if (balance > 1 && book.Year < node.Left.Data.Year)
                {
                    return RightRotate(node);
                }

                // RR Rotation
                if (balance < -1 && book.Year > node.Right.Data.Year)
                {
                    return LeftRotate(node);
                }

                // LR Rotation
                if (balance > 1 && book.Year > node.Left.Data.Year)
                {
                    node.Left = LeftRotate(node.Left);
                    return RightRotate(node);
                }

                // RL Rotation
                if (balance < -1 && book.Year < node.Right.Data.Year)
                {
                    node.Right = RightRotate(node.Right);
                    return LeftRotate(node);
                }

                return node;
            }

            public Node Delete(Node node, int year)
            {
                if (node == null)
                    return node;

                // Conditional statement to run through tree
                if (year < node.Data.Year)
                    node.Left = Delete(node.Left, year);
                else if (year > node.Data.Year)
                    node.Right = Delete(node.Right, year);
                else
                {
                    // No children within Node
                    if (node.Left == null && node.Right == null)
                        return null;

                    // Node has 1 child
                    if (node.Left == null)
                        return node.Right;

                    if (node.Right == null)
                        return node.Left;

                    // Node has atleast 2 children, get largest and smallest childen Nodes in subtree
                    Node successor = GetMinNode(node.Right);

                    node.Data.Year = successor.Data.Year;
                    node.Data.Title = successor.Data.Title;

                    node.Right = Delete(node.Right, successor.Data.Year);
                }

                // Rebalance the Tree
                node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

                int balance = GetBalanceFactor(node);

                if (balance > 1 && GetBalanceFactor(node.Left) >= 0)
                    return RightRotate(node);

                if (balance > 1 && GetBalanceFactor(node.Left) < 0)
                {
                    node.Left = LeftRotate(node.Left);
                    return RightRotate(node);
                }

                if (balance < -1 && GetBalanceFactor(node.Right) <= 0)
                    return LeftRotate(node);

                if (balance < -1 && GetBalanceFactor(node.Right) > 0)
                {
                    node.Right = RightRotate(node.Right);
                    return LeftRotate(node);
                }

                return node;
            }

            public void q2_InOrder(Node node, List<string> list)
            {
                if (node == null) return;
                q2_InOrder(node.Left, list);
                list.Add(node.Data.Title);
                q2_InOrder(node.Right, list);
            }

            private Node GetMinNode(Node node)
            {
                Node current = node;

                while (current.Left != null)
                    current = current.Left;

                return current;
            }

        }

        public class q2_AVLTree
        {
            public Node Root;

            public void PrintInOrder()
            {
                InOrder(Root);
            }

            private void InOrder(Node node)
            {
                if (node == null) return;

                InOrder(node.Left);
                Console.WriteLine(node.Data.Title);
                InOrder(node.Right);
            }
        }

        public class Node
        {
            public q1_Books Data;
            public Node Left;
            public Node Right;
            public int Height;

            // Constructor
            public Node(q1_Books book)
            {
                Data = book;
                Left = null;
                Right = null;
                Height = 1;
            }

        }

        static void Main()
        {
            int i = 1;
            int searchYear;
            bool exists;
            int totalBooks;
            bool state = true;
            List<string> bookTitles = new List<string>();
            q1_AVLTree tree = new q1_AVLTree();
            q1_Books recent;
            q1_Books foundBook;

            tree.Root = tree.Insert(tree.Root, new q1_Books("The Silent Patient", "Alex Michaelides", 2019));
            tree.Root = tree.Insert(tree.Root, new q1_Books("The Great Gatsby", "F. Scott Fitzgerald", 1925));
            tree.Root = tree.Insert(tree.Root, new q1_Books("To Kill a Mockingbird", "Harper Lee", 1960));
            tree.Root = tree.Insert(tree.Root, new q1_Books("1984", "George Orwell", 1949));
            tree.Root = tree.Insert(tree.Root, new q1_Books("The Catcher in the Rye", "J.D. Salinger", 1951));
            tree.Root = tree.Insert(tree.Root, new q1_Books("Pride and Prejudice", "Jane Austen", 1813));
            tree.Root = tree.Insert(tree.Root, new q1_Books("Moby-Dick", "Herman Melville", 1851));
            tree.Root = tree.Insert(tree.Root, new q1_Books("The Hobbit", "J.R.R. Tolkien", 1937));

            tree.q2_InOrder(tree.Root, bookTitles);
            bookTitles.Sort();

            Console.WriteLine("Book Titles in Order\n");
            foreach (string title in bookTitles)
            {
                Console.WriteLine($"{i}. {title}");
                i++;
            }

            do
            {
                Console.WriteLine("\nBOOK AVL TREE \n\nPlease select an option");
                Console.WriteLine("1. Search by Year.\n2. Display Recent Book. \n3. Number of Books. \n4. Exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter year to search: ");
                        searchYear = int.Parse(Console.ReadLine());
                        foundBook = tree.BinarySearchByYear(tree.Root, searchYear);
                        if (foundBook != null)
                            Console.WriteLine($"\nBook from year {searchYear}: {foundBook.Title} by {foundBook.Author}");
                        else
                            Console.WriteLine($"\nNo book found from year {searchYear}");
                        break;
                    case 2:
                        recent = tree.GetMostRecentBook();
                        Console.WriteLine($"\nMost recent book: {recent.Title} ({recent.Year})");
                        break;
                    case 3:
                        totalBooks = tree.CountBooks(tree.Root);
                        Console.WriteLine($"\nTotal number of books: {totalBooks}");
                        break;
                    case 4:
                        Console.WriteLine("Exiting Program! Goodbye.");
                        state = false;
                        break;
                }
            } while (state);
        }
    }
}
