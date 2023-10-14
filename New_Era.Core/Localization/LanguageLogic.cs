namespace New_Era.Core.Localization
{
    public static class LanguageLogic
    {
        public static bool IsArbic()
        {
            if (Thread.CurrentThread.CurrentCulture.Name.Split("-").First() == "ar")
                return true;

            return false;
        }
    }
}
