using MVC.Service;

namespace Core.LevelEntity.ServiceLayer
{
    public class GameUiServiceLayer  : ServiceLayer<GameUiType,GameUiType>
    {
        public override GameUiType GetContext()
        {
            return dto;
        }
    }

    public enum GameUiType
    {
        MainMenu = 0,
        FinishMenu = 1,
        GameMenu = 2,
        SwitchOff = 3,
    }
}
