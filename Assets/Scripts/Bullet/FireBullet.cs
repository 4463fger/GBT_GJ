using Enemy;
using Managers;
using UnityEngine;

namespace Item.Bullet
{
    public class FireBullet : BulletBase
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
            if (collision.gameObject.layer == 6 &&
                !enemyDamages.Contains(collision.gameObject.GetComponent<IHurt>()))
            {
                Hit();
                Vector3 currentGrid = collision.gameObject.transform.position;
                Vector3 newGridPos = new Vector3(0, 0, 0);
                //TODO:射击怪物造成伤害
                // 不用获取格子坐标，格子是用来生成地图用的，跟战斗没任何关系，这里需要改
                //Vector3 newGridPos = FightManager.Instance.getCoordinates(currentGrid);
                //newGridPos = FightManager.Instance.getGridCoordinates(newGridPos);
                Instantiate(fireGrid, newGridPos, Quaternion.identity);
                ChangeSprite();
                if (isChanged)
                {

                }
            }
        }

        private void ChangeSprite()
        {
            Sprite currtSprite = GetComponent<SpriteRenderer>().sprite;
            GetComponent<SpriteRenderer>().renderingLayerMask = 4;
            isChanged = true;
            GetComponent<SpriteRenderer>().sortingOrder = 100;
            currtSprite = fireGrid;
            bulletSpeed = 0;
            destroyTimer = destroyTime;
        }
    }
}