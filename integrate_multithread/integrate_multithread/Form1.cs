using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace integrate_multithread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void btnClearResults_Click(object sender, EventArgs e)
        {
            //Очищаем таблицу результатов
            dgResults.Rows.Clear();
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
