using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace integrate_multithread
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //Параметры по умолчанию
            cbFunction.SelectedIndex = 2;

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void btnClearResults_Click(object sender, EventArgs e)
        {
            //Очищаем таблицу результатов и строку состояния
            dgResults.Rows.Clear();
            StatusBar.Items[0].Text = "";
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            //Проверяем корректность параметров
            try
            {
                Verify();
            }
            catch(FormatException ex0)
            {
                MessageBox.Show("Вводимые параметры должны быть числами");
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //Если параметры заданы корректно, запускаем решение
            int method = -1;
            if (rbRectangle.Checked)
            {
                method = 0;
            }
            else if (rbTrapezoidal.Checked)
            {
                method = 1;
            }
            else if (rbSimpson.Checked)
            {
                method = 2;
            }
            if(method<0)
            {
                return;
            }
            Integral I = new Integral(
                Convert.ToDouble(tbLowerLimit.Text), 
                Convert.ToDouble(tbUpperLimit.Text), 
                cbFunction.SelectedIndex, 
                Convert.ToDouble(tbAccuracy.Text), method);
               
            //Распределяем по потокам
            Threader threader = new Threader();
            int thrcount = Convert.ToInt32(/*i*/tbThreadsNum.Text);

            List<Integral> SubIntegrals = new List<Integral>(threader.Threads.Count); //Список подынтегралов
            try
            {
                double K = Convert.ToDouble(tbCorrection.Text);
                threader.K = K;
                threader.Distribute(I,ref SubIntegrals, thrcount, rbRegular.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Запускаем выполнение
            threader.StartAll();
            StatusBar.Items[0].Text = "Все потоки запущены";

            //Завершаем потоки
            threader.JoinAll();
            StatusBar.Items[0].Text = "Все потоки завершены";
            // сбор общего результата
            I.TotalValue(SubIntegrals);
            //вывод результатов в таблицу
            dgResults.Rows.Add();
            dgResults.Rows[dgResults.RowCount - 1].Cells[2].Value = I.Value;
            dgResults.Rows[dgResults.RowCount - 1].Cells[0].Value = threader.Threads.Count;
            dgResults.Rows[dgResults.RowCount - 1].Cells[1].Value = threader.TotalTime.TotalMilliseconds;
        }

        public int Verify()
        {
            double a, b, eps;
            int k;           

            //проверяем, выбрана ли подынтегральная функция
            if (cbFunction.SelectedIndex < 0)
            {
                throw new Exception("Не выбрана подынтегральная функция");
            }

            a = Convert.ToDouble(tbLowerLimit.Text);
            b = Convert.ToDouble(tbUpperLimit.Text);
           
            //проверяем отрезок интегрирования
            if (a>b)
            {
                throw new Exception("Отрезок интегрирования должен быть не вырожденным");
            }

            eps = Convert.ToDouble(tbAccuracy.Text);
            
            //проверяем число разбиений
            if (eps<=0)
            {
                throw new Exception("Точность должна быть положительным числом");
            }

            k = Convert.ToInt32(tbThreadsNum.Text);
            //проверяем число потоков
            if (k <= 0)
            {
                throw new Exception("Количество потоков должно быть положительным числом");
            }   
            
            //Если всё заданно корректно
            return 0;
        }

    }
}
