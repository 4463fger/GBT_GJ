using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "MapConfig", menuName = "Config/PathConfig")]
    public class PathConfig : ScriptableObject
    {
        public Vector2[] path;
        public bool isHaveObstacle;
        public Vector2[] Obstacle;
    }
}