using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.View;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.UiEntity
{
    public class MainMenuScoreView : View
    {
        [SerializeField] private Text scoreText;

        public void SetContext(int score)
        {
            scoreText.text = score.ToString();
        }
        protected override IController CreateController() => new MainMenuScoreController(this);
    }
    public class MainMenuScoreController : Controller<MainMenuScoreView,ScoreInfoServiceLayer>
    {
        public MainMenuScoreController(MainMenuScoreView view) : base(view)
        {
        }

        protected override void HandleServiceLayer()
        {
            View.SetContext(serviceLayer.GetContext());
        }
    }
}