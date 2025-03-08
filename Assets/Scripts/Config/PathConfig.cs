using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig", menuName = "Config/PathConfig")]
public class PathConfig : ScriptableObject
{
    public Vector2[] path;
    public bool isHaveObstacle;
    public Vector2[] Obstacle;
}