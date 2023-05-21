namespace Frontend
{
    // TODO: Közel áll (funkcionalitásban) a készhez,
    // Ami hiányzik az a Recepthez tartozo bool adatok
    // További tesztelés és try catch-ek hibaüzenetekkel

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