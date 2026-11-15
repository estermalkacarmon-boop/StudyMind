
namespace StudyMind;

public partial class SubjectsPage : ContentPage
{
    public SubjectsPage()
    {
        InitializeComponent();
    }

    private async void OnContinueClicked(object sender, EventArgs e)
    {
        string selectedSubjects = "";

        if (MathCheckBox.IsChecked)
            selectedSubjects += "מתמטיקה\n";

        if (EnglishCheckBox.IsChecked)
            selectedSubjects += "אנגלית\n";

        if (HistoryCheckBox.IsChecked)
            selectedSubjects += "היסטוריה\n";

        if (BibleCheckBox.IsChecked)
            selectedSubjects += "תנ״ך\n";

        if (CivicsCheckBox.IsChecked)
            selectedSubjects += "אזרחות\n";

        if (selectedSubjects == "")
        {
            await DisplayAlert(
                "שימו לב",
                "צריך לבחור לפחות מקצוע אחד",
                "אישור");

            return;
        }

        Preferences.Default.Set("SelectedSubjects", selectedSubjects);

        await Shell.Current.GoToAsync(nameof(PreferencesPage));
    }
}
