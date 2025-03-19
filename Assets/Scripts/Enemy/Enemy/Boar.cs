using JKFrame;

namespace Game.Enemy
{
    public class Boar : EnemyBase<Boar>
    {
        public override void Hurt()
        {
            // 死亡后调用Die
            if (curHp <= 0)
            {
                Die();
            }
        }

        // 死亡
        protected override void Die()
        {
            ResSystem.PushGameObjectInPool(this.gameObject);
        }
    }
}