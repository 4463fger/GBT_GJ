using UnityEngine;
using Config;
namespace Tower
{
    /// <summary>
    /// 塔的基类
    /// </summary>
    public class TowerBase : MonoBehaviour
    {

        private int PosX;
        private int PosY;

        public void SetPos(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        protected float gridLength=1; //砖块的大小，用于计算攻击距离

        [SerializeField] protected LayerMask enemyLayer; //敌人层

        [Header("塔的数据")] 
        
        protected float attackRadius; //攻击半径

        protected float attackInterval; //攻击间隔

        protected float attackDamage; //攻击伤害

        protected float attackTimer; //攻击计时器

        [SerializeField]protected GameObject Bullet; //塔的子弹



        protected virtual void Update()
        {
            if(attackTimer>0)
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0 && isHaveEnemy())
            {
                Attack();        // 调用攻击方法
                attackTimer = attackInterval; // 重置计时器
            }
        }
        protected virtual void Attack() 
        { }

        protected bool isTimeEnd()
        {
            return attackTimer == attackInterval;
        }
        public Collider2D[] collider2Ds;
        protected Collider2D[] getEnemyCollider()
        {
            collider2Ds= Physics2D.OverlapCircleAll(gameObject.transform.position, attackRadius * gridLength, enemyLayer);
            return Physics2D.OverlapCircleAll(gameObject.transform.position, attackRadius * gridLength, enemyLayer);
        }

        protected bool isHaveEnemy()
        {
            return getEnemyCollider().Length > 0;
        }

        public void InitTower(TowerConfig towerConfig)
        {
            this.attackRadius = towerConfig.attackRadius;
            this.attackDamage= towerConfig.attackDamage;
            this.attackInterval= towerConfig.attackInterval;
            attackTimer = attackInterval;
        }
    }
}