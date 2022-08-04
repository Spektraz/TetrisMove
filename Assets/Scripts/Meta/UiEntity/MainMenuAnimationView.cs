using Core.FinishGameEntity.ServiceLayer;
using Core.GameStart.ServiceLayer;
using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using MVC.View;
using UnityEngine;

namespace Meta.UiEntity
{
    public class MainMenuAnimationView : View
    {
        [SerializeField] private Animator animatorHero;
        public void SetAnimator(int trigger)
        {
            animatorHero.SetTrigger(trigger);
        }
        protected override IController CreateController() => new MainMenuAnimationController(this);
    }

    public class MainMenuAnimationController : Controller<MainMenuAnimationView, StartGameServiceLayer>
    {
        private static readonly int AnimatorStartParameter = Animator.StringToHash("Start");
        private static readonly int AnimatorRestartParameter = Animator.StringToHash("Restart");
        private static readonly int AnimatorFinishParameter = Animator.StringToHash("Finish");
        private FinishGameServiceLayer finishGameServiceLayer;
        private GameUiServiceLayer gameUiServiceLayer;
        public MainMenuAnimationController(MainMenuAnimationView view) : base(view)
        {
            finishGameServiceLayer = ServiceFactory.GetService<FinishGameServiceLayer>();
            gameUiServiceLayer = ServiceFactory.GetService<GameUiServiceLayer>();
        }
        public override void AddListeners()
        {
            base.AddListeners();
            finishGameServiceLayer.DtoHandler.AddListener(SetEnd);
            gameUiServiceLayer.DtoHandler.AddListener(Restart);
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            finishGameServiceLayer.DtoHandler.RemoveListener(SetEnd);
            gameUiServiceLayer.DtoHandler.RemoveListener(Restart);
        }
        protected override void HandleServiceLayer()
        {
            View.SetAnimator(AnimatorStartParameter);
        }

        private void SetEnd()
        {
            View.SetAnimator(AnimatorFinishParameter);
        }

        private void Restart()
        {
            if(gameUiServiceLayer.GetContext() == GameUiType.MainMenu)
             View.SetAnimator(AnimatorRestartParameter);
        }
    }
}