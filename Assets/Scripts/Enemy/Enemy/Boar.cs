using JKFrame;

namespace Game.Enemy
{
    public class Boar : EnemyBase<Boar>
    {
        public override void Hurt()
        {
            
        }

        private void Start()
        {
        }

        // 死亡
        protected override void Die()
        {
            ResSystem.PushGameObjectInPool(this.gameObject);
        }
    }
}