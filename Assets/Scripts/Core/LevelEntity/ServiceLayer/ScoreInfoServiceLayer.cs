using MVC.Service;
namespace Core.LevelEntity.ServiceLayer
{
    public class ScoreInfoServiceLayer  : ServiceLayer<int,int>
    {
        public override int GetContext()
        {
            return dto;
        }
    }
}

