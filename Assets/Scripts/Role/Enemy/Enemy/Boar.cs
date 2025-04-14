using JKFrame;

namespace Enemy
{
    public class Boar : EnemyBase<Boar>
    {
        // 死亡
        protected override void Die()
        {
            ResSystem.PushGameObjectInPool(this.gameObject);
        }
    }
}