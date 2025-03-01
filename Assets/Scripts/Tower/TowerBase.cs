using UnityEngine;

public class TowerBase : MonoBehaviour
{
    protected float attackRadius;//¹¥»÷°ë¾¶

    protected float attackInterval;//¹¥»÷¼ä¸ô

    protected float attackDamage;//¹¥»÷ÉËº¦

    protected float attackTimer;//¹¥»÷¼ÆÊ±Æ÷

    protected virtual void Awake()
    {
        attackTimer = attackInterval;
    }
}
