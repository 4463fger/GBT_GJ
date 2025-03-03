using JKFrame;
using System.Collections.Generic;
using UnityEngine;
public class GridManager:SingletonMono<GridManager> 
{
    public Vector2 InitPos;

    public float GridLength=16;
    public MapConfig Config;

    public void CreateMap(MapConfig mapConfig)
    {
        float x=InitPos.x;
        float y=InitPos.y;
        for(int i=0;i<mapConfig.Length;i++) 
        {
            y = InitPos.y;
            for(int j=0;j<mapConfig.Width;j++) 
            {
                
                Vector2 currentPos = new Vector2(i, j);
                GameObject grid;
                if(mapConfig.Path.Contains(currentPos))
                {
                    grid = Instantiate(mapConfig.pathGrid, new Vector3(x, y, 0), Quaternion.identity);
                }
                else
                {
                    grid = Instantiate(mapConfig.nomralGrid, new Vector3(x, y, 0), Quaternion.identity);
                }
                UpdateGridPos(grid.GetComponent<GridBase>(), i, j);
                y += GridLength;
            }
            x += GridLength;
        }
    }

    private GameObject UpdatePathGrid(MapConfig mapConfig,Vector2 pos)
    {
        int index=mapConfig.Path.IndexOf(pos);
        GameObject Grid = Instantiate(mapConfig.pathGrid, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        Vector2 lastGrid = mapConfig.Path[index-1];
        Vector2 nextGrid = mapConfig.Path[index+1];
        return Grid;
    }

    private void UpdateGridPos(GridBase Grid,int x,int y)
    {
        Grid.gridPosition = new Vector2(x,y);
    }

    protected override void Awake()
    {
        InitPos=new Vector2(GridLength/2,GridLength/2);
        CreateMap(Config);
    }
}