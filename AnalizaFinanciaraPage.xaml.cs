using Microcharts;
namespace BursaDeValori;

public partial class AnalizaFinanciaraPage : ContentPage
{

    List<Bursa> listaBursa;

    public AnalizaFinanciaraPage()
	{
		InitializeComponent();
        BackgroundImageSource = "fotobursa.png";
        
        listaBursa = new BazaDateBursa().ObtineToateInreg();
        List<ChartEntry> chartEntries = new List<ChartEntry>();
        List<ChartEntry> chartEntries1 = new List<ChartEntry>();

        Random rnd = new Random();

        List<Bursa> BursaSortataPret = listaBursa.OrderByDescending(o => o.RegularMarketPrice).ToList();
        List<Bursa> BursaSortataVolum = listaBursa.OrderByDescending(o => o.RegularMarketVolume).ToList();

        Border1.IsVisible = Border2.IsVisible = TextChart1.IsVisible = TextChart2.IsVisible = true;

        TextChart1.Text = "Top 15 companii dupa pretul actiunilor";
        TextChart2.Text = "Top 15 companii dupa volumul tranzactionat";

        for (int i = 0; i < 15; i++)
        {
            chartEntries.Add(new ChartEntry((float)BursaSortataPret[i].RegularMarketPrice)
            {
                Label = BursaSortataPret[i].Symbol,
                ValueLabel = BursaSortataPret[i].RegularMarketPrice.ToString(),
                Color = new SkiaSharp.SKColor((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256))
            });

            chartEntries1.Add(new ChartEntry((float)BursaSortataVolum[i].RegularMarketVolume)
            {
                Label = BursaSortataVolum[i].Symbol,
                ValueLabel = BursaSortataVolum[i].RegularMarketVolume.ToString(),
                Color = new SkiaSharp.SKColor((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256))
            });

        }

        chartView.Chart = new BarChart()
        {
            Entries = chartEntries
        };

        chartView1.Chart = new BarChart()
        {
            Entries = chartEntries1
        };
    }
    
    async void OnToggled(object sender, ToggledEventArgs e)
    {

        bool isToggled = e.Value;

        listaBursa = await ValoriBursa.PreiaBursa(Constants.symbols);
        List<ChartEntry> chartEntries = new List<ChartEntry>();
        List<ChartEntry> chartEntries1 = new List<ChartEntry>();

        List<Bursa> BursaSortataPret = listaBursa.OrderByDescending(o => o.RegularMarketPrice).ToList();
        List<Bursa> BursaSortataVolum = listaBursa.OrderByDescending(o => o.RegularMarketVolume).ToList();

        Random rnd = new Random();

        Border1.IsVisible = Border2.IsVisible = TextChart1.IsVisible = TextChart2.IsVisible = true;

        TextChart1.Text = "Top 15 companii dupa pretul actiunilor";
        TextChart2.Text = "Top 15 companii dupa volumul tranzactionat";

        if (isToggled)
        {
            BursaSortataPret = listaBursa.OrderBy(o => o.RegularMarketPrice).ToList();
            BursaSortataVolum = listaBursa.OrderBy(o => o.RegularMarketVolume).ToList();

            TextChart1.Text = "Ultimele 15 companii dupa pretul actiunilor";
            TextChart2.Text = "Ultimele 15 companii dupa volumul tranzactionat";
        }

        for (int i = 0; i < 15; i++)
        {
            chartEntries.Add(new ChartEntry((float)BursaSortataPret[i].RegularMarketPrice)
            {
                Label = BursaSortataPret[i].Symbol,
                ValueLabel = BursaSortataPret[i].RegularMarketPrice.ToString(),
                Color = new SkiaSharp.SKColor((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256))
            });

            chartEntries1.Add(new ChartEntry((float)BursaSortataVolum[i].RegularMarketVolume)
            {
                Label = BursaSortataVolum[i].Symbol,
                ValueLabel = BursaSortataVolum[i].RegularMarketVolume.ToString(),
                Color = new SkiaSharp.SKColor((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256))
            });

        }

        chartView.Chart = new BarChart()
        {
            Entries = chartEntries
        };

        chartView1.Chart = new BarChart()
        {
            Entries = chartEntries1
        };
    }
}