using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace integrate_multithread
{
    //Распределение задачи по потокам, сбор результатов, подсчёт времени и ускорения
    class Threader
    {
        //Список потоков
        public List<Thread> Threads { get; set; }
        //Время выполнения
        public TimeSpan TotalTime { get { return FinishTime - StartTime; } }
        private DateTime StartTime;
        private DateTime FinishTime;


        public Threader()
        {
            Threads = new List<Thread>();
            StartTime = DateTime.Now;
            FinishTime = DateTime.Now;
        }


        //Распределение интервалов по потокам
        public void Distribute(ref Integral I,int threadscount, bool regular)
        {
            if (regular)
            {
                //Инициализируем список потоков
                Threads = new List<Thread>();
                //Делим отрезок интегрирования между потоками
                //SubIntegrals = new List<Integral>();
                double h = (I.UpperLimit - I.LowerLimit) / threadscount;
               // double h = (I.UpperLimit - I.LowerLimit) / I.N;
                for (int i = 0; i < threadscount; i++)
                { 
                    Integral intg = new Integral(I.LowerLimit + i * h, I.LowerLimit + (i + 1) * h,I.F,I.Eps/threadscount,I.Method);
                    //Изменяем пределы и точность
                    intg.Eps /= threadscount;
                    if (threadscount > 1)
                    {
                        if (intg.LowerLimit + i * h <= I.UpperLimit)
                        {
                            intg.N = Math.Round((double)I.N / (double)threadscount);
                        }
                        else
                        {
                            intg.N = I.N - (i - 1) * I.N;
                        }
                    }
                    else
                    {
                        intg.N = I.N;
                    }
                    intg.LowerLimit = I.LowerLimit + i * h;
                    intg.UpperLimit = I.LowerLimit + (i + 1) * h;
                    //Включаем интеграл в список
                    I.SubIntegrals.Add(intg);
                    //Создаём поток и добавляем в список
                    ThreadStart solver = new ThreadStart(I.SubIntegrals[i].Solve);
                    Thread thread = new Thread(solver);
                    Threads.Add(thread);
                }
            }
            else
            {
                throw new Exception("Неравномерное разбиение в разработке");
            }
        }

        //Старт потоков
        public void StartAll()
        {
            //Фиксируем время
            StartTime = DateTime.Now;
            //Начинаем выполнение потоков
            Parallel.ForEach(Threads,(thread)=>
            {
                thread.Start();
            });
        }

        //Завершение потоков
        public void JoinAll()
        {
            Parallel.ForEach(Threads, (thread) =>
            {
                thread.Join();
            });
            //Фиксируем время
            FinishTime = DateTime.Now;
        }

        ////Вычисление ускорения
        //public double Acceleration(TimeSpan onethread)
        //{
        //    return (onethread.TotalMilliseconds /TotalTime.TotalMilliseconds);
        //}
    }

    //public delegate double Function(double x);
   
}
