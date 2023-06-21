namespace BursaDeValori;

public partial class MainPage : ContentPage
{
    List<Bursa> listaBursa = new List<Bursa>();

    public MainPage()
	{
		InitializeComponent();
		listaBursa = new BazaDateBursa().ObtineToateInreg();
        BackgroundImageSource = "fotobursa.png";
    }
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		BazaDateBursa bazaDateBursa = new BazaDateBursa();

        bazaDateBursa.StergeToateInregistrarile();

		listaBursa = bazaDateBursa.ObtineToateInreg();


        listaBursa = await ValoriBursa.PreiaBursa(Constants.symbols);
        bazaDateBursa.AdaugaListaBursa(listaBursa);

        listViewBursa.ItemsSource = listaBursa;

    }

    private void listViewBursa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        DisplayAlert("","Simbolul companiei, numele ei, pretul ei si volumul tranzactionat la bursa in timp real","Inchide");
    }
}

