using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using UnityEngine;

namespace Core.LevelEntity.View
{
    public class ComboAnimatorView : MVC.View.View
    {
        [SerializeField] private Animator animatorUi;
        public void SetAnimator(int trigger)
        {
            animatorUi.SetTrigger(trigger);
        }
        protected override IController CreateController() => new ComboAnimatorController(this);
    }

    public class ComboAnimatorController : Controller<ComboAnimatorView, ScoreServiceLayer>
    {
        private static readonly int AnimatorComboParameter = Animator.StringToHash("Bonus");
        public ComboAnimatorController(ComboAnimatorView view) : base(view)
        {
        }

        protected override void HandleServiceLayer()
        {
            View.SetAnimator(AnimatorComboParameter);
        }
    }
}