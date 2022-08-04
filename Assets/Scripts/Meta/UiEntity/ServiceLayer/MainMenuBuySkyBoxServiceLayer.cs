using BaseService.ModelEntity;
using Meta.UiEntity.Model;
using MVC.Service;

namespace Meta.UiEntity.ServiceLayer
{
    public class MainMenuBuySkyBoxServiceLayer : ServiceLayer<BuySkyModel, int, MainMenuBuySkyBoxContext>
    {
        public int GetSkyboxPriceModel(SkyboxName skyboxName) =>
            ModelService.GetModel<BuySkyModel>().GetByName(skyboxName).PriceSkybox;

        public override MainMenuBuySkyBoxContext GetContext()
        {
            return new MainMenuBuySkyBoxContext
            {
                
            };

        }
    }

    public class MainMenuBuySkyBoxContext
    {
    }
}