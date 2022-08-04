using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;

namespace Core.LevelEntity.View
{
    public class TriggerScoreView : MVC.View.View
    {
        private bool stateBlock;

        public bool  StateBlock()
        {
           return stateBlock;
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Wool"))
                stateBlock = true;
            if (!other.gameObject.CompareTag("Player")) return;
            Controller.Execute();
        }

        protected override IController CreateController() => new TriggerScoreController(this);
    }
    public class TriggerScoreController : Controller<TriggerScoreView>
    {
        public TriggerScoreController(TriggerScoreView view) : base(view)
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
            if(!View.StateBlock())
              ServiceFactory.GetService<ScoreServiceLayer>().UpdateDto(ScoreType.Passed);
        }
    }
}
