using MVC.Service;

namespace Core.LevelEntity.ServiceLayer
{
    public class ScoreServiceLayer  : ServiceLayer<ScoreType,ScoreType>
    {
        public override ScoreType GetContext()
        {
            return dto;
        }
    }

    public enum ScoreType
    {
        Unset = 0,
        Passed = 1,
        Combo = 2,
        NotCombo = 3,
    }
}