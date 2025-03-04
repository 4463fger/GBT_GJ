using JKFrame;
using System.Collections.Generic;
using UnityEngine;
public class GridManager:SingletonMono<GridManager> 
{
    public Vector2 InitPos;

    public float GridLength;


    public void CreateMap(MapConfig mapConfig)
    {
        for(int i = 0; i < GridLength; i++) 
        {
            for (int j = 0; j < GridLength; j++) 
            {

            }
        }
    }

    public List<Vector2> GetPath(MapConfig mapConfig)
    {
        List<Vector2> path= new List<Vector2>();
        Vector2 startPos = mapConfig.startPos;
        path.Add(startPos);
        //找下一个点

        Vector2 endPos = mapConfig.endPos;




        path.Add(endPos);
        return path;
    }
    private void UpdateGridPos(GridBase Grid,int x,int y)
    {
        Grid.gridPosition = new Vector2(x,y);
    }
}