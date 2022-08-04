using System;
using Core.InputEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Core.InputEntity.View
{
    public class InputView : MVC.View.View
    {
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        public void AddListenerLeft(Action action)
        {
            leftButton.onClick.AddListener(action.Invoke);
        }
        public void AddListenerRight(Action action)
        {
            rightButton.onClick.AddListener(action.Invoke);
        }

        public void RemoveListener()
        {
            rightButton.onClick.RemoveAllListeners();
            leftButton.onClick.RemoveAllListeners();
        }
        protected override IController CreateController() => new InputController(this);
    }

    public class InputController : Controller<InputView>
    {
        public InputController(InputView view) : base(view)
        {
        }

        public override void AddListeners()
        {
            View.AddListenerLeft(LeftClick);
            View.AddListenerRight(RightClick);
        }

        public override void RemoveListeners()
        {
            View.RemoveListener();
        }

        private void RightClick()
        {
            ServiceFactory.GetService<InputServiceLayer>().UpdateDto(InputState.Right);
        }

        private void LeftClick()
        {
            ServiceFactory.GetService<InputServiceLayer>().UpdateDto(InputState.Left);
        }
    }
}