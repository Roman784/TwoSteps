using GameRoot;

namespace GameplayLevelsMode
{
    public class GameplayLevelsModeEnterParams : SceneEnterParams
    {
        public GameplayLevelsModeEnterParams(string exitSceneName) : base(Scenes.GAMEPLAY_LEVELS_MODE, exitSceneName)
        {
        }
    }
}