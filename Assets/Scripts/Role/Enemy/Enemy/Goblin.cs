using JKFrame;

namespace Enemy
{
    public class Goblin : EnemyBase<Goblin>
    {
        protected override void Die()
        {
            ResSystem.PushGameObjectInPool(this.gameObject);
        }
    }
}