using System;
using Core.GameStart.ServiceLayer;
using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using MVC.View;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.UiEntity
{
    public class MainMenuView : View
    {
        [SerializeField] private Button exitButton;
        [SerializeField] private Button startButton;

        public void AddListenerStart(Action action)
        {
            startButton.onClick.AddListener(action.Invoke);
        }
        public void AddListenerExit(Action action)
        {
            exitButton.onClick.AddListener(action.Invoke);
        }
        public void RemoveListener()
        {
            startButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
        }
        protected override IController CreateController() => new MainMenuController(this);
    }
    public class MainMenuController : Controller<MainMenuView>
    {
        public MainMenuController(MainMenuView view) : base(view)
        {
        }

        public override void AddListeners()
        {
           View.AddListenerStart(StartGame);
           View.AddListenerExit(ExitGame);
        }

        public override void RemoveListeners()
        {
           View.RemoveListener();
        }

        private void StartGame()
        {
            ServiceFactory.GetService<StartGameServiceLayer>().UpdateDto(true);
            ServiceFactory.GetService<GameUiServiceLayer>().UpdateDto(GameUiType.GameMenu);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}