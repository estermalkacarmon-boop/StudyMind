
using Microsoft.Maui.Storage;

namespace StudyMind;

public partial class PreferencesPage : ContentPage
{
    public PreferencesPage()
    {
        InitializeComponent();
    }

    // עדכון מספר שעות הלמידה בזמן הזזת המחוון
    private void OnHoursChanged(object sender, ValueChangedEventArgs e)
    {
        int hours = (int)Math.Round(e.NewValue);
        HoursValueLabel.Text = $"{hours} שעות ביום";
    }

    // שמירת כל העדפות הלמידה
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // 1. זמן לימוד יומי
        int hours = (int)Math.Round(HoursSlider.Value);

        // 2. זמן מועדף ללמידה
        string preferredTime = "בצהריים";

        if (MorningRadio.IsChecked)
            preferredTime = "בבוקר";
        else if (EveningRadio.IsChecked)
            preferredTime = "בערב";

        // 3. סגנון למידה
        string learningStyle = "שילוב של כמה שיטות";

        if (ReadingRadio.IsChecked)
            learningStyle = "סיכומים וקריאה";
        else if (VideosRadio.IsChecked)
            learningStyle = "סרטונים והסברים";
        else if (PracticeRadio.IsChecked)
            learningStyle = "תרגול שאלות";

        // 4. יכולת ריכוז
        string focusDuration = "30–45 דקות";

        if (Focus15Radio.IsChecked)
            focusDuration = "15–25 דקות";
        else if (Focus45Radio.IsChecked)
            focusDuration = "45–60 דקות";
        else if (Focus60Radio.IsChecked)
            focusDuration = "יותר משעה";

        // 5. האתגר בלמידה
        string mainChallenge = "להבין את החומר";

        if (StartingRadio.IsChecked)
            mainChallenge = "להתחיל ללמוד";
        else if (ConcentrationRadio.IsChecked)
            mainChallenge = "לשמור על ריכוז";
        else if (MemoryRadio.IsChecked)
            mainChallenge = "לזכור את החומר";
        else if (TimeRadio.IsChecked)
            mainChallenge = "לנהל את הזמן";

        // 6. משך מקטע הלמידה
        string sessionLength = "45 דקות";

        if (Session25Radio.IsChecked)
            sessionLength = "25 דקות";
        else if (Session60Radio.IsChecked)
            sessionLength = "60 דקות";
        else if (Session90Radio.IsChecked)
            sessionLength = "90 דקות";

        // 7. זמן הפסקה
        string breakLength = "10 דקות";

        if (Break5Radio.IsChecked)
            breakLength = "5 דקות";
        else if (Break15Radio.IsChecked)
            breakLength = "15 דקות";
        else if (Break20Radio.IsChecked)
            breakLength = "20 דקות";

        // שמירת ההעדפות במכשיר
        Preferences.Default.Set("DailyHours", hours);
        Preferences.Default.Set("PreferredTime", preferredTime);
        Preferences.Default.Set("LearningStyle", learningStyle);
        Preferences.Default.Set("FocusDuration", focusDuration);
        Preferences.Default.Set("MainChallenge", mainChallenge);
        Preferences.Default.Set("SessionLength", sessionLength);
        Preferences.Default.Set("BreakLength", breakLength);
        await DisplayAlert(
            "ההעדפות נשמרו!",
            "ההעדפות שלך נשמרו בהצלחה.",
            "מעולה");

        await Shell.Current.GoToAsync(nameof(DashboardPage));

    }
}
