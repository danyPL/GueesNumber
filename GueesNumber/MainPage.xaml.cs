using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace GueesNumber
{
    public partial class MainPage : ContentPage
    {
        public int remainsTrials = 0;
        public int totalTrials = 5;
        public int uNumber;
        public int gNumber;
        public MainPage()
        {
            InitializeComponent();
            ResetTrails();
            Random random = new Random();
            gNumber = random.Next(1, 30);
        }
        public static bool IsAlphaNumeric(string strToCheck)
        {
            return strToCheck.All(char.IsLetterOrDigit);
        }

        public void ResetTrails()
        {
            remainsTrials = totalTrials;
        }
        public void ResetGame()
        {
            ResetTrails();
            remainsTrailsLabel.Text = $"Pozostała liczba prób: {remainsTrials}";
            Random random = new Random();
            gNumber = random.Next(1, 30);
            uNumber = 0;
            DisplayAlert("Zresetowano", "Gra została zresetowana", "OK");
            userNumber.Text = "";
        }
        public void Rgame(object sender, EventArgs e)
        {
            ResetGame();
        }
        public void UpdateTrails(int trails)
        {
            remainsTrailsLabel.Text = $"Pozostała liczba prób: {trails}";
        }
        public void CheckTrails()
        {
            if (remainsTrials <= 0)
            {
                DisplayAlert("Porażka", $"Niestety nie udało ci się zgadnąć liczby. Wylosowana to: {gNumber}", "OK");
                ResetGame();

            }
        }
        public void StartGame(object sender, EventArgs e)
        {


           
            if(string.IsNullOrEmpty(userNumber.Text)) { DisplayAlert("Błąd", "Podaj liczbę!", "OK"); return; }
            if (!int.TryParse(userNumber.Text, out int uNumber)) { DisplayAlert("Błąd", "Podaj prawidłową liczbę!", "OK"); return; }
            else
            {
                if (uNumber > 30 || uNumber < 0)
                {
                    DisplayAlert("Liczba z poza zakresu", $"Zakres to od 0 do 30", "Zamknij");

                }
                else
                {


                    uNumber = Convert.ToInt32(userNumber.Text);

                    if (uNumber > gNumber)
                    {
                        DisplayAlert("Za wysoko", $"Wylosowana liczba jest mnijesza od liczby {uNumber}", "Zamknij");
                        remainsTrials--;
                        UpdateTrails(remainsTrials);
                        CheckTrails();
                    }
                    else if (uNumber < gNumber)
                    {
                        DisplayAlert("Za nisko", $"Wylosowana liczba jest większa od liczby {uNumber}", "Zamknij");
                        remainsTrials--;
                        UpdateTrails(remainsTrials);
                        CheckTrails();

                    }
                    else if (uNumber == gNumber)
                    {
                        DisplayAlert("Udało się!", $"Gratulacje odgadłeś liczbe! Wylosowana liczba to {gNumber}", "OK");
                        ResetTrails();
                        ResetGame();
                    }
                }
            }
           


        }
    }

}
