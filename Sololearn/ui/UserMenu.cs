using Sololearn.utils;

internal static class UserMenu
{
    internal static void Menu()
    {

        Console.WriteLine("******** User Menu ******** ");
        Console.WriteLine(" ***** " + ContextHolder.CurrentUser?.Name + " ***** ");
        Console.WriteLine("***** "+ContextHolder.CurrentUser?.Email+" ***** ");

        Console.WriteLine();

    }
}