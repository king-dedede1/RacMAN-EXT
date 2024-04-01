namespace RacMAN;

internal static class Program
{
    public static Racman state;
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        state = new Racman();
        state.ShowConnectDialog();
        Application.Run(state.MainForm);
    }
}