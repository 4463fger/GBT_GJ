using UnityEngine;

[CreateAssetMenu(fileName ="MapConfig",menuName ="Config/MapConfig")]
public class MapConfig : ScriptableObject
{
    [Header("��ͼ���")]
    public GameObject placedableGrid;
    public GameObject boundaryGrid;
    public GameObject pathGrid;
    public GameObject destinationGrid;
    public GameObject nomralGrid;
    [Header("�ؿ�����")]
    public int waveCount;
    public int Length;
    public int Width;
    [Range (0, 1f)] public float normalGridProbability;
    [Range (0, 1f)] public float destinationGridProbability;
    public Vector2 startPos;
    public Vector2 endPos;
}
