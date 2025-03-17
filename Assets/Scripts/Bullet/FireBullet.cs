using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FireBullet:BulletBase
{
    protected float bulletSpeed;
    protected Sprite fireGrid;
    private bool isChanged;
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
            Vector3 newGridPos=FightManager.Instance.getCoordinates(currentGrid);
            newGridPos=FightManager.Instance.getGridCoordinates(newGridPos);
            Instantiate(fireGrid, newGridPos, Quaternion.identity);
            ChangeSprite();
            if(isChanged) 
            {

            }
        }
    }

    private void ChangeSprite()
    {
        Sprite currtSprite=GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().renderingLayerMask = 4;
        isChanged = true;
        GetComponent<SpriteRenderer>().sortingOrder = 100;
        currtSprite = fireGrid;
        bulletSpeed = 0;
        destroyTimer = destroyTime;
    }
}