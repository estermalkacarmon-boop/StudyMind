
namespace StudyMind
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartClicked(object sender, EventArgs e)
        {
            await DisplayAlert("StudyMind", "בואו נתחיל ללמוד!", "יאללה");
        }
    }
}
