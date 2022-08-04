using Core.GameStart.ServiceLayer;
using Core.HeroEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;

namespace Core.LevelEntity.View
{
    public class RigidbodyWallView : MVC.View.View
    {
        private Rigidbody rd;

        protected override void Start()
        {
            rd = gameObject.GetComponent<Rigidbody>();
        }
        public void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            Controller.Execute();
            rd.useGravity = true;
        }

        protected override IController CreateController() => new RigidbodyWallController(this);
    }
    public class RigidbodyWallController : Controller<RigidbodyWallView, StartGameServiceLayer>
    {
        public RigidbodyWallController(RigidbodyWallView view) : base(view)
        {
        }
        protected override void HandleServiceLayer()
        {
        }

        public override void Execute()
        {
            ServiceFactory.GetService<StanServiceLayer>().UpdateDto(true);
        }
    }
}
