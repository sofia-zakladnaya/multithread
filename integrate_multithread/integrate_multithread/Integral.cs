﻿using System;
using System.Collections.Generic;
using System.Threading;

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
        //Результаты интегрирования
        public double Value { get; set; }

        //счётчики для рекурсии
        public int n1 { get; set; } //общее кол=во потоков
        public int k { get; set; } //текущее
        public DateTime StartTime; //время
        public DateTime FinishTime;
        public TimeSpan TotalTime { get { return FinishTime - StartTime; } }

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

        public Integral(double lower, double upper, Function func, double eps, IntgMethod method, int N1, int K1)
        {
            // SubIntegrals = new List<Integral>();
            F = func;
            LowerLimit = lower;
            UpperLimit = upper;
            Eps = eps;
            Method = method;
            N = 2;
            n1 = N1;
            k = K1;
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

        }

        //рекурсивное решение
        public void SolveR()
        {
            if(k<1)
            {
                Value = 0;
                return;
            }
            //Создаём поток для рекурсивного вызова
            double h = (UpperLimit - LowerLimit) / k;
            Integral I = new Integral(LowerLimit + h, UpperLimit, F, Eps, Method,n1,k - 1);
            ThreadStart solver = new ThreadStart(I.SolveR);
            Thread thread = new Thread(solver);
            //Запускаем поток
            thread.Start();
            //Запускаем решение на текущем подотрезке
            Integral I0 = new Integral(LowerLimit, LowerLimit + h, F, Eps/n1, Method);
            I0.Solve();
            //Синхронизируем
            thread.Join();
            //Складываем результаты
            Value = I.Value + I0.Value;
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
            foreach(Integral i in  I)
            {
                Value += i.Value;
            }
        }

        //Получение делегата подынтегральной функции
        private Function GetFuncDelegate(int i)
        {
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
            if(Subs.Count<2)
            {
                return;
            }
            bool found = true; //Найден отрезок с большой производной
            while(found)
            {
                found = false;
                //поиск отрезка с максимальной производной
                double maxTg = 0;
                int imax = -1;
                for (int i = 0; i < Subs.Count; i++)
                {
                    double atg = Math.Abs(Tg(Subs[i].LowerLimit, Subs[i].UpperLimit));
                    if ((atg > maxTg) && ((Subs[i].UpperLimit - Subs[i].LowerLimit) > Subs[i].Eps))
                    {
                        maxTg = atg;
                        imax = i;
                    }
                }
                //Сравниваем максимум с параметром корректировки
                if (imax >= 0)
                {


                    if ((maxTg > K0) && (Subs[imax].UpperLimit - Subs[imax].LowerLimit) > Subs[imax].Eps*10)
                    {
                        found = true;
                        bool changed = false;
                        //Сжимаем отрезок с максимальной производной
                        while ((Math.Abs(Tg(Subs[imax].LowerLimit, Subs[imax].UpperLimit)) > K0)
                            && (Subs[imax].UpperLimit - Subs[imax].LowerLimit) > Subs[imax].Eps*10)
                        {
                            double middle = (Subs[imax].UpperLimit + Subs[imax].LowerLimit) / 2;
                            if (Math.Abs(Tg(Subs[imax].LowerLimit, middle)) > Math.Abs(Tg(middle, Subs[imax].UpperLimit))
                                && (imax < Subs.Count-1))
                            {
                                changed = true;
                                Subs[imax].UpperLimit = middle;
                            }
                            else if(imax > 0)
                            {
                                changed = true;
                                Subs[imax].LowerLimit = middle;
                            }

                        }
                        if (changed)
                        {
                            //Пристыковываем соседние отрезки
                            if (imax > 0)
                            {
                                Subs[imax - 1].UpperLimit = Subs[imax].LowerLimit;
                            }

                            if (imax < Subs.Count - 1)
                            {
                                Subs[imax + 1].LowerLimit = Subs[imax].UpperLimit;
                            }
                        }
                    }
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
