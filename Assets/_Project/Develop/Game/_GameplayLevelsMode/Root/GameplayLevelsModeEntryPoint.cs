using GameRoot;
using System.Collections;
using UnityEngine;
using Zenject;
using Player;

namespace GameplayLevelsMode
{
    public class GameplayLevelsModeEntryPoint : SceneEntryPoint
    {
        [SerializeField] private PlayerView _playerViewPrefab;

        private PlayerFactory _playerFactory;

        [Inject]
        private void Construct(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public override IEnumerator Run<T>(T enterParams)
        {
            var castedEnterParams = enterParams.As<GameplayLevelsModeEnterParams>();
            var isLoaded = false;

            _playerFactory.Create(_playerViewPrefab);

            isLoaded = true;

            yield return new WaitUntil(() => isLoaded);
        }
    }
}