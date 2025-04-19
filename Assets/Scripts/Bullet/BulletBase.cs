using System.Collections.Generic;
using JKFrame;
using UnityEngine;
using Enemy;

namespace Item.Bullet
{
    /// <summary>
    /// 子弹基类
    /// </summary>
    public abstract class BulletBase : MonoBehaviour
    {
        protected float bulletDamage;
        [SerializeField] protected float destroyTime;
        protected float destroyTimer;
        protected AudioClip hitClip;
        protected Collider2D bulletCollider;
        protected GameObject enemyTarget;
        protected HashSet<IHurt> enemyDamages = new HashSet<IHurt>();
        
        public void SetTarget(GameObject gameObject)
        {
            enemyTarget = gameObject;
        }
        protected virtual void Awake()
        {
            destroyTimer = destroyTime;
        }

        protected virtual void Update()
        {
            destroyTimer -= Time.deltaTime;
            Shoot();
            if (destroyTimer <= 0) DestroyBullet();
        }
        protected abstract void Shoot();

        protected virtual void Hit()
        {
            AudioSystem.PlayOneShot(hitClip);
        }

        protected virtual void DestroyBullet()
        {
            Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}