using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace GameRoot
{
    public class SceneLoader
    {
        private Coroutine _loading;

        public void LoadAndRunGameplayLevelsMode()
        {
            StopLoading();
            Coroutines.Start(LoadAndRunScene(Scenes.GAMEPLAY_LEVELS_MODE));
        }

        private IEnumerator LoadAndRunScene(string sceneName)
        {
            yield return LoadScene(sceneName);
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return null;
        }

        private void StopLoading()
        {
            if (_loading != null)
                Coroutines.Stop(_loading);
        }
    }
}