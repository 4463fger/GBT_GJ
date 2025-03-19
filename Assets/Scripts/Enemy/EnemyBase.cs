using System;
using DG.Tweening;
using Map;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public enum EnemyType
    {
        Goblin,
        Boar,
    }
    // 怪物基类
    public abstract class EnemyBase<T> : MonoBehaviour,IEnemy where T : EnemyBase<T>
    {
        public float maxHp;
        public float curHp;
        public float Speed;
        public float Attack;

        private void Awake()
        {
<<<<<<< HEAD
            MoveTowards(GameApp.Instance.MapManager.LoadRoad(0));
=======
            pathQueue = new();
>>>>>>> b80dbf9396424941ebc546484561d360b0f6cce6
        }

        public virtual void Hurt()
        {
            if (maxHp <= 0)
            {
                Destroy(this.gameObject);        
            }
        }

        // 死亡
        protected abstract void Die();

<<<<<<< HEAD






        /// <summary>
        /// 敌人的移动
        /// </summary>
        /// <param name="LoadList"></param>
        public void MoveTowards(List<Vector2> LoadList)
=======
        public void Move(List<Vector2> LoadList)
>>>>>>> b80dbf9396424941ebc546484561d360b0f6cce6
        {
            pathQueue.Clear();
            pathQueue.AddRange(LoadList);
            if(!isMoving)
            {
                StartNextMove();
            }
        }
        
        private List<Vector2> pathQueue;
        private bool isMoving;
        private void StartNextMove()
        {
            isMoving = true;
            Vector2 targetGrid = pathQueue[0];
            pathQueue.RemoveAt(0);

            Vector2 targetWorld = FightManager.Instance.getGridCoordinates(targetGrid);
            transform.DOMove(targetWorld, 0.5f)
            .SetEase(Ease.Linear)
            .OnComplete(() => {
                isMoving = false;
                StartNextMove(); // 移动下一个点
            });
        }
    }
}