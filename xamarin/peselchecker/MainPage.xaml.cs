using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            isok(input.Text);
        }
        public void isok(string text)
        {
            if (text.Length != 11) {
                return;
            }
            int cyfrakontrolna =-1;
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int suma = 0;
            for (int i = 0; i < wagi.Length; i++)
            {
                suma += int.Parse( text[i].ToString()) * wagi[i];
            }
            Console.WriteLine("suma"+suma);
            int reszta = 10 - suma % 10;
            Console.WriteLine("reszta"+reszta);
            cyfrakontrolna = reszta == 10 ? 0 : reszta;
            Console.WriteLine("kontrolna " + cyfrakontrolna);

            if ( cyfrakontrolna == int.Parse( text[10].ToString())) {
                wynik.Text = "jest ok ";
                wynik.TextColor = Color.Green;
            }
            else
            {
                wynik.Text = "nie jest ok ";
                wynik.TextColor = Color.Red;
            }
        }
    }
}
