using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum eTileState
    {
        None, /// 설치 불가 지역(벽)
        SpawnPoint, /// 적이 생성 되는 지점
        EndPoint, /// 적이 도달할 경우 넥서스의 체력이 깎이는 지점
        WayPoint, /// 꺾이는 지점
        Way, /// 지점과 지점 사이 길목
        Buildable, /// 설치 가능한 지역
        Tower, ///타워가 있는 지역
    }

    public eTileState state = eTileState.None;
    public Vector2 coordinate;

    public Renderer modelRenderer;

    public void SetState(eTileState targetState)
    {
        state = targetState;
        RefreshTile();
    }

    private void RefreshTile()
    {
        switch(state)
        {
            case eTileState.SpawnPoint:
                modelRenderer.material.color = Color.blue;
                TileManager.Instance.spawnPoint = this;
                break;

            case eTileState.EndPoint:
                modelRenderer.material.color = Color.red;
                TileManager.Instance.endPoint = this;
                break;

            case eTileState.WayPoint:
                modelRenderer.material.color = Color.cyan;
                TileManager.Instance.wayPoints.Add(this);
                break;

            case eTileState.Way:
                modelRenderer.material.color = new Color32(102, 51, 0, 255);//갈색
                break;
        }
    }
}
