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
        //параметр для корректировки разбиения
        public double K { get; set; }


        public Threader()
        {
            Threads = new List<Thread>();
            StartTime = DateTime.Now;
            FinishTime = DateTime.Now;
        }

        public Threader(double k)
        {
            Threads = new List<Thread>();
            StartTime = DateTime.Now;
            FinishTime = DateTime.Now;
            K = k;
        }

        //Распределение интервалов по потокам
        public void Distribute(Integral I,ref List<Integral> SubIntegrals,int threadscount, bool regular)
        {
            //Число потоков должно быть не меньше 1
            if (threadscount < 1)
            {
                throw new Exception("Неверное число потоков");
            }
            //Равномерная сетка
            if (regular)
            {
                //Инициализируем список потоков
                Threads = new List<Thread>();
                //Делим отрезок интегрирования между потоками
                double h = (I.UpperLimit - I.LowerLimit) / threadscount;
                for (int i = 0; i < threadscount; i++)
                { 
                    Integral intg = new Integral(I.LowerLimit + i * h, I.LowerLimit + (i + 1) * h,I.F,I.Eps/threadscount,I.Method);
                    //Включаем интеграл в список
                    SubIntegrals.Add(intg);
                    //Создаём поток и добавляем в список
                    ThreadStart solver = new ThreadStart(SubIntegrals[i].Solve);
                    Thread thread = new Thread(solver);
                    Threads.Add(thread);
                }
            }
            //Неравномерная сетка
            else
            {
                //Инициализируем список потоков
                Threads = new List<Thread>();
                //Делим отрезок интегрирования сначала поровну между потоками
                double h = (I.UpperLimit - I.LowerLimit) / threadscount;
                for (int i = 0; i < threadscount; i++)
                {
                    Integral intg = new Integral(I.LowerLimit + i * h, I.LowerLimit + (i + 1) * h, I.F, I.Eps / threadscount, I.Method);
                    //Включаем интеграл в список
                    SubIntegrals.Add(intg);
                }

                //Корректируем разбиение
                if (threadscount > 1)
                {
                    I.CorrectGrid(ref SubIntegrals, K);
                }
                //Создаём потоки
                foreach(Integral sub in SubIntegrals)
                {
                    ThreadStart solver = new ThreadStart(sub.Solve);
                    Thread thread = new Thread(solver);
                    Threads.Add(thread);
                }
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
    }
   
}
