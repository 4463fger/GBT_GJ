using DG.Tweening;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Enemy
{
    public enum EnemyType
    {
        Goblin,
        Boar,
    }
    // 怪物基类
    public abstract class EnemyBase<T> : MonoBehaviour,IHurt where T : EnemyBase<T>
    {
        public float maxHp;
        public float curHp;
        public float Speed;
        public float Attack;

        private void Awake()
        {
            pathQueue = new();
        }

        // 死亡
        protected abstract void Die();

        public void Move(List<Vector2> LoadList)
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

        public virtual void Hurt(float damage)
        {
            curHp -= damage;
            
            if (curHp <= 0)
            {
                Die();
            }
        }
    }
}