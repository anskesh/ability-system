using System.Collections.Generic;
using AbilitySystem.Scripts.Entities;
using Services;
using UnityEngine;

namespace AbilitySystem.Scripts.SceneContexts
{
    public class GameplaySceneContext : SceneContext
    {
        [SerializeField] private Entity _player;
        
        [SerializeField] private List<Entity> _enemies;
        
        public override void Install()
        {
            _player.Setup();

            foreach (var enemy in _enemies)
            {
                enemy.Setup();
            }
        }

        public override void DeInstall()
        {
        }
    }
}