using JKFrame;

namespace Game.Enemy
{
    public class Goblin : EnemyBase<Goblin>
    {
        public override void Hurt()
        {
            // 死亡后调用Die
            if (curHp <= 0)
            {
                Die();
            }
        }

        protected override void Die()
        {
            ResSystem.PushGameObjectInPool(this.gameObject);
        }
    }
}