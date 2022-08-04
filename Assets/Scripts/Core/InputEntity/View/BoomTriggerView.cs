using Core.InputEntity.ServiceLayer;
using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.InputEntity.View
{
    public class BoomTriggerView : MVC.View.View, IPointerClickHandler
    {
        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private GameObject boomRunner;
        public void OnEnable()
        {
            particleSystem.Pause();
        }

        public void BoomParticle()
        {
            boomRunner.SetActive(true);
            particleSystem.Play();
        }
        protected override IController CreateController() => new BoomTriggerController(this);

        public void OnPointerClick(PointerEventData eventData)
        {
            Controller.Execute();
        }
        
    }
    public class BoomTriggerController : Controller<BoomTriggerView>
    {
        public BoomTriggerController(BoomTriggerView view) : base(view)
        {
        }

        public override void AddListeners()
        {
            
        }

        public override void RemoveListeners()
        {

        }

        public override void Execute()
        {
            base.Execute();
            View.BoomParticle();
            ServiceFactory.GetService<BoomTriggerServiceLayer>().UpdateDto(true);
            ServiceFactory.GetService<GameUiServiceLayer>().UpdateDto(GameUiType.GameMenu);
        }
    }
}