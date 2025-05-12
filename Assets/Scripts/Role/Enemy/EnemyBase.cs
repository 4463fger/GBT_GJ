using DG.Tweening;
using System.Collections.Generic;
using JKFrame;
using Managers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Enemy
{
    public enum EnemyType
    {
        Slime,
        Goblin,
        Skeleton,
        RollGlobin,
        WaterGlobin,
        BoxGlobin,
    }
    // 怪物基类
    public abstract class EnemyBase<T> : MonoBehaviour,IHurt where T : EnemyBase<T>
    {
        [SerializeField] protected float maxHp;
        protected float curHp;
        [SerializeField] protected float Speed;
        [SerializeField] protected float Attack;

        // 怪物的路径坐标
        protected List<Vector2> pathQueue;
        protected bool isMoving; // 是否正在移动

        protected bool isRight = true;
        private bool isOnFirstPoint = true;

        public bool isDie { get; protected set; }

        protected virtual void Awake()
        {
            pathQueue = new();
            curHp = maxHp;
        }
        
        /// <summary>
        /// 敌人的初始化
        /// </summary>
        /// <param name="LoadList">路径点</param>
        public void Init(List<Vector2> LoadList,Transform spawnPos)
        {
            isDie = false;
            pathQueue.Clear();
            isOnFirstPoint = true;
            
            // 将配置中的格子坐标转化为世界坐标并存为路径
            for (int i = 0; i < LoadList.Count; i++)
            {
                Vector3 roadPoint = FightManager.Instance.MapManager.GetWorldPosition((int)LoadList[i].x,(int)LoadList[i].y);
                pathQueue.Add(roadPoint);
            }
        }

        protected virtual void Update()
        {
            if (isDie)
                return;
            Move();
            if((Vector2)gameObject.transform.position==FightManager.Instance.Destination)
            {
                print("怪到了");
            }
        }

        private void Move()
        {
            if(isMoving == false)
            {
                if (pathQueue.Count == 0)
                {
                    isMoving = false;
                    return;
                }
                isMoving = true;

                if (isOnFirstPoint == true)
                {
                    Vector2 startPos = pathQueue[0];
                    pathQueue.RemoveAt(0);

                    if ((Vector2)transform.position != startPos)
                    {
                        var position = transform.position;
                        position.x = startPos.x;
                        position.y = startPos.y;
                        transform.position = position;
                    }
                    Debug.Log("起始点坐标:"+startPos + "怪物坐标:" + transform.position);
                    isOnFirstPoint = false;
                }
                
                Vector2 targetPos = pathQueue[0];
                pathQueue.RemoveAt(0);
                
                SerDir(targetPos);

                float animationTime = 1f / (Speed * 0.1f);
                transform.DOMove(targetPos, animationTime)
                    .SetEase(Ease.Linear)
                    .OnComplete(() => {
                        isMoving = false;
                    });
            }
        }

        protected virtual void SerDir(Vector2 targetPos)
        {
            
                // 转向
                Vector2 direction = (targetPos - (Vector2)transform.position).normalized;
                if (direction.x > 0)
                {
                    if (isRight == true)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                }
                else 
                {
                    if (isRight == false)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                }

        }


        public virtual void Hurt(float damage)
        {
            curHp -= damage;
            
            if (curHp <= 0)
            {
                Die();
            }
        }
        
        // 死亡
        protected virtual void Die()
        {
            isDie = true;
            transform.position = FightManager.Instance.EnemySpawnRoot.position;

            Destroy(gameObject);
            Addressables.ReleaseInstance(this.gameObject);
        }
    }
}