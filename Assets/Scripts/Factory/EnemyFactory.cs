using Enemy;
using ManagerScene;
using UnityEngine;

namespace Factory
{
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
                        ("哥布林", FightManager.Instance.EnemySpawnRoot);
                    break;
                case EnemyType.Boar:
                    enemy = JKFrame.ResSystem.InstantiateGameObject<Boar>
                        ("野猪",FightManager.Instance.EnemySpawnRoot);
                    break;
                case EnemyType.Slime:
                    enemy = JKFrame.ResSystem.InstantiateGameObject<Slime>
                        ("史莱姆",FightManager.Instance.EnemySpawnRoot);
                    break;
            }
            return enemy as T;
        }
    }
}