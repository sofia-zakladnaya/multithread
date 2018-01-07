﻿using System;
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
            N = 2;
        }
        public Integral(int func)
        {
            //SubIntegrals = new List<Integral>();
            F = GetFuncDelegate(func);
            N = 2;
        }
        public Integral(double lower, double upper, int func, double eps,IntgMethod method)
        {
           // SubIntegrals = new List<Integral>();
            F = GetFuncDelegate(func);
            LowerLimit = lower;
            UpperLimit = upper;
            Eps = eps;
            Method = method;
            N = 2;
        }

        public Integral(double lower, double upper, int func, double eps, int method)
        {
            // SubIntegrals = new List<Integral>();
            F = GetFuncDelegate(func);
            LowerLimit = lower;
            UpperLimit = upper;
            Eps = eps;
            Method = GetMethodDelegate(method);
            N = 2;
        }
        public Integral(double lower, double upper, Function func, double eps, IntgMethod method)
        {
           // SubIntegrals = new List<Integral>();
            F = func;
            LowerLimit = lower;
            UpperLimit = upper;
            Eps = eps;
            Method = method;
            N = 2;
        }
        //Вычисление значения интеграла
        public void Solve()
        {
            double S = Method(LowerLimit,UpperLimit,N);
            N *= 2;
            Value = Method(LowerLimit, UpperLimit, N);
            while (Math.Abs(Value - S)>Eps)
            {
                S = Value;
                N *= 2;
                Value = Method(LowerLimit, UpperLimit, N);
            }
            // Value = Method(LowerLimit,UpperLimit);
            //Value = 22;
            //Thread.Sleep(2000);
            //TODO
            // int N = 10;
            //double S = 0;
            //double h = (UpperLimit - LowerLimit) / N;
            //for (int i = 0; i < N; i++)
            //{
            //    //метод трапеций
            //    //S += ((F(x(i, h)) + F(x(i + 1, h))) / 2) * (x(i + 1, h) - x(i, h));
            //    S += F((x(i, h) + x(i + 1, h)) / 2) * (x(i + 1, h) - x(i, h)); //метод прямоугольников
            //}
            //Value = S;
            //S = 0;
            //N *= 2;
            //h = (UpperLimit - LowerLimit) / N;
            //for (int i = 0; i < N; i++)
            //{
            //    //метод трапеций
            //    //S += ((F(x(i, h)) + F(x(i + 1, h))) / 2) * (x(i + 1, h) - x(i, h));
            //    S += F((x(i, h) + x(i + 1, h)) / 2) * (x(i + 1, h) - x(i, h)); //метод прямоугольников
            //}

            //while (Math.Abs(Value - S) > Eps)
            //{
            //    Value = S;
            //    S = 0;
            //    N *= 2;
            //    h = (UpperLimit - LowerLimit) / N;
            //    for (int i = 0; i < N; i++)
            //    {
            //        //метод трапеций
            //        //S += ((F(x(i, h)) + F(x(i + 1, h))) / 2) * (x(i + 1, h) - x(i, h));
            //        S += F((x(i, h) + x(i + 1, h)) / 2) * (x(i + 1, h) - x(i, h)); //метод прямоугольников
            //    }
            //}

        }


        //i-й узел решётки
        private double x(double a,int i,double h)
        {
            return a + i * h;
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
                case 4:
                    {
                        return F3;
                    }
                default:
                    {
                        return Math.Abs;
                    }
            }
        }
        //Получение делегата подынтегральной функции
        private IntgMethod GetMethodDelegate(int i)
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
        private double Rectangle(double a, double b, int n)
        {
            //throw new Exception("Метод нереализован");
            double S = 0; //результат
            double h = (b - a) / n; //шаг

            for (int i = 0; i < n; i++)
            {
                double xi = x(a,i, h);
                double xi1 = x(a,i + 1, h);
                S += F((xi + xi1) / 2) * (xi1 - xi);
            }

            return S;
        }
        
        //Метод трапеций
        private double Trapezoid(double a, double b, int n)
        {
            //throw new Exception("Метод нереализован");
            double S = 0; //результат
            double h = (b - a) / n; //шаг
            S = (F(x(a,0,h))+ F(x(a, n, h))) / 2;
            for (int i = 1; i < n; i++)
            {
                S += F(x(a, i, h));
            }

            S *= h;
            return S;
        }
        //Метод Симпсона
        private double Simpson(double a, double b, int n)
        {
            throw new Exception("Метод нереализован");
        }

        //Пример1
        private double F1(double x)
        {
            return 1 / (x * Math.Exp(x));
        }

        //Пример2
        private double F2(double x)
        {
            return 1 / Math.Log(x);
        }

        //Пример 3 (плотность нормального распределения с параметрами 0; 0.05)
        private double F3(double x)
        {
            return 636619.772 * Math.Exp(-200000000*x*x);
        }

        //Делегат метода интегрирования
        public delegate double IntgMethod(double a, double b, int n);
        //Делегат подынтегральной функции
        public delegate double Function(double x);

        //Исправление разбиения
        public void CorrectGrid(ref List<Integral> Subs, double K0)
        {
            //Ищем отрезки с максимальной и минимальной производной(модуль)
            double maxTg = Math.Abs(Tg(Subs[0].LowerLimit, Subs[0].UpperLimit));
            // double minTg = ATg(Subs[0].LowerLimit, Subs[0].UpperLimit);
            int imax = 0;
           // int imin = 0;
            for(int i=1;i<Subs.Count;i++)
            {
                double atg = Math.Abs(Tg(Subs[i].LowerLimit, Subs[i].UpperLimit));
                if (atg > maxTg)
                {
                    maxTg = atg;
                    imax = i;
                }
                //else if (atg < minTg)
                //{
                //    minTg = atg;
                //    imin = i;
                //}
            }
            /*Если максимум больше К0, сжимаем отрезок с максимальной производной в 2 раза в сторону 
большего значения функции(по модулю),пока модуль производной не станет меньше или равным к0 остальное пытаемся разбить поровну между остальными потоками*/
            //double K = maxTg / minTg;
            bool changed = false; //флаг изменения            
            double a = Subs[0].LowerLimit;//границы целого отрезка
            double b = Subs[Subs.Count-1].UpperLimit;

            while ((Math.Abs(Tg(Subs[imax].LowerLimit, Subs[imax].UpperLimit))>K0) 
                && ((Subs[imax].UpperLimit - Subs[imax].LowerLimit) > Subs[imax].Eps))
            {
                double middle = (Subs[imax].UpperLimit + Subs[imax].LowerLimit) / 2;
                if(Math.Abs(Tg(Subs[imax].LowerLimit, middle))>= Math.Abs(Tg(middle, Subs[imax].UpperLimit)))
                {
                    Subs[imax].UpperLimit = middle;
                }
                else
                {
                    Subs[imax].LowerLimit = middle;
                }
                changed = true;
            }
           
            if(changed)
            {
                //Если отрезок с максимумом с краю, то разбиваем остальную часть поровну
                if(Subs[imax].LowerLimit==a)
                {
                    double h = (b - Subs[imax].UpperLimit) / (Subs.Count-1);
                    for (int i=1;i<Subs.Count;i++)
                    {
                        Subs[i].LowerLimit = Subs[i - 1].UpperLimit;
                        Subs[i].UpperLimit = Subs[i].LowerLimit + h;
                    }
                }
                else if(Subs[imax].UpperLimit == b)
                {
                    double h = (Subs[imax].LowerLimit - a) / (Subs.Count - 1);
                    for (int i = 0; i < Subs.Count-1; i++)
                    {
                        Subs[i].LowerLimit = a + h*i;
                        Subs[i].UpperLimit = Subs[i].LowerLimit + h;
                    }
                }
                /*Если слева не помещается ни одного целого отрезка, принимаем эту часть за один отрезок.
                  Если слева от сжатого отрезка помещается положительное число отрезков(как поровну), то разбиваем эту часть, 
                 округляя число отрезков в меньшую сторону. Часть справа разбиваем на оставшееся число отрезков*/
                else
                {

                }
            }

        }

        //Оценка производной(тангенс угла наклона прямой)
        private double Tg(double a, double b)
        {
            return (F(b) - F(a)) / (b - a);
        }

    }

    

    
}
