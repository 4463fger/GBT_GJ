using Enemy;
using UnityEngine;

namespace Item.Bullet
{
    public class NormalBullet : BulletBase
    {
        protected float bulletSpeed=10f;
        private float rotateSpeed=200f;
        private Vector3 direction;
        protected override void Shoot()
        {
            // 如果有目标敌人，则计算方向
            if (enemyTarget != null)
            {
                direction = (enemyTarget.transform.position - transform.position).normalized;
            }
            transform.position += direction * bulletSpeed * Time.deltaTime;

        }
        protected override void Update() 
        {
            base.Update();
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy")) 
            {
                // Hit();
                IHurt damage = collision.gameObject.GetComponentInParent<IHurt>();
                damage.Hurt(bulletDamage);
                enemyDamages.Add(damage);
                //TODO:把子弹放入对象池
                DestroyBullet();
            }
        }
    }
}
