using MVC.Controller;
using UnityEngine;

namespace MVC.View
{
    public abstract class View : MonoBehaviour
    {

        protected IController Controller
        {
            get
            {
                if (controller == null)
                {
                    controller = CreateController();
                    OnControllerCreate(controller);
                }

                return controller;
            }
        }

        private IController controller;

        protected virtual void Start()
        {
            Controller.AddListeners();
        }

        protected virtual void OnDestroy()
        {
            controller?.RemoveListeners();
        }

        protected abstract IController CreateController();
        
        protected virtual void OnControllerCreate(IController controller){}

      
    }
}