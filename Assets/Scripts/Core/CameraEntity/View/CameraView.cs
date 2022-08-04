using Core.GameStart.ServiceLayer;
using Core.HeroEntity.ServiceLayer;
using Core.HeroEntity.View;
using Core.LevelEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;

namespace Core.CameraEntity.View
{
    public class CameraView : MVC.View.View
    {
        private const int StanScore = 1;
        private const int MoveScore = 2;
        private HeroState gameState;
        public void SetGame(HeroState heroState)
        {
            gameState = heroState;
        }
        public void Update()
        {
            var o = gameObject;
            var position = o.transform.position;
            if (gameState == HeroState.Start)
            {
                position = new Vector3(position.x - MoveScore * Time.deltaTime,
                    position.y, position.z);
                o.transform.position = position;
            }
            else if (gameState == HeroState.Stan)
            {
                Controller.Execute();
                position = new Vector3(position.x + StanScore * Time.deltaTime,
                    position.y, position.z);
                o.transform.position = position;
            }
        }
        protected override IController CreateController() => new CameraController(this);
    }

    public class CameraController : Controller<CameraView, StartGameServiceLayer>
    {
        private readonly StanServiceLayer stanServiceLayer;
        public CameraController(CameraView view) : base(view)
        {
            stanServiceLayer = ServiceFactory.GetService<StanServiceLayer>();
        }
        public override void AddListeners()
        {
            base.AddListeners();
            stanServiceLayer.DtoHandler.AddListener(SetStan);
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            stanServiceLayer.DtoHandler.RemoveListener(SetStan);
        }
        protected override void HandleServiceLayer()
        {
            if(serviceLayer.GetContext())
                View.SetGame(HeroState.Start);
        }

        private void SetStan()
        {
            View.SetGame(HeroState.Stan);
        }

        public override void Execute()
        {
            base.Execute();
            ServiceFactory.GetService<ScoreServiceLayer>().UpdateDto(ScoreType.NotCombo);
        }
    }
}