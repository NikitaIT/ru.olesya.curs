using ru.olesya.curs.ConsoleControllers;

namespace ru.olesya.curs.Models
{
    /**
     * КЛАСС ПОЛЬЗОВАТЕЛЯ
     */
    public class Client
    {
        public void CreateApplication(CommandManagerFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}