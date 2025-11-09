# Deliverable 1 and 2: Implement an AVL tree to store listings of books
A book listing has the following properties:

1.     Title (string)
2.     Author (string)
3.     Year (int)
   
In the AVL tree, the left child contains books with a year earlier than the parent and the right child contains books with a year later than the parent. Keep in mind that your AVL tree must be able to insert and delete nodes and self-balance.
You may hardcode data entries for the book objects.
Remember to label all classes belonging to this question with “q1_”.
You are also required to implement the following functionality:

1.     In-order traversal – print the title of every book in the tree in-order.
2.     Search by year – search whether a book from a particular year exists. You must take advantage of having an AVL tree structure by using a binary search.
3.     Display the most recent book – display the title of the book with the most recent year.
4.     Display the number of books – display the number of books in the tree.
   
# Deliverable 3: Efficient Ticketing System

Implement a priority queue to help the clinic schedule its patients. Priority is determined by the triage nurse. A highest priority of 0 is given to the most urgent patient cases, whilst the lowest priority of 4 is given to the least urgent patient cases.
Your program will be given a series of patient names (with priorities) to enter into the queue. Commands will also be given to dequeue patients out of the queue. Your program should print to terminal whenever a patient is dequeued.
Remember to label all classes belonging to this question with “q3_”.

# Deliverable 4: Sorting for Booking Agent

You are required to write a program that will read in this JSON data file. You may use the System.Text.Json library, included in the .NET standard library, to read in JSON files. Using a 3rd party JSON library is not recommended as your work will be penalised should your program fail to execute correctly.

Once you have read in the JSON data, your program will then sort the data according to the metric specified at the top of your program. You should implement this mechanism to change the sorting metric – the marker will manually change the metric in your code. During each run, this will allow the marker to sort your data by a different metric. Ideally, this will be a private string class variable that the marker can change in your code to change the metric. The metrics to consider are:

1.     name
2.     nightly_rate
3.     stars
4.     distance_from_airport

