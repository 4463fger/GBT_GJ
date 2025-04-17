using Enemy;
using Managers;
using UnityEngine;

namespace Factory
{
    //TODO:没有跟对象池关联
    public class EnemyFactory : IFactory
    {
        public EnemyFactory()
        {
        }
        
        public T CreateEnemy<T>(EnemyType type) where T : MonoBehaviour, IHurt
        {
            IHurt enemy = null;

            switch (type)
            {
                case EnemyType.Goblin:
                    enemy = JKFrame.ResSystem.InstantiateGameObject<Goblin>
                        ("Prefabs/Enemy/哥布林", FightManager.Instance.EnemySpawnRoot);
                    break;
                case EnemyType.Boar:
                    enemy = JKFrame.ResSystem.InstantiateGameObject<Boar>
                        ("Prefabs/Enemy/野猪",FightManager.Instance.EnemySpawnRoot);
                    break;
            }
            return enemy as T;
        }
    }
}