using Meta.UiEntity.Model;
using MVC.Service;

namespace Meta.UiEntity.ServiceLayer
{
    public class OpenLockServiceLayer  : ServiceLayer<SkyboxName,SkyboxName>
    {
        public override SkyboxName GetContext()
        {
            return dto;
        }
    }
}