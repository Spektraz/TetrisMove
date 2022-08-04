using Core.InputEntity.ServiceLayer;
using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Core.InputEntity.View
{
    public class BlockUseView: MVC.View.View
    {
        [SerializeField] private Button left;
        [SerializeField] private Button right;
        public void SetButton(bool state)
        {
            left.enabled = state;
            right.enabled = state;
        }
        
        public void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            Controller.Execute();
        }
        
        protected override IController CreateController() => new BlockUseController(this);
    }
    public class BlockUseController : Controller<BlockUseView,BoomTriggerServiceLayer>
    {
        public BlockUseController(BlockUseView view) : base(view)
        {
        }
        protected override void HandleServiceLayer()
        {
            View.SetButton(serviceLayer.GetContext());
        }

        public override void Execute()
        {
            base.Execute();
            ServiceFactory.GetService<GameUiServiceLayer>().UpdateDto(GameUiType.SwitchOff);
            View.SetButton(false);
        }
    }
}