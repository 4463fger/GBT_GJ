using Game.Enemy;
using UnityEngine;

public class NormalBullet : BulletBase
{
    protected float bulletSpeed;

    protected override void Shoot()
    {
        gameObject.transform.localPosition += Time.deltaTime * bulletSpeed * transform.up;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer==6&&!enemyDamages.Contains(collision.gameObject.GetComponent<EnemyDamage>()))
        {
            Hit();
            EnemyDamage damage = collision.gameObject.GetComponent<EnemyDamage>();
            damage.Hurt(bulletDamage);
            enemyDamages.Add(collision.gameObject.GetComponent<EnemyDamage>());
            Destroy(gameObject);
        }
    }


}
