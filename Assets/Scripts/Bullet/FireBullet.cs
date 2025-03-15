using UnityEngine;

public class FireBullet:BulletBase
{
    protected float bulletSpeed;
    protected GameObject fireGrid;
    protected override void Shoot()
    {
        gameObject.transform.localPosition += Time.deltaTime * bulletSpeed * transform.up;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 && !enemyDamages.Contains(collision.gameObject.GetComponent<EnemyDamage>()))
        {
            Hit();
            Vector3 currentGrid = collision.gameObject.transform.position;
            Instantiate(fireGrid, currentGrid, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}