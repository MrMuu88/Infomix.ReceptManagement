namespace Frontend
{
    // TODO: K�zel �ll (funkcionalit�sban) a k�szhez,
    // Ami hi�nyzik az a Recepthez tartozo bool adatok
    // Tov�bbi tesztel�s �s try catch-ek hiba�zenetekkel

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Receptek());
        }
    }
}