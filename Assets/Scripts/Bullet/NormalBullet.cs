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
            // ���㳯��Ŀ��ķ���
            Vector2 direction = (Vector2)enemyTarget.transform.position - (Vector2)gameObject.transform.position;
            direction.Normalize();

            // ƽ����ת����Ŀ��
            float rotateStep = rotateSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateStep);

            // ��ǰ�ƶ������ڵ�ǰ����
            transform.Translate(Vector3.up * (bulletSpeed * Time.deltaTime), Space.Self);

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
                Debug.Log("碰到了");
                enemyDamages.Add(collision.gameObject.GetComponentInParent<IHurt>());
                Destroy(this.gameObject);
            }
        }
    }
}
