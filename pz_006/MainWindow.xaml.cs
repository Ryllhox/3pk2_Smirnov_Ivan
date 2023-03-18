using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pz_006
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        //  тут паралельно асинхроный
        async Task Work(decimal a, int i)
        {
            for (int n = 0; n < i; n++)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5f));

                a += (decimal)Math.Sqrt((double)a);
                a = (decimal)Math.Pow((double)a, -1);
                a = (decimal)Math.Sqrt((double)a);
                a /= (decimal)((double)a * Math.Sqrt((double)a));

                //ReloadProgress(99 / n);
                pb1.Value = 100 - 101 / (n + 1);

                Trace.WriteLine(n);

                tb1.Text = $"{a:f25}";
            }

            MessageBox.Show("work end the", "work.");
        }

        //  здесь не асинхронный
        void Work2(decimal a, int i)
        {
            for (int n = 0; n < i; n++)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.5f));

                a += (decimal)Math.Sqrt((double)a);
                a = (decimal)Math.Pow((double)a, -1);
                a = (decimal)Math.Sqrt((double)a);
                a /= (decimal)((double)a * Math.Sqrt((double)a));

                //ReloadProgress(99 / n);
                pb1.Value = 100 - 101 / (n + 1);

                Trace.WriteLine(n);

                tb1.Text = $"{a:f25}";
            }

            MessageBox.Show("work end the", "work.");
        }

        //  происходит на форме установка или не утсановка голочки какой метод запустить и происходит действие работы
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cb1.IsChecked) Work(3, int.MaxValue / int.Parse(tb3.Text));
            else Work2(3, int.MaxValue / int.Parse(tb3.Text));
        }
    }
}