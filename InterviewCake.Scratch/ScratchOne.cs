using System;
using System.Collections.Generic;

namespace InterviewCake.Scratch
{
    public class ScratchOne
    {

        public bool BinarySearchIterative(int[] arr, int value)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid = 0;

            while (low <= high)
            {
                mid = (high + low) / 2;
                var item = arr[mid];
                if (item == value) return true;
                if (item > value)
                {
                    high = mid - 1;

                }
                else
                    low = mid + 1;
            }
            return false;
        }

        public bool BinarySearch(int[] arr, int value)
        {
            if (arr == null || arr.Length == 0) return false;
            int low = 0;
            int high = arr.Length - 1;
            return BinarySearchRecursive(arr, low, high, value);

        }

        bool BinarySearchRecursive(int[] arr, int low, int high, int value)
        {
            if (high < low)
                return false;
            int mid = (high + low) / 2;
            int item = arr[mid];

            if (value > item)
                low = mid + 1;
            else if (value < item)
                high = mid - 1;
            else //val == item!
                return true;

            return BinarySearchRecursive(arr, low, high, value);
        }

        public int[] PrimeNumbers(int num)
        {
            List<int> primes = new List<int>(num) { 2 };
            int start = 3;
            while (primes.Count < num)
            {
                bool isPrime = true;
                var sqstart = (int)Math.Round(Math.Sqrt(start));
                for (int i = sqstart; i > 2; i--)
                {
                    if (i % 2 != 0)
                    {
                        if (start % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                if (isPrime)
                {
                    primes.Add(start);
                }
                start += 2;
            }
            return primes.ToArray();
        }

        public int[][] CreateNxMArray(int n, int m)
        {
            Random r = new Random();
            int[][] array = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int[] temp = new int[m];
                PopulateArray(temp, r);
                array[i] = temp;
            }
            return array;
        }

        private void PopulateArray(int[] temp, Random r)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = r.Next(2);
            }
        }

        //from CTCI page Arrays Question 1.7
        public void RotateMatrix(int[][] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            var n = matrix.Length;
            for (int layer = 0; layer < (n / 2); layer++)
            {
                int first = layer;
                int last = n - layer - 1;
                for (int j = first; j < last; j++)
                {
                    int offset = j - first;
                    int temp = matrix[first][j];
                    matrix[first][j] = matrix[last - offset][first];
                    matrix[last - offset][first] = matrix[last][last - offset];
                    matrix[last][last - offset] = matrix[j][last];
                    matrix[j][last] = temp;
                }
            }
        }
        //from CTCI page Arrays Question 1.8
        public void ZeroMatrix(int[][] matrix, int symbol = 0)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            var setCols = new HashSet<int>();
            var setRows = new HashSet<int>();

            int rowsLength = matrix.Length;
            int colsLength = matrix[0].Length;

            for (int row = 0; row < rowsLength; row++)
            {
                for (int col = 0; col < colsLength; col++)
                {
                    //if (setCols.Contains(col))
                    //    break;
                    if (matrix[row][col] == symbol)
                    {
                        setRows.Add(row);
                        setCols.Add(col);
                        break;
                    }
                }
            }

            for (int row = 0; row < rowsLength; row++)
            {
                if (setRows.Contains(row))
                {
                    for (int col = 0; col < colsLength; col++)
                    {
                        matrix[row][col] = symbol;
                    }
                }
                else
                {
                    foreach (var item in setCols)
                    {
                        matrix[row][item] = symbol;
                    }
                }
            }

            //for (int col = 0; col < colsLength; col++)
            //{
            //    foreach (var item in setCols)
            //    {
            //        matrix[col][item] = symbol;
            //    }
            //}

        }

        public int MinDistanceInMatrix(char[][] grid)
        {
            QItem source = new QItem(0, 0, 0);
            int n = grid.Length;
            bool[][] visited = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                visited[i] = new bool[n];
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    var cell = grid[row][col];
                    if (cell == '0')
                        visited[row][col] = true;
                    else if (cell == 's')
                    {
                        source.Row = row;
                        source.Col = col;
                    }
                }
            }

            Queue<QItem> q = new Queue<QItem>();
            q.Enqueue(source);
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (grid[current.Row][current.Col] == 'd')
                    return current.Distance;
                //up
                if(current.Row -1 >=0 && visited[current.Row-1][current.Col] == false)
                {
                    q.Enqueue(new QItem(current.Row - 1, current.Col, current.Distance + 1));
                    visited[current.Row - 1][current.Col] = true;
                }
                //down
                if (current.Row + 1 < n && visited[current.Row + 1][current.Col] == false)
                {
                    q.Enqueue(new QItem(current.Row + 1, current.Col, current.Distance + 1));
                    visited[current.Row + 1][current.Col] = true;
                }

                //left
                if (current.Col - 1 >= 0 && visited[current.Row][current.Col-1] == false)
                {
                    q.Enqueue(new QItem(current.Row, current.Col-1, current.Distance + 1));
                    visited[current.Row][current.Col-1] = true;
                }
                //right
                if (current.Col + 1 < n && visited[current.Row][current.Col + 1] == false)
                {
                    q.Enqueue(new QItem(current.Row, current.Col + 1, current.Distance + 1));
                    visited[current.Row][current.Col + 1] = true;
                }
            }

            return -1;
        }

        private class QItem
        {
            public QItem(int row, int col, int distance)
            {
                Row = row;
                Col = col;
                Distance = distance;
            }
            public int Row { get; set; }
            public int Col { get; set; }
            public int Distance { get; set; }
        }
    }
}
