using MVC.Service;

namespace Core.FinishGameEntity.ServiceLayer
{
    public class FinishGameServiceLayer: ServiceLayer<bool,bool>
    {
        public override bool GetContext()
        {
            return dto;
        }
    }
}
