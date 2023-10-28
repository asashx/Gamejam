using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyObstacle : MonoBehaviour
{
    public float offsetX;
    public float offsetY;

    private Tilemap obstacle;

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    private Vector3 pos5;
    private Vector3 pos6;
    private Vector3 pos7;
    private Vector3 pos8;

    private void Awake()
    {
        obstacle = GetComponent<Tilemap>();
    }

    public void DestroyTile(Vector3 hitPos)
    {
        pos1 = new Vector3(hitPos.x + offsetX, hitPos.y + offsetY, hitPos.z);
        pos2 = new Vector3(hitPos.x + offsetX, hitPos.y - offsetY, hitPos.z);
        pos3 = new Vector3(hitPos.x - offsetX, hitPos.y + offsetY, hitPos.z);
        pos4 = new Vector3(hitPos.x - offsetX, hitPos.y - offsetY, hitPos.z);
        pos5 = new Vector3(hitPos.x + offsetX, hitPos.y, hitPos.z);
        pos6 = new Vector3(hitPos.x - offsetX, hitPos.y, hitPos.z);
        pos7 = new Vector3(hitPos.x, hitPos.y + offsetY, hitPos.z);
        pos8 = new Vector3(hitPos.x, hitPos.y - offsetY, hitPos.z);

        if (obstacle.HasTile(obstacle.WorldToCell(pos1)))
        {
            obstacle.SetTile(obstacle.WorldToCell(pos1), null);
        }
        if (obstacle.HasTile(obstacle.WorldToCell(pos2)))
        {
            obstacle.SetTile(obstacle.WorldToCell(pos2), null);
        }
        if (obstacle.HasTile(obstacle.WorldToCell(pos3)))
        {
            obstacle.SetTile(obstacle.WorldToCell(pos3), null);
        }
        if (obstacle.HasTile(obstacle.WorldToCell(pos4)))
        {
            obstacle.SetTile(obstacle.WorldToCell(pos4), null);
        }
        if (obstacle.HasTile(obstacle.WorldToCell(pos5)))
        {
            obstacle.SetTile(obstacle.WorldToCell(pos5), null);
        }
        if (obstacle.HasTile(obstacle.WorldToCell(pos6)))
        {
            obstacle.SetTile(obstacle.WorldToCell(pos6), null);
        }
        if (obstacle.HasTile(obstacle.WorldToCell(pos7)))
        {
            obstacle.SetTile(obstacle.WorldToCell(pos7), null);
        }
        if (obstacle.HasTile(obstacle.WorldToCell(pos8)))
        {
            obstacle.SetTile(obstacle.WorldToCell(pos8), null);
        }
    }
}
