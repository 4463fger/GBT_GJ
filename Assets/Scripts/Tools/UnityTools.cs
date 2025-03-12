using UnityEngine;

namespace Tools
{
    public static class UnityTools
    {
        // 检测鼠标位置是否有2D碰撞体
        public static void ScreenPointToRay2D(Camera camera, Vector3 mousePos, System.Action<Collider2D> callBack)
        {
            Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
            Collider2D col =Physics2D.OverlapCircle(worldPos, 0.02f);
            callBack?.Invoke(col);
        }
    }
}