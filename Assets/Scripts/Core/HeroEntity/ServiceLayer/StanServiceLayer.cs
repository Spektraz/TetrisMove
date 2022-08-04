using MVC.Service;

namespace Core.HeroEntity.ServiceLayer
{
    public class StanServiceLayer : ServiceLayer<bool,bool>
    {
        public override bool GetContext()
        {
            return dto;
        }
    }
}