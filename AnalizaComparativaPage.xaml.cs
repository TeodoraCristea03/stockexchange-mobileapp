

namespace BursaDeValori;

public partial class AnalizaComparativaPage : ContentPage
{

    List<Bursa> ListaBursa = new List<Bursa>();
    public AnalizaComparativaPage()
	{
		InitializeComponent();

        BackgroundImageSource = "fotobursa.png";

        ListaBursa = new BazaDateBursa().ObtineToateInreg();

        pickerComp1.ItemsSource = ListaBursa;
        pickerComp2.ItemsSource = ListaBursa;

        pickerComp1.SelectedIndex = 0;
        pickerComp2.SelectedIndex = 1;

    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        Bursa comp1 = pickerComp1.SelectedItem as Bursa;
        Bursa comp2 = pickerComp2.SelectedItem as Bursa;

        if (comp1 == comp2)
        {
            DisplayAlert("", "Alege doua companii diferite!", "Inchide");
        }
        else
        {
            Compara(comp1, comp2);
        }

    }

    void Compara(Bursa Companie1, Bursa Companie2)
    {

        SymbolLabel1.Text = Companie1.Symbol;
        NameLabel1.Text = Companie1.ShortName;
        RMVLabel1.Text = Companie1.RegularMarketVolume.ToString();
        RMPLabel1.Text = Companie1.RegularMarketPrice.ToString();
        RMPLowLabel1.Text = Companie1.RegularMarketDayLow.ToString();
        RMPHighLabel1.Text = Companie1.RegularMarketDayHigh.ToString();
        ADV10DLabel1.Text = Companie1.AverageDailyVolume10Day.ToString();
        ADV3MLabel1.Text = Companie1.AverageDailyVolume3Month.ToString();

        SymbolLabel2.Text = Companie2.Symbol;
        NameLabel2.Text = Companie2.ShortName;
        RMVLabel2.Text = Companie2.RegularMarketVolume.ToString();
        RMPLabel2.Text = Companie2.RegularMarketPrice.ToString();
        RMPLowLabel2.Text = Companie2.RegularMarketDayLow.ToString();
        RMPHighLabel2.Text = Companie2.RegularMarketDayHigh.ToString();
        ADV10DLabel2.Text = Companie2.AverageDailyVolume10Day.ToString();
        ADV3MLabel2.Text = Companie2.AverageDailyVolume3Month.ToString();

        CompVol.Text = (Companie1.RegularMarketVolume > Companie2.RegularMarketVolume) ? ">" : "<";
        CompPret.Text = (Companie1.RegularMarketPrice > Companie2.RegularMarketPrice) ? ">" : "<";
        CompPretMin.Text = (Companie1.RegularMarketDayLow > Companie2.RegularMarketDayLow) ? ">" : "<";
        CompPretMax.Text = (Companie1.RegularMarketDayHigh > Companie2.RegularMarketDayHigh) ? ">" : "<";
        CompVol10Z.Text = (Companie1.AverageDailyVolume10Day > Companie2.AverageDailyVolume10Day) ? ">" : "<";
        CompVol3L.Text = (Companie1.AverageDailyVolume3Month > Companie2.AverageDailyVolume3Month) ? ">" : "<";

    }
}