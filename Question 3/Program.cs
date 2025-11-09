namespace Question_3
{
    internal class Program
    {
        static void Main()
        {
            bool state = true;
            PriorityQueue<string, int> patients = new PriorityQueue<string, int>();

            // Preloaded Patients in queue

            patients.Enqueue("Sarah Mokoena", 2);
            patients.Enqueue("Thabo Ndlovu", 0);
            patients.Enqueue("Nomsa Dlamini", 4);
            patients.Enqueue("Kabelo Molefe", 3);
            patients.Enqueue("Siphiwe Ntuli", 0);
            patients.Enqueue("Ayanda Zulu", 1);

            do
            {
                Console.WriteLine("Ticketing System\n");
                Console.WriteLine("1. View Patients in Queue");
                Console.WriteLine("2. Add Patient");
                Console.WriteLine("3. Dequeue Patient");
                Console.WriteLine("4. Exit");
                Console.Write("Enter: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        if (patients.Count == 0)
                        {
                            Console.WriteLine("No patients in queue.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nPatients in Queue:");

                            // Displays each patient inorder with regards to their priority

                            foreach (var item in patients.UnorderedItems.OrderBy(p => p.Priority))
                            {
                                Console.WriteLine($"Name: {item.Element}; Priority: {item.Priority}");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 2:

                        // Add patient into the queue

                        Console.WriteLine("Enter patient priority (0 - 4): ");
                        int priority = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter patient name: ");
                        string name = Console.ReadLine();
                        patients.Enqueue(name, priority);
                        Console.WriteLine($"Patient {name} is waiting in queue.");
                        break;
                    case 3:
                        if (patients.Count == 0)
                        {
                            Console.WriteLine("No patients to dequeue.\n");
                        }
                        else
                        {
                            // Dequeue the next patient in the queue (FIFO)

                            string next = patients.Dequeue();
                            Console.WriteLine($"Next patient to be treated: {next}\n");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Exiting Ticketing System. Goodbye.\n");
                        state = false;
                        break;
                }
            } while (state);

        }
    }
}
