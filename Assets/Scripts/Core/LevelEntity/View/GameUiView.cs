using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using UnityEngine;

namespace Core.LevelEntity.View
{
    public class GameUiView  : MVC.View.View
    {
        [SerializeField] private Canvas gameCanvas;
        [SerializeField] private Canvas mainMenu;
        [SerializeField] private Canvas finishMenu;
        public void SetMainMenu(bool state)
        {
            gameCanvas.enabled = !state;
            mainMenu.enabled = state;
            finishMenu.enabled = !state;
        }
        public void SetMainFinish(bool state)
        {
            gameCanvas.enabled = !state;
            mainMenu.enabled = !state;
            finishMenu.enabled = state;
        }
        public void SetMainGame(bool state)
        {
            gameCanvas.enabled = state;
            mainMenu.enabled = !state;
            finishMenu.enabled = !state;
        }

        public void SwitchOff(bool state)
        {
            gameCanvas.enabled = !state;
            mainMenu.enabled = !state;
            finishMenu.enabled = !state;
        }
        protected override IController CreateController() => new GameUiController(this);
    }

    public class GameUiController  : Controller<GameUiView, GameUiServiceLayer>
    {
      
        public GameUiController(GameUiView view) : base(view)
        {
        }

        protected override void HandleServiceLayer()
        {
            var context = serviceLayer.GetContext();
            switch (context)
            {
                case GameUiType.MainMenu:
                    View.SetMainMenu(true);
                    break;
                case GameUiType.FinishMenu:
                    View.SetMainFinish(true);
                    break;
                case GameUiType.GameMenu:
                    View.SetMainGame(true);
                    break;
                case GameUiType.SwitchOff:
                    View.SwitchOff(true);
                    break;
            }
        }
    }
}