using System;
using Core.LevelEntity.ServiceLayer;
using Meta.UiEntity.Model;
using Meta.UiEntity.ServiceLayer;
using MVC.Controller;
using MVC.Factory;
using MVC.View;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.UiEntity
{
    public class BuySkyBoxView : View
    {
        [SerializeField] private Button button;
        [SerializeField] private SkyboxName skyboxName;

        public SkyboxName SkyboxName()
        {
            return skyboxName;
        }
        public void AddListener(Action action)
        {
            button.onClick.AddListener(action.Invoke);
        }
        public void RemoveListener()
        {
            button.onClick.RemoveAllListeners();
        }
        protected override IController CreateController() => new BuySkyBoxViewController(this);
    }
    public class BuySkyBoxViewController : Controller<BuySkyBoxView,ScoreInfoServiceLayer>
    {
        private int newScore;
        private MainMenuBuySkyBoxServiceLayer mainMenuBuySkyBoxServiceLayer;
         public BuySkyBoxViewController(BuySkyBoxView view) : base(view)
         {
             mainMenuBuySkyBoxServiceLayer = ServiceFactory.GetService<MainMenuBuySkyBoxServiceLayer>();
         }
        
        public override void AddListeners()
        {
          View.AddListener(ClickButton);
        }

        public override void RemoveListeners()
        {
           View.RemoveListener();
        }

        protected override void HandleServiceLayer()
        {
        }

        private void ClickButton()
        {
            if (serviceLayer.GetContext() <
                mainMenuBuySkyBoxServiceLayer.GetSkyboxPriceModel(View.SkyboxName())) return;
            newScore = serviceLayer.GetContext() -
                       mainMenuBuySkyBoxServiceLayer.GetSkyboxPriceModel(View.SkyboxName());
            serviceLayer.UpdateDto(newScore);
            ServiceFactory.GetService<OpenLockServiceLayer>().UpdateDto(View.SkyboxName());
        }
    }
}