using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    Vector3 targetPos = Vector3.zero;
    Tile currentTile = null;

    private void Update()
    {
        if (targetPos != Vector3.zero)
        {
            transform.Translate((targetPos - transform.position)
             .normalized * moveSpeed * Time.deltaTime);

            if ((targetPos - transform.position).magnitude <= 0.3f)
            {
                transform.position = targetPos;
                targetPos = Vector3.zero;
                NextMove();
            }
        }
    }

    public void NextMove()
    {
        var targetTile = TileManager.Instance.GetNextWayPoint(currentTile);
        if (targetTile == null)
        {
            Destroy(gameObject);
            return;
        }
        Move(targetTile);
    }

    /// <summary>
    /// 해당 타일로 이동하는 메소드
    /// </summary>
    /// <param name="tile">해당 타일</param>
    public void Move(Tile tile)
    {
        currentTile = tile;
        targetPos = tile.transform.position;

          modelTrans.LookAt(
            new Vector3(targetPos.x, modelTrans.position.y, targetPos.z)
            );
    }
}
    



