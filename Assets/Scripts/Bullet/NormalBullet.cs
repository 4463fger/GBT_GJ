using Enemy;
using UnityEngine;

namespace Item.Bullet
{
    public class NormalBullet : BulletBase
    {
        protected float bulletSpeed;

        protected override void Shoot()
        {
            gameObject.transform.localPosition += Time.deltaTime * bulletSpeed * transform.up;

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 6 &&
                !enemyDamages.Contains(collision.gameObject.GetComponent<IHurt>()))
            {
                Hit();
                IHurt damage = collision.gameObject.GetComponent<IHurt>();
                damage.Hurt(bulletDamage);
                enemyDamages.Add(collision.gameObject.GetComponent<IHurt>());
                Destroy(gameObject);
            }
        }
    }
}
