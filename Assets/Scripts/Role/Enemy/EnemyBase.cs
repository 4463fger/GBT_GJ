using DG.Tweening;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Enemy
{
    public enum EnemyType
    {
        Slime,
        Goblin,
        Boar,
    }
    // 怪物基类
    public abstract class EnemyBase<T> : MonoBehaviour,IHurt where T : EnemyBase<T>
    {
        [SerializeField] protected float maxHp;
        [SerializeField] protected float curHp;
        [SerializeField] protected float Speed;
        [SerializeField] protected float Attack;

        // 怪物的路径坐标
        protected List<Vector2> pathQueue;
        protected bool isMoving; // 是否正在移动

        protected bool isInit;

        public bool isDie { get; protected set; }

        protected virtual void Awake()
        {
            pathQueue = new();
        }
        
        /// <summary>
        /// 敌人的初始化
        /// </summary>
        /// <param name="LoadList">路径点</param>
        public void Init(List<Vector2> LoadList)
        {
            Debug.Log("怪物创建时的初始化");
            if (isInit == false)
            {
                isDie = false;
                isInit = true;
                transform.position = FightManager.Instance.EnemySpawnRoot.position;
            }
            pathQueue.Clear();
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
                Vector2 targetPos = pathQueue[0];
                pathQueue.RemoveAt(0);
                
                transform.DOMove(targetPos, 0.5f)
                    .SetEase(Ease.Linear)
                    .OnComplete(() => {
                        isMoving = false;
                    });
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
        protected abstract void Die();
    }
}