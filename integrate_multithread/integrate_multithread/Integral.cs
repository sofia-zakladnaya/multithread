////using System;
using System.Collections.Generic;
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
        //Результаты интегрирования
        public double Value { get; set; }
        
        //Вычисление значения интеграла
        public void Solve()
        {
            //TODO
        }
    }

    //Делегат метода интегрирования
    public delegate void IntgMethod();
    //Делегат подынтегральной функции
    public delegate double Function(double x);
}
