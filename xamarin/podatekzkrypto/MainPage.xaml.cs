using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace podatekzkrypto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        public List<operacja> x = new List<operacja>();
        public List<string> y = new List<string>();
        public List<string> z= new List<string>() {"asd","asd","gdasd" };
        public int index = 0;
        private void Switch_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Switch s = (Switch)sender;
            corobi.Text = s.IsToggled ? "wpłata " : "wypłata";
        }
        public void sumuj()
        {
            List<string> abc = new List<string>();
            float sumain = 0;
            float sumaout = 0;
            foreach (var item in x)
            {
                if(item.rodzaj == "wpłata") {
                    sumain += item.kwota * item.kurs;
                }
                else
                {
                    sumaout += item.kwota * item.kurs;
                }
            }
            abc = new List<string>(){"wpłaty: "+sumain,"wypłaty " + sumaout };
            podsumowanie.ItemsSource = abc;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if(kwotaentry.Text.Length == 0 || kursentry.Text.Length == 0)
            {
                return;
            }
            x.Add(new operacja(index , int.Parse(kwotaentry.Text), float.Parse(kursentry.Text), wplataSwitch.IsToggled ? "wpłata" : "wypłata"));
            index++;
            y = tostring(x);
            lista.ItemsSource = y;
            sumuj();
        }
        public List<string> tostring(List<operacja> op)
        {
            List<string> a = new List<string>();
            foreach (var item in op)
            {
                a.Add(item.makestring());
            }
            return a;
        }

        //private  async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    ListView lista = (ListView)sender;
        //    bool answer = await DisplayAlert("Question?", "Would you like to delete this entry ", "Yes", "No");
        //    if (answer)
        //    {
        //        x.RemoveAt(y.IndexOf(lista.SelectedItem.ToString()));
        //        y = tostring(x);
        //        lista.ItemsSource = y;
        //    }
        //    //Debug.WriteLine("Answer: " + answer);
        //}
        private async void lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lista = (ListView)sender;
            bool answer = await DisplayAlert("Question?", "Would you like to delete this entry ", "Yes", "No");
            if (answer)
            {
                x.RemoveAt(y.IndexOf(lista.SelectedItem.ToString()));
                y = tostring(x);
                lista.ItemsSource = y;
            }
            sumuj();
        }
    }
}
public class operacja
{
    int id;
    public int kwota;
    public float  kurs;
    public string rodzaj;
    public operacja(int id,int kwota, float  kurs, string rodzaj)
    {
        this.id = id;
        this.kwota = kwota;
        this.kurs = kurs;
        this.rodzaj = rodzaj;
    }
    public string  makestring()
    {
        return "#"+id + " " + kwota + "  " + kurs + " " + rodzaj;
    }

}