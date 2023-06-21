namespace BursaDeValori;

public partial class DespreAplicatiePage : ContentPage
{
	public DespreAplicatiePage()
	{
		InitializeComponent();

        

    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        

        string nume = EntryNume.Text;
        string prenume = EntryPrenume.Text;
        string datanastere = (DataNastere.Date).ToString();
        string extracomp = EntryExtraComp.Text;
        double notaapp = NotaApp.Value;
        
        if(nume.Length < 3)
        {
            DisplayAlert("", "Numele si prenumele trebuie sa fie mai lungi!", "Inchide");
        }
        else
        {
            DisplayAlert("", "Multumim pentru raspuns!", "Inchide");
            Submit(nume, prenume, datanastere, extracomp, notaapp);
            EntryNume.Text = "";
            EntryPrenume.Text = "";
            EntryExtraComp.Text = "";
            NotaApp.Value = 0;
        }

    }
    void Submit(string nume, string prenume, string datan, string extracomp, double nota)
    {
        Formular raspuns = new Formular(nume, prenume, datan, extracomp, nota);

        BazaDateFormular BDForm = new BazaDateFormular();

        BDForm.AdaugaRaspuns(raspuns);
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        double value = args.NewValue;
        LabelNota.Text = "Oferă o nota paginii (" + Convert.ToInt32(value).ToString() + ")";
    }

}