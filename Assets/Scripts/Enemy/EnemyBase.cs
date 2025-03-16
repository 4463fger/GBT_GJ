using UnityEngine;

namespace Game.Enemy
{
    public enum EnemyType
    {
        Goblin,
        Boar,
    }
    // 怪物基类
    public abstract class EnemyBase<T> : MonoBehaviour,IEnemy where T : EnemyBase<T>
    {
        public float maxHp;
        public float curHp;
        public float Speed;
        public float Attack;
        
        private void Update()
        {
            //TODO:按照路径网格开始寻路移动
        }

        public virtual void Hurt()
        {
            if (maxHp <= 0)
            {
                Destroy(this.gameObject);        
            }
        }

        // 死亡
        protected abstract void Die();
    }
}