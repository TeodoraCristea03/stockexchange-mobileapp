
using Microcharts;
using SkiaSharp;

namespace BursaDeValori;

public partial class AnalizaStatisticaPage : ContentPage
{
    List<Bursa> listaBursa;
    public AnalizaStatisticaPage()
	{
		InitializeComponent();
        BackgroundImageSource = "fotobursa.png";
    }

    protected override async void OnAppearing()
    {
        listaBursa = await ValoriBursa.PreiaBursa(Constants.symbols);
        List<ChartEntry> chartEntriesMP = new List<ChartEntry>();
        List<ChartEntry> chartEntriesMV = new List<ChartEntry>();

        Random rnd = new Random();

        string[] categoriiRMP = new string[] { "Sub 5$", "5$-25$", "25$-50$", "50$-100$", "100$-150$", "Peste 150$" };
        int[] frecvCategRMP = new int[6];

        string[] categoriiRMV = new string[] { "Sub 10.000", "10.000-100.000", "Peste 100.000" };
        int[] frecvCategRMV = new int[3];

        foreach (Bursa bursa in listaBursa)
        {
            if (bursa.RegularMarketPrice<=5)
                frecvCategRMP[0]++;
            else if (bursa.RegularMarketPrice > 5 && bursa.RegularMarketPrice < 25)
                frecvCategRMP[1]++;
            else if (bursa.RegularMarketPrice > 25 && bursa.RegularMarketPrice < 50)
                frecvCategRMP[2]++;
            else if (bursa.RegularMarketPrice > 50 && bursa.RegularMarketPrice < 100)
                frecvCategRMP[3]++;
            else if (bursa.RegularMarketPrice > 100 && bursa.RegularMarketPrice < 150)
                frecvCategRMP[4]++;
            else frecvCategRMP[5]++;

            if (bursa.RegularMarketVolume <= 10000)
                frecvCategRMV[0]++;
            else if (bursa.RegularMarketVolume > 10000 && bursa.RegularMarketVolume < 100000)
                frecvCategRMV[1]++;
            else frecvCategRMV[2]++;
        }

        string[] chartColors = { "#3ca381", "#693ca3", "#a33c88", "#de9c40", "#becf27", "#cf4327" };

        for (int i=0;i<=5;i++)
        {
            chartEntriesMP.Add(new ChartEntry((float)frecvCategRMP[i])
            {
                Label = categoriiRMP[i],
                ValueLabel = frecvCategRMP[i].ToString(),
                Color = SKColor.Parse(chartColors[i]),
                ValueLabelColor = SKColor.Parse(chartColors[i])
            });
        }

        chartView.Chart = new DonutChart()
        {
            Entries = chartEntriesMP
        };

        for (int i = 0; i <= 2; i++)
        {
            chartEntriesMV.Add(new ChartEntry((float)frecvCategRMV[i])
            {
                Label = categoriiRMV[i],
                ValueLabel = frecvCategRMV[i].ToString(),
                Color = new SkiaSharp.SKColor((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256))
            });
        }

        chartView1.Chart = new RadarChart()
        {
            Entries = chartEntriesMV
        };
    }
}