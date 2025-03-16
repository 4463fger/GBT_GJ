using JKFrame;

namespace Game.Enemy
{
    public class Goblin : EnemyBase<Goblin>
    {
        public override void Hurt()
        {
            
        }

        private void Start()
        {
            Invoke(nameof(Die),1f);
        }

        protected override void Die()
        {
            ResSystem.PushGameObjectInPool(this.gameObject);
        }
    }
}