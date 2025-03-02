using UnityEngine;

namespace Game.Enemy
{
    // 怪物基类
    public abstract class EnemyBase : MonoBehaviour,IEnemy
    {
        public float Hp;
        public float Speed;
        public float Attack;
        
        private void Update()
        {
            //TODO:按照路径网格开始寻路移动
        }

        public virtual void Hurt()
        {
            if (Hp <= 0)
            {
                Destroy(this.gameObject);        
            }
        }
    }
}