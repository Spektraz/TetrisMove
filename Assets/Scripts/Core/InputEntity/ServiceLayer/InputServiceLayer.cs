using MVC.Service;

namespace Core.InputEntity.ServiceLayer
{
    public class InputServiceLayer : ServiceLayer<InputState,InputState>
    {
        public override InputState GetContext()
        {
            return dto;
        }
    }

    public enum InputState
    {
        Zero = 0,
        Left = 1,
        Right = 2,
    }
}