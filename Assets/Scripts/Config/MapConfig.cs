using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MapConfig",menuName ="Config/MapConfig")]
public class MapConfig : ScriptableObject
{
    [Header("地图外观")]
    public GameObject placedableGrid;
    public GameObject boundaryGrid;
    public GameObject pathGrid;
    public GameObject destinationGrid;
    public GameObject nomralGrid;
    [Header("关卡设置")]
    public int waveCount;
    public int Length;
    public int Width;
    [Range (0, 1f)] public float normalGridProbability;
    [Range (0, 1f)] public float destinationGridProbability;
    public List<MapTile> mapTileList;
    public List<Vector2> Path;
    public Vector2 startPos;
    public Vector2 endPos;
}
[Serializable]
public class MapTile
{
    public string tileName;
    public Sprite spriteRenderer;
}