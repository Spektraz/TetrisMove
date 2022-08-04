using Meta.UiEntity.Model;
using Meta.UiEntity.ServiceLayer;
using MVC.Controller;
using MVC.View;
using UnityEngine;

namespace Meta.UiEntity
{
    public class BuySkyAnimationLockView:View
    {
        [SerializeField] private Animator animatorUi;
        [SerializeField] private Material skyBox;
        [SerializeField] private SkyboxName skyboxName;
        public void SetAnimator(int trigger, SkyboxName skyboxname)
        {
            if (skyboxname != skyboxName) return;
            animatorUi.SetTrigger(trigger);
            RenderSettings.skybox = skyBox;
        }
        protected override IController CreateController() => new BuySkyAnimationLockController(this);
    }


    public class BuySkyAnimationLockController : Controller<BuySkyAnimationLockView, OpenLockServiceLayer>
    {
        private static readonly int AnimatorLockParameter = Animator.StringToHash("Open");

        public BuySkyAnimationLockController(BuySkyAnimationLockView view) : base(view)
        {
        }

        protected override void HandleServiceLayer()
        {
            View.SetAnimator(AnimatorLockParameter, serviceLayer.GetContext());
        }
    }
}