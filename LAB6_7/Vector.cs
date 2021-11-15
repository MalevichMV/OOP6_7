using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_7
{
    class Vector : Matrix
    {
        public Vector(int r = 3) : base(r, 1)
        {
            mtr_id = IDS;
            Console.WriteLine("Вызвался конструктор и создалася вектор  " + mtr_id);
        }
        public Vector(int r, Func<uint, double> genVec) : base(r, 1)
        {
            for (uint i = 0; i < r; i++)
                mtr[i] = genVec(i);
            mtr_id = IDS;
            Console.WriteLine("Вызвался конструктор и создалася вектор  " + mtr_id);
        }
        public Vector(Matrix other) : base(other)
        {
            if (cols > 1)
                throw new Exception("Ошибка при копировании");
            mtr_id = IDS;
            Console.WriteLine("Вызвался конструктор и скопировался вектор " + mtr_id);
        }
        ~Vector()
        {
            Console.WriteLine("Вызвался деструктор и удалился вектор " + mtr_id);
        }
        public static Vector operator +(Vector A, Vector B)
        {
            if (A.CheckForSum(B) && !A.isNULL())
            {
                if (!A.isNULL())
                {
                    Vector New = new Vector(A);
                    for (int i = 0; i < (A.rows * A.cols); i++)
                    {
                        New.mtr[i] = A.mtr[i] + B.mtr[i];
                    }
                    return New;
                }
                else return A;
            }
            else
                throw new ArgumentException("Ошибка! Вектора с номерами " + A.mtr_id + " и " + B.mtr_id + " нельзя складывать!");
        }

        public static Vector operator -(Vector A, Vector B)
        {
            if (A.CheckForSum(B))
            {
                if (!A.isNULL())
                {
                    Vector New = new Vector(A);
                    for (int i = 0; i < (A.rows * A.cols); i++)
                    {
                        New.mtr[i] = A.mtr[i] - B.mtr[i];
                    }
                    return New;
                }
                else return A;
            }
            else
                throw new ArgumentException("Ошибка! Вектора с номерами " + A.mtr_id + " и " + B.mtr_id + " нельзя вычитать!");
        }

        public static Vector operator *(Vector A, double k)
        {
            if (!A.isNULL())
            {
                Vector New = new Vector(A);
                for (int i = 0; i < (A.rows * A.cols); i++)
                {
                    New.mtr[i] = A.mtr[i] *= k;
                }
                return New;
            }
            else return A;
        }
        public static Matrix operator *(Vector A, Vector B)
        {
            if (A.CheckForMult(B))
            {
                if (!A.isNULL())
                {
                    Matrix C = new Matrix(A.rows, B.cols);
                    for (int i = 0; i < A.rows; i++)
                    {
                        for (int j = 0; j < B.cols; j++)
                        {
                            C[i + 1, j + 1] = 0;
                        }
                    }
                    for (int i = 0; i < A.rows; i++)
                    {
                        for (int j = 0; j < B.cols; j++)
                        {
                            for (int k = 0; k < A.cols; k++)
                                C[i + 1, j + 1] += A[i + 1, k + 1] * B[k + 1, j + 1];
                        }
                    }
                    return C;
                }
                else return A;
            }
            else
                throw new ArgumentException("Ошибка! Вектора с номерами " + A.mtr_id + " и " + B.mtr_id + " нельзя умножать!");
        }
        public double this[int r]
        {
            get
            {
                if (r <= rows && r > 0)
                    return this.mtr[(r - 1)];
                else
                    throw new IndexOutOfRangeException("Выход за границы объекта " + mtr_id);
            }
            set
            {
                if (r <= rows && r > 0)
                    this.mtr[(r - 1)] = value;
                else
                    throw new IndexOutOfRangeException("Выход за границы объекта " + mtr_id);
            }
        }
    }
}
