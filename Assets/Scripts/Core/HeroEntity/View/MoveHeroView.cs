using System;
using System.Collections;
using Core.FinishGameEntity.ServiceLayer;
using Core.GameStart.ServiceLayer;
using Core.HeroEntity.ServiceLayer;
using Core.InputEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;

namespace Core.HeroEntity.View
{
    public class MoveHeroView : MVC.View.View
    {
        
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform transformObject;
        private const int MoveScore = 2;
        private const int MoveStan = 1;
        private HeroState gameState;
        public void SetGame(HeroState heroState)
        {
            gameState = heroState;
        }
        private void Update()
        {
            if (gameState == HeroState.Start)
            {
                var o = gameObject;
                var position = o.transform.position;
                position = new Vector3(position.x - MoveScore * Time.deltaTime,
                    position.y, position.z);
                o.transform.position = position;
                rb.position = new Vector3(rb.position.x - MoveScore * Time.deltaTime, rb.position.y, rb.position.z);
            }
            else if (gameState == HeroState.Stan)
            {
                StartCoroutine(WaitStan());
            }
            else if (gameState == HeroState.End)
            {
                return;
            }
        }

        public void MoveHero(InputState inputState, int rotate)
        {
            if (inputState == InputState.Right)
            {
                Vector3 rotationToAdd = new Vector3(0, -rotate, 0);
                transformObject.transform.Rotate(rotationToAdd);
            }
            else if (inputState == InputState.Left)
            {
                Vector3 rotationToAdd = new Vector3(0, rotate, 0);
                transformObject.transform.Rotate(rotationToAdd);
            }
              
        }
        private IEnumerator WaitStan()
        {
            var o = gameObject;
            var position = o.transform.position;
            position = new Vector3(position.x + MoveStan * Time.deltaTime,
                position.y, position.z);
            o.transform.position = position;
            rb.position = new Vector3(rb.position.x + MoveStan * Time.deltaTime,rb.position.y,rb.position.z);
            yield return new WaitForSeconds(1.0f);
            gameState = HeroState.Start;
        }
        protected override IController CreateController() => new MoveHeroController(this);
    }
    public class MoveHeroController: Controller<MoveHeroView, StartGameServiceLayer>
    {
        private const int RotateHero = 90;
        private StanServiceLayer stanServiceLayer;
        private InputServiceLayer inputServiceLayer;
        private FinishGameServiceLayer finishGameServiceLayer;
        public MoveHeroController(MoveHeroView view) : base(view)
        {
            stanServiceLayer = ServiceFactory.GetService<StanServiceLayer>();
            inputServiceLayer = ServiceFactory.GetService<InputServiceLayer>();
            finishGameServiceLayer = ServiceFactory.GetService<FinishGameServiceLayer>();
        }

        public override void AddListeners()
        {
            base.AddListeners();
            stanServiceLayer.DtoHandler.AddListener(SetStan);
            inputServiceLayer.DtoHandler.AddListener(MoveHero);
            finishGameServiceLayer.DtoHandler.AddListener(SetEnd);
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            stanServiceLayer.DtoHandler.RemoveListener(SetStan);
            inputServiceLayer.DtoHandler.RemoveListener(MoveHero);
            finishGameServiceLayer.DtoHandler.RemoveListener(SetEnd);
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

        private void SetEnd()
        {
            View.SetGame(HeroState.End);
        }
        private void MoveHero()
        {
            View.MoveHero(inputServiceLayer.GetContext(), RotateHero);
        }
    }

    public enum HeroState
    {
        End = 0,
        Start = 1,
        Stan = 2
    }
}
