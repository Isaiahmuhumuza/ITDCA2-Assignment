using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Question_4
{
    internal class Program
    {
        // Metric to change method of sorting
        private static string metric = "nightly_rate";

        public class q4_BookingAgents
        {

            [JsonPropertyName("id")]
            public int id { get; set; }

            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("nightly_rate")]
            public int nightly_rate { get; set; }

            [JsonPropertyName("stars")]
            public int stars { get; set; }

            [JsonPropertyName("distance_from_airport")]
            public int distance_from_airport { get; set; }
        }

        static void Main()
        {
            string json = File.ReadAllText("BookingAgents.json");

            List<q4_BookingAgents> agents = JsonSerializer.Deserialize<List<q4_BookingAgents>>(json);

            QuickSort(agents, 0, agents.Count - 1);

            foreach (var agent in agents)
            {
                Console.WriteLine(agent.name);
            }
        }

        static void QuickSort(List<q4_BookingAgents> list, int left, int right)
        {
            // Recursively sorts the list using the QuickSort algorithm.
            if (left < right)
            {
                int pivotIndex = Partition(list, left, right);
                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, right);
            }
        }

        static int Partition(List<q4_BookingAgents> list, int left, int right)
        {
            // Pivot is chosen as the last element in this section of the list
            q4_BookingAgents pivot = list[right];

            int i = left - 1;

            // Loop through the list and compare each item to the pivot
            for (int j = left; j < right; j++)
            {
                if (Compare(list[j], pivot) <= 0)
                {
                    i++;
                    Swap(list, i, j);
                }
            }

            Swap(list, i + 1, right);

            return i + 1;
        }

        static int Compare(q4_BookingAgents a, q4_BookingAgents b)
        {
            // Compares two agent objects based on the selected metric.
            return metric switch
            {
                "name" => string.Compare(a.name, b.name, StringComparison.OrdinalIgnoreCase),
                "nightly_rate" => a.nightly_rate.CompareTo(b.nightly_rate),
                "stars" => a.stars.CompareTo(b.stars),
                "distance_from_airport" => a.distance_from_airport.CompareTo(b.distance_from_airport),
                _ => 0 // default case
            };
        }

        static void Swap(List<q4_BookingAgents> list, int i, int j)
        {
            // Swaps two elements in the list (standard swap operation)
            q4_BookingAgents temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
