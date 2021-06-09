using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransposeMatrix
{
    public class Matrix
    {
        private double[,] data;

        private int m;
        public int M { get => this.m; }

        private int n;
        public int N { get => this.n; }

        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
            this.ProcessFunctionOverData((i, j) => this.data[i, j] = 0);
        }

        public double this[int x, int y]
        {
            get
            {
                return this.data[x, y];
            }
            set
            {
                this.data[x, y] = value;
            }
        }

        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for(int i = 0; i < this.M; i++)
            {
                for(int j = 0; j < this.N; j++)
                {
                    func(i, j);
                }
            }
        }

        public void CreateTransposeMatrix()
        {
            var result = new Matrix(this.N, this.M);
            result.ProcessFunctionOverData((i, j) => result[i, j] = this[j, i]);
            Console.WriteLine();

        }


        public void OutputMatrix(Matrix matrix)
        {
            Console.WriteLine("Введите элементы матрицы: ");
            for (int i = 0; i < this.M; i++)
            {
                for(int j = 0; j < this.N; j++)
                { 
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            CreateTransposeMatrix();
        }
    }
}
