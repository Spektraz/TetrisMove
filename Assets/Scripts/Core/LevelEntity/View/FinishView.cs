using Core.FinishGameEntity.ServiceLayer;
using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;

namespace Core.LevelEntity.View
{
    public class FinishView : MVC.View.View
    {
        
        public void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            Controller.Execute();
        }

        protected override IController CreateController() => new FinishController(this);
    }
    public class FinishController  : Controller<FinishView>
    {
        public FinishController(FinishView view) : base(view)
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
            ServiceFactory.GetService<FinishGameServiceLayer>().UpdateDto(false);
            ServiceFactory.GetService<GameUiServiceLayer>().UpdateDto(GameUiType.FinishMenu);
        }
    }
}