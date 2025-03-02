using UnityEngine;

namespace Game.Enemy
{
    public enum EnemyType
    {
        哥布林,
        野猪,
    }
    
    public class Enemy : MonoBehaviour,IEnemy
    {
        public void Hurt()
        {
            
        }
    }
}