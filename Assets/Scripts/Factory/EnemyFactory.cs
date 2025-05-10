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
                        ("哥布林", FightManager.Instance.EnemySpawnRoot);
                    break;
                case EnemyType.RollGlobin:
                    enemy = JKFrame.ResSystem.InstantiateGameObject<RollGoblin>
                        ("滚动哥布林", FightManager.Instance.EnemySpawnRoot);
                    break;
                case EnemyType.BoxGlobin:
                    enemy = JKFrame.ResSystem.InstantiateGameObject<BoxGlobin>
                        ("箱子哥布林", FightManager.Instance.EnemySpawnRoot);
                    break;
                case EnemyType.WaterGlobin:
                    enemy = JKFrame.ResSystem.InstantiateGameObject<WaterGlobin>
                        ("水哥布林", FightManager.Instance.EnemySpawnRoot);
                    break;
                case EnemyType.Skeleton:
                    enemy = JKFrame.ResSystem.InstantiateGameObject<Skeleton>
                        ("小骷髅", FightManager.Instance.EnemySpawnRoot);
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