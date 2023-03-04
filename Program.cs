using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int n;

        string? inputN = Console.ReadLine();
        if(int.TryParse(inputN, out n) && n <= 100000)
        { 
            n = int.Parse(inputN);
        }
        else
        {
            throw new ArgumentException("Invalid input");
        }

        int[] arr = new int[n];


        string? inputNumbers = Console.ReadLine();
        if(inputNumbers != null)
        {
            string[] numbers = inputNumbers.Split();
            for (int i = 0; i < n; i++)
            {
                if (int.TryParse(numbers[i], out arr[i]) && (arr[i] > 0 && arr[i] < 1000000))
                {
                    arr[i] = int.Parse(numbers[i]);
                }
                else
                {
                    throw new ArgumentException("Invalid input");

                }
            }
        }
        else
        {
            throw new ArgumentException("Invalid input");
        }
       
        
        int k;

        string? inputK = Console.ReadLine();
        if(int.TryParse(inputK, out k) && k < 100000 )
        {
            if(k >= 1 && k <= n)
            {
                k = int.Parse(inputK);
            }
            else
            {
                throw new ArgumentException("Invalid input");

            }
        }
        else
        {
            throw new ArgumentException("Invalid input");
        }




        Deque deque = new Deque();

        for (int i = 0; i < k; i++)
        {
            while (!deque.IsEmpty() && arr[i] >= arr[deque.PeekBack()])
            {
                deque.PopBack();
            }
            deque.PushBack(i);
        }


        for (int i = k; i < n; i++)
        {
            Console.Write(arr[deque.PeekFront()] + " ");


            while (!deque.IsEmpty() && deque.PeekFront() <= i - k)
            {
                deque.PopFront();
            }

          
            while (!deque.IsEmpty() && arr[i] >= arr[deque.PeekBack()])
            {
                deque.PopBack();
            }


            deque.PushBack(i);
        }

        Console.Write(arr[deque.PeekFront()]);


    }




    class Deque
    {
        private LinkedList<int> deque;

        public Deque()
        {
            deque = new LinkedList<int>();
        }

        public void PushFront(int x)
        {

            deque.AddFirst(x);
        }

        public void PushBack(int x)
        {
            deque.AddLast(x);
        }

        public int PopFront()
        {

            int x = deque.First?.Value ?? throw new InvalidOperationException("Deque is empty.");
            deque.RemoveFirst();
            return x;
        }

        public int PopBack()
        {
            int x = deque.Last?.Value ?? throw new InvalidOperationException("Deque is empty.");
            deque.RemoveLast();
            return x;
        }

        public int PeekFront()
        {
            return deque.First?.Value ?? throw new InvalidOperationException("Deque is empty.");
        }

        public int PeekBack()
        {
            return deque.Last?.Value ?? throw new InvalidOperationException("Deque is empty.");
        }

        public bool IsEmpty()
        {
            return deque.Count == 0;
        }
    }
}

