using GameRoot;
using System.Collections;
using UnityEngine;

namespace GameplayLevelsMode
{
    public class GameplayLevelsModeEntryPoint : SceneEntryPoint
    {
        public override IEnumerator Run<T>(T enterParams)
        {
            var castedEnterParams = enterParams.As<GameplayLevelsModeEnterParams>();
            var isLoaded = false;

            isLoaded = true;

            yield return new WaitUntil(() => isLoaded);
        }
    }
}