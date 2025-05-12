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
        //规定起始位置是：（0，0）块位于（-9.5，-6.5）
        private static readonly Vector2 GridOrigin = new Vector2(-9.5f, -6.5f);
        private static readonly float GridSize = 1f;
        public static Vector2 currentEnemyGrid(Vector2 enemyPos)//敌人位置转当前格子世界坐标
        {
            float gridX = Mathf.Floor((enemyPos.x - GridOrigin.x) / GridSize);
            float gridY = Mathf.Floor((enemyPos.y - GridOrigin.y) / GridSize);
            return new Vector2(gridX, gridY);
        }
        public static Vector2 currentGridPos(Vector2 gridPos)//网格坐标转世界坐标
        {
            // 根据网格坐标计算世界坐标
            float worldX = GridOrigin.x + gridPos.x * GridSize;
            float worldY = GridOrigin.y + gridPos.y * GridSize;
            return new Vector2(worldX, worldY);
        }
    }
}