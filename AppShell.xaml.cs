namespace StudyMind
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SubjectsPage), typeof(SubjectsPage));
            Routing.RegisterRoute(nameof(PreferencesPage), typeof(PreferencesPage));
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
        }
    }
}