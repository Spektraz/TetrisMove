using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Core.LevelEntity.View
{
    public class ScoreUiView : MVC.View.View
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text bonusText;

        public void SetContext(int score, int bonus)
        {
            scoreText.text = score.ToString();
            bonusText.text = bonus.ToString();
        }
        protected override IController CreateController() => new ScoreUiController(this);
    }

    public class ScoreUiController  : Controller<ScoreUiView, ScoreServiceLayer>
    {
        private const int ScorePlus = 20;
        private int score;
        private int comboScore;
        private bool isPassed;
        public ScoreUiController(ScoreUiView view) : base(view)
        {
        }

        protected override void HandleServiceLayer()
        {
            var context = serviceLayer.GetContext();
            if (context == ScoreType.NotCombo)
            {
                comboScore = 0;
                return;
            }
            else if (context == ScoreType.Passed)
            {
                if (isPassed)
                {
                    ServiceFactory.GetService<ScoreServiceLayer>().UpdateDto(ScoreType.Combo);
                    return;
                }

                score += ScorePlus;
                ServiceFactory.GetService<ScoreInfoServiceLayer>().UpdateDto(score);
                View.SetContext(score, 0);
                isPassed = true;
                return;
            }

            if (context == ScoreType.Combo)
            {
                if(score <= 0)
                    return;
                comboScore++;
                score += ScorePlus * comboScore;
                ServiceFactory.GetService<ScoreInfoServiceLayer>().UpdateDto(score);
                View.SetContext(score, comboScore);
            }
        }
    }
}