﻿using System;
using System.Collections.Generic;
////using System.Linq;
////using System.Text;
using System.Threading;
﻿////using System;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;


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
        //Метод интегрирования
        public IntgMethod Method { get; set; }

        //Разбиения
        public List<Integral> SubIntegrals { get; set; }
        //Результаты интегрирования
        public double Value { get; set; }


        //Конструкторы
        public Integral()
        {
            SubIntegrals = new List<Integral>();
        }
        public Integral(int func)
        {
            SubIntegrals = new List<Integral>();
            F = GetFuncDelegate(func);
        }
        public Integral(double lower, double upper, int func, double eps,IntgMethod method)
        {
            SubIntegrals = new List<Integral>();
            F = GetFuncDelegate(func);
            LowerLimit = lower;
            UpperLimit = upper;
            Eps = eps;
            Method = method;
        }
        public Integral(double lower, double upper, Function func, double eps, IntgMethod method)
        {
            SubIntegrals = new List<Integral>();
            F = func;
            LowerLimit = lower;
            UpperLimit = upper;
            Eps = eps;
            Method = method;
        }
        //Вычисление значения интеграла
        public void Solve()
        {
            Value = 22;
            Thread.Sleep(2000);
            //TODO
            
        }

        //Сумма сумма по разбиениям
        public void TotalValue()
        {
            Value = 0;
            foreach(Integral sub in  SubIntegrals)
            {
                Value += sub.Value;
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
                default:
                    {
                        return Math.Exp;
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
        private void Rectangle()
        {
            throw new Exception("Метод нереализован");
        }
        
        //Метод трапеций
        private void Trapezoid()
        {
            throw new Exception("Метод нереализован");
        }
        //Метод Симпсона
        private void Simpson()
        {
            throw new Exception("Метод нереализован");
        }
        
        
    }

    //Делегат метода интегрирования
    public delegate void IntgMethod();
    //Делегат подынтегральной функции
    public delegate double Function(double x);
}
