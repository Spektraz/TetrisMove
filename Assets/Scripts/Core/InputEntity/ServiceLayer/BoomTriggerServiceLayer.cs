using MVC.Service;

namespace Core.InputEntity.ServiceLayer
{
    public class BoomTriggerServiceLayer   : ServiceLayer<bool,bool>
    {
        public override bool GetContext()
        {
            return dto;
        }
    }
}


