using Enemy;
using UnityEngine;

namespace Item.Bullet
{
    public class NormalBullet : BulletBase
    {
        protected float bulletSpeed=10f;
        private float rotateSpeed=200f;
        protected override void Shoot()
        {
            // 计算朝向目标的方向
            Vector2 direction = (Vector2)enemyTarget.transform.position - (Vector2)gameObject.transform.position;
            direction.Normalize();

            // 平滑旋转朝向目标
            float rotateStep = rotateSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateStep);

            // 向前移动（基于当前朝向）
            transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime, Space.Self);

        }
        protected override void Update() 
        {
            base.Update();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 128)  
            {
                Hit();
                IHurt damage = collision.gameObject.GetComponent<IHurt>();
                damage.Hurt(bulletDamage);
                print("扣血");
                enemyDamages.Add(collision.gameObject.GetComponent<IHurt>());
                Destroy(gameObject);
            }
        }
    }
}
