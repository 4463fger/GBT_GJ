using Game.Enemy;

namespace Factory
{
    public class EnemyFactory : IFactory
    {
        public IEnemy CreateEnemy(EnemyType type)
        {
            IEnemy enemy = null;
            switch (type)
            {
                case EnemyType.Goblin:
                    enemy =  JKFrame.ResSystem.LoadAsset<EnemyBase>("Resources/Prefabs/Enemy/哥布林");
                    break;
                case EnemyType.Boar:
                    enemy = JKFrame.ResSystem.LoadAsset<EnemyBase>("Resources/Prefabs/Enemy/野猪");
                    break;
            }
            return enemy;
        }
    }
}