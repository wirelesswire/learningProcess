using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace chlebogodziny
{
    public partial class MainPage : ContentPage
    {
        List<aktywnosc> x = new List<aktywnosc>();
        List<string> y = new List<string>();
        int id = 0;
        List<chleb> chleby = new List<chleb>() { new chleb("graham", 6), new chleb("ziarnisty", 10) };
        public MainPage()
        {
            InitializeComponent();
            typchleba.ItemsSource = chleby;
            typchleba.SelectedIndex = 0;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (aktstawka.Text == "" || aktnazwa.Text == "" || aktilosc.Text == "")
            {
                return;
            }
            x.Add(new aktywnosc(id++, aktnazwa.Text, int.Parse(aktilosc.Text), int.Parse(aktstawka.Text)));
            //y = aktywnosctostring(x);
            //lista.ItemsSource = y;
            refreshlista();
        }
        public List<string> aktywnosctostring(List<aktywnosc> x)
        {
            List<string> xb = new List<string>();
            foreach (var item in x)
            {
                xb.Add(item.ToString());
            }
            return xb;
        }
        public void refreshlista()
        {
            y = aktywnosctostring(x);
            lista.ItemsSource = y;
            sumuj();
            //liczchlebogodziny();
        }

        private void lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView tmp = (ListView)sender;
            x.RemoveAt(y.IndexOf(tmp.SelectedItem.ToString()));
            //y = aktywnosctostring(x);
            //lista.ItemsSource = y;
            refreshlista();
        }
        public void sumuj()
        {
            int sumag = 0;
            int sumap = 0;
            foreach (var item in x)
            {
                sumag += item.liczbagodzin;
                sumap += item.liczbagodzin * item.stawkaph;
            }
            sumagodzin.Text = "suma godzin: " + sumag;
            sumaplac.Text = "suma plac : " + sumap;
            chleb tmpchleb = chleby[typchleba.SelectedIndex];
            chlegbogodziny.Text = "chlebogodziny :" + sumap / tmpchleb.cena +"chlebów typu " + tmpchleb.nazwa+"("+tmpchleb.cena+"zł)"  ;


        }

        private void typchleba_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshlista();
        }
        //public void liczchlebogodziny()
        //{

        //}
    }


}
public class aktywnosc
{
    int id;
    string nazwa;
    public int liczbagodzin;
    public int stawkaph;

    public aktywnosc(int id, string nazwa, int liczbagodzin, int stawkaph)
    {
        this.id = id;
        this.nazwa = nazwa;
        this.liczbagodzin = liczbagodzin;
        this.stawkaph = stawkaph;
    }
    public override string ToString()
    {
        //return base.ToString();
        return id + " " + nazwa + " " + liczbagodzin + " " + stawkaph + "suma :" + " " + stawkaph * liczbagodzin;
    }
}
public class chleb
{
    public string nazwa;
    public int cena;
    public chleb(string nazwa, int cena)
    {
        this.nazwa = nazwa;
        this.cena = cena;
    }
    public override string ToString()
    {
        //return base.ToString();
        return nazwa;
    }
}