using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Findsmallest
{
    class Program
    {
        private static readonly int[][] Data = new int[][]{new int[]{1,5,4,2}, 
            new int[]{3,2,4,11,4},
            new int[] {33,2,3,-1, 10},
            new int[] {3,2,8,9,-1},
            new int[] {22,1,9,-3, -3}
        };

        private static int FindSmallest(int[] numbers)
        {
            if (numbers.Length < 1)
            {
                throw new ArgumentException("There must be at least one element in the array");
            }

            int smallestSoFar = numbers[0];
            foreach (int number in numbers)
            {
                
                if (number < smallestSoFar)
                {
                    smallestSoFar = number;
                }
                
            }
            //Console.WriteLine(": " + smallestSoFar);
            //Console.WriteLine(String.Join(", ", numbers) + ": " + smallestSoFar);
            return smallestSoFar;
        }

        static void Main(string[] args)
        {
            List < Task<int> > tasklist= new List<Task<int>>();
            foreach (int[] data in Data)
            {
                //int smallest = FindSmallest(data);
                //Thread t1 = new Thread(()=> FindSmallest(data));
                Task<int> task1 = Task<int>.Factory.StartNew(() => FindSmallest(data));
                //Task.Factory.StartNew(() => FindSmallest(data));
                tasklist.Add(task1);
                
                //Console.WriteLine(String.Join(", ", data) + ": " + smallestSoFar);
            }
            
                foreach (Task<int> task in tasklist)
                {
                        if (task.Result != null)
                        {
                            Console.WriteLine(task.Result);
                           
                        }
                }
            
            
            Console.ReadLine();
        }
    }
}