using System;
using System.Collections.Generic;
////using System.Linq;
////using System.Text;
//using System.Threading;

namespace integrate_multithread
{
    class Integral
    {
        //Подынтегральная функция
        public Function F { get; set; }
        //Пределы интегрирования
        public double LowerLimit { get; set; }
        public double UpperLimit { get; set; }
        //Точность
        public double Eps { get; set; }
        //Число разбиений
        public int N { get; set; }
        //Метод интегрирования
        public IntgMethod Method { get; set; }
        //Разбиения
       // public List<Integral> SubIntegrals { get; set; }
        //Результаты интегрирования
        public double Value { get; set; }


        //Конструкторы
        public Integral()
        {
           // SubIntegrals = new List<Integral>();
            N = 8;
        }
        public Integral(int func)
        {
            //SubIntegrals = new List<Integral>();
            F = GetFuncDelegate(func);
            N = 8;
        }
        public Integral(double lower, double upper, int func, double eps,IntgMethod method)
        {
           // SubIntegrals = new List<Integral>();
            F = GetFuncDelegate(func);
            LowerLimit = lower;
            UpperLimit = upper;
            Eps = eps;
            Method = method;
        }
        public Integral(double lower, double upper, Function func, double eps, IntgMethod method)
        {
           // SubIntegrals = new List<Integral>();
            F = func;
            LowerLimit = lower;
            UpperLimit = upper;
            Eps = eps;
            Method = method;
        }
        //Вычисление значения интеграла
        public void Solve()
        {
            // Value = Method(LowerLimit,UpperLimit);
            //Value = 22;
            //Thread.Sleep(2000);
            //TODO
           // int N = 10;
            double S = 0;
            double h = (UpperLimit - LowerLimit) / N;
            for (int i = 0; i < N; i++)
            {
                //метод трапеций
                //S += ((F(x(i, h)) + F(x(i + 1, h))) / 2) * (x(i + 1, h) - x(i, h));
                S += F((x(i, h) + x(i + 1, h)) / 2) * (x(i + 1, h) - x(i, h)); //метод прямоугольников
            }
            Value = S;
            S = 0;
            N *= 2;
            h = (UpperLimit - LowerLimit) / N;
            for (int i = 0; i < N; i++)
            {
                //метод трапеций
                //S += ((F(x(i, h)) + F(x(i + 1, h))) / 2) * (x(i + 1, h) - x(i, h));
                S += F((x(i, h) + x(i + 1, h)) / 2) * (x(i + 1, h) - x(i, h)); //метод прямоугольников
            }

            while (Math.Abs(Value - S) > Eps)
            {
                Value = S;
                S = 0;
                N *= 2;
                h = (UpperLimit - LowerLimit) / N;
                for (int i = 0; i < N; i++)
                {
                    //метод трапеций
                    //S += ((F(x(i, h)) + F(x(i + 1, h))) / 2) * (x(i + 1, h) - x(i, h));
                    S += F((x(i, h) + x(i + 1, h)) / 2) * (x(i + 1, h) - x(i, h)); //метод прямоугольников
                }
            }

        }


        //i-й узел решётки
        private double x(int i,double h)
        {
            return LowerLimit + i * h;
        }

        //Сумма сумма по разбиениям
        public void TotalValue(List<Integral> I)
        {
            Value = 0;
            foreach(Integral i in  I/*SubIntegrals*/)
            {
                Value += i.Value;
            }
        }

        //Получение делегата подынтегральной функции
        private Function GetFuncDelegate(int i)
        {
            //TODO: дописать весь список функций
            switch(i)
            {
                case 0:
                    {
                        return Math.Sin;
                    }
                case 1:
                    {
                        return Math.Exp;
                    }
                case 2:
                    {
                        return F1;
                    }
                case 3:
                    {
                        return F2;
                    }
                default:
                    {
                        return Math.Abs;
                    }
            }
        }
        //Получение делегата подынтегральной функции
        public IntgMethod GetMethodDelegate(int i)
        {
            //TODO: дописать весь список функций
            switch (i)
            {
                case 0:
                    {
                        return Rectangle;
                    }
                case 1:
                    {
                        return Trapezoid;
                    }
                default:
                    {
                        return Simpson;
                    }

            }
        }

        //Методы интегрирования
        //Метод прямоугольников
        public double Rectangle(double a, double b,double e)
        {
            throw new Exception("Метод нереализован");
            // int N = 10;
            // double S1 = 0;
            // double S2 = 0;
            // double h = (b - a) / N;
            // for (int i = 0; i < N; i++)
            // {
            //     double f = F((x(i, h,a) + x(i + 1, h,a)) / 2);
            //     double dx = (x(i + 1, h,a) - x(i, h,a));
            //     S1 +=  (f*dx);
            // }
            // //Value = S;
            //// S = 0;
            // N *= 2;
            // h = (b - a) / N;
            // for (int i = 0; i < N; i++)
            // {
            //     S2 += F((x(i, h,a) + x(i + 1, h,a)) / 2) * (x(i + 1, h,a) - x(i, h,a));
            // }

            // while (Math.Abs(S1 - S2) > e)
            // {
            //     S1 = S2;
            //     S2 = 0;
            //     N *= 2;
            //     h = (b - a) / N;
            //     for (int i = 0; i < N; i++)
            //     {
            //         S2 += F((x(i, h,a) + x(i + 1, h,a)) / 2) * (x(i + 1, h,a) - x(i, h,a));
            //     }
            // }

            // return S2;
        }
        
        //Метод трапеций
        public double Trapezoid(double a, double b, double e)
        {
            throw new Exception("Метод нереализован");
        }
        //Метод Симпсона
        public double Simpson(double a, double b, double e)
        {
            throw new Exception("Метод нереализован");
        }

        //Пример1
        public double F1(double x)
        {
            return 1 / (x * Math.Exp(x));
        }

        //Пример2
        public double F2(double x)
        {
            return 1 / Math.Log(x);
        }
    }

    //Делегат метода интегрирования
    public delegate double IntgMethod(double a, double b,double e);
    //Делегат подынтегральной функции
    public delegate double Function(double x);

    
}
