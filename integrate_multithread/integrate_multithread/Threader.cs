using System;
using System.Collections.Generic;
using System.Threading;

namespace integrate_multithread
{
    //Распределение задачи по потокам, сбор результатов, подсчёт времени и ускорения
    class Threader
    {
        //Список потоков
        public List<Thread> Threads { get; set; }
        //Время выполнения
        public TimeSpan TotalTime { get; set; }

        //Распределение интервалов по потокам
        public void Distribute(Integral I, int threadscount)
        {
            //Инициализируем список потоков
            Threads = new List<Thread>();
            //Делим отрезок интегрирования между потоками
            List<Integral> SubIntegrals = new List<Integral>();
            double h = (I.UpperLimit - I.LowerLimit) / threadscount;
            for (int i=0;i<threadscount;i++)
            {
                Integral intg = I;
                //Изменяем пределы и точность
                intg.Eps /= threadscount;
                intg.LowerLimit = I.LowerLimit + i*h;
                intg.UpperLimit = I.LowerLimit + (i + 1) * h;
                //Включаем интеграл в список
                SubIntegrals.Add(intg);

                //Создаём поток и добавляем в список
                ThreadStart solver = new ThreadStart(SubIntegrals[i].Solve);
                Thread thread = new Thread(solver);
                Threads.Add(thread);
            }

        }

        //Вычисление ускорения
        public double Acceleration(TimeSpan onethread)
        {
            return (onethread.TotalMilliseconds /TotalTime.TotalMilliseconds);
        }
    }

    //public delegate double Function(double x);

}
