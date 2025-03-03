using JKFrame;
using UnityEngine;
public class CameraController : SingletonMono<CameraController>
{
    public void SetCameraSize(float Height,float Width)
    {

    }
    public void SetCameraPos(Vector2 pos)
    {
        transform.position = new Vector3(pos.x, pos.y, -10);
    }
}
