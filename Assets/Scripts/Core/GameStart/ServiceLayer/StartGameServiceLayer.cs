using MVC.Service;

namespace Core.GameStart.ServiceLayer
{
    public class StartGameServiceLayer : ServiceLayer<bool,bool>
    {
        public override bool GetContext()
        {
            return dto;
        }
    }
}