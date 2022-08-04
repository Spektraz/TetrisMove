using System;
using Core.FinishGameEntity.ServiceLayer;
using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.FinishGameEntity.View
{
    public class FinishGameView : MVC.View.View
    {
        [SerializeField] private ParticleSystem saluteSystem;
        [SerializeField] private Canvas canvas;
        [SerializeField] private Button closeFinishUi;
        [SerializeField] private Text textScore;

        public void OnEnable()
        {
            saluteSystem.Pause();
        }

        public void AddListener(Action action)
        {
            closeFinishUi.onClick.AddListener(action.Invoke);
        }

        public void RemoveListener()
        {
            closeFinishUi.onClick.RemoveAllListeners();
        }
        public void SetCanvas(bool state, int score)
        {
            saluteSystem.Play();
            canvas.enabled = state;
            textScore.text = score.ToString();
        }
        protected override IController CreateController() => new FinishGameController(this);
    }

    public class FinishGameController : Controller<FinishGameView, FinishGameServiceLayer>
    {
        private ScoreInfoServiceLayer scoreInfoServiceLayer;
        public FinishGameController(FinishGameView view) : base(view)
        {
            scoreInfoServiceLayer = ServiceFactory.GetService<ScoreInfoServiceLayer>();
        }

        public override void AddListeners()
        {
            base.AddListeners();
            View.AddListener(SetButton);
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            View.RemoveListener();
        }

        protected override void HandleServiceLayer()
        {
            View.SetCanvas(serviceLayer.GetContext(),scoreInfoServiceLayer.GetContext());
        }

        private void SetButton()
        {
            ServiceFactory.GetService<GameUiServiceLayer>().UpdateDto(GameUiType.MainMenu);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}