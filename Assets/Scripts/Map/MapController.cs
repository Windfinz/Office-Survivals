using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    //Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    Vector3 playerLastPosition;


    [Header("Optimization")]
    public List<GameObject> spawnedChunk;
    GameObject lastestChunk;
    public float maxOpDist;
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;

    void Start()
    {
       playerLastPosition = player.transform.position;
    }

    void Update()
    {
        ChunkerChecker();
        ChunkOptimizer();
    }

    void ChunkerChecker()
    {
        if (!currentChunk)
        {
            return;
        }
        #region
        //if (pm.moveDir.x > 0 && pm.moveDir.y == 0) // right
        //{
        //    if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
        //    {
        //        noTerrainPosition = currentChunk.transform.Find("Right").position;
        //        SpawnChunk();
        //    }
        //}
        //else if (pm.moveDir.x < 0 && pm.moveDir.y == 0) // left
        //{
        //    if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
        //    {
        //        noTerrainPosition = currentChunk.transform.Find("Left").position;
        //        SpawnChunk();
        //    }
        //}
        //else if (pm.moveDir.x == 0 && pm.moveDir.y < 0) // down
        //{
        //    if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
        //    {
        //        noTerrainPosition = currentChunk.transform.Find("Down").position;
        //        SpawnChunk();
        //        noTerrainPosition = currentChunk.transform.Find("LeftDown").position;
        //        SpawnChunk();
        //        noTerrainPosition = currentChunk.transform.Find("RightDown").position;
        //        SpawnChunk();
        //    }

        //}
        //else if (pm.moveDir.x == 0 && pm.moveDir.y > 0) // up
        //{
        //    if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
        //    {
        //        noTerrainPosition = currentChunk.transform.Find("Up").position;
        //        SpawnChunk();
        //        noTerrainPosition = currentChunk.transform.Find("RightUp").position;
        //        SpawnChunk();
        //        noTerrainPosition = currentChunk.transform.Find("LeftUp").position;
        //        SpawnChunk();
        //    }
        //}
        //else if (pm.moveDir.x > 0 && pm.moveDir.y > 0) // right up
        //{
        //    if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkerRadius, terrainMask))
        //    {
        //        noTerrainPosition = currentChunk.transform.Find("RightUp").position;
        //        SpawnChunk();   
        //    }
        //}
        //else if (pm.moveDir.x < 0 && pm.moveDir.y > 0) // left up
        //{
        //    if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftUp").position, checkerRadius, terrainMask))
        //    {
        //        noTerrainPosition = currentChunk.transform.Find("LeftUp").position;
        //        SpawnChunk();
        //    }
        //}
        //else if (pm.moveDir.x > 0 && pm.moveDir.y < 0) // right down
        //{
        //    if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightDown").position, checkerRadius, terrainMask))
        //    {
        //        noTerrainPosition = currentChunk.transform.Find("RightDown").position;
        //        SpawnChunk();
        //    }
        //}
        //else if (pm.moveDir.x > 0 && pm.moveDir.y < 0) // left down
        //{
        //    if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftDown").position, checkerRadius, terrainMask))
        //    {
        //        noTerrainPosition = currentChunk.transform.Find("LeftDown").position;
        //        SpawnChunk();
        //    }
        //}
        #endregion
        Vector3 moveDir = player.transform.position - playerLastPosition;
        playerLastPosition = player.transform.position;

        string directionName = GetDirectionName(moveDir);
        #region
        //if (!Physics2D.OverlapCircle(currentChunk.transform.Find(directionName).position, checkerRadius, terrainMask))
        //{
        //    SpawnChunk(currentChunk.transform.Find(directionName).position);

        //    if (directionName.Contains("Up") && directionName.Contains("Right"))
        //    {
        //        if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
        //        {
        //            SpawnChunk(currentChunk.transform.Find("Up").position);
        //        }
        //        if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
        //        {
        //            SpawnChunk(currentChunk.transform.Find("Right").position);
        //        }

        //    }
        //    else if (directionName.Contains("Up") && directionName.Contains("Left"))
        //    {
        //        if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
        //        {
        //            SpawnChunk(currentChunk.transform.Find("Up").position);
        //        }
        //        if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
        //        {
        //            SpawnChunk(currentChunk.transform.Find("Left").position);
        //        }
        //    }
        //    else if (directionName.Contains("Down") && directionName.Contains("Right"))
        //    {
        //        if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
        //        {
        //            SpawnChunk(currentChunk.transform.Find("Down").position);
        //        }
        //        if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
        //        {
        //            SpawnChunk(currentChunk.transform.Find("Right").position);
        //        }
        //    }
        //    else if (directionName.Contains("Down") && directionName.Contains("Left"))
        //    {
        //        if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
        //        {
        //            SpawnChunk(currentChunk.transform.Find("Down").position);
        //        }
        //        if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
        //        {
        //            SpawnChunk(currentChunk.transform.Find("Left").position);
        //        }
        //    }
        //}
        #endregion
        CheckAndSpawnChunk(directionName);

        if (directionName.Contains("Up"))
        {
            CheckAndSpawnChunk("Up");
        }
        if (directionName.Contains("Down"))
        {
            CheckAndSpawnChunk("Down");
        }
        if (directionName.Contains("Right"))
        {
            CheckAndSpawnChunk("Right");
        }
        if (directionName.Contains("Left"))
        {
            CheckAndSpawnChunk("Left");
        }

    }
    void CheckAndSpawnChunk(string direction)
    {
        if(!Physics2D.OverlapCircle(currentChunk.transform.Find(direction).position, checkerRadius, terrainMask))
        {
            SpawnChunk(currentChunk.transform.Find(direction).position);
        }
    }

    string GetDirectionName(Vector3 direction)
    {
        direction = direction.normalized;

        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.y > 0.5f)
            {
                return direction.x > 0 ? "RightUp" : "LeftUp";
            }
            else if(direction.y < -0.5f)
            {
                return direction.x > 0 ? "RightDown" : "LeftDown";
            }
            else
            {
                return direction.x > 0 ? "Right" : "Left";
            }
        }
        else
        {
            if (direction.x > 0.5f)
            {
                return direction.y > 0 ? "RightUp" : "RightDown";
            }
            else if (direction.x < -0.5f)
            {
                return direction.y > 0 ? "LeftUp" : "LeftDown";
            }
            else
            {
                return direction.y > 0 ?  "Up" : "Down";
            }
        }
    }

    void SpawnChunk(Vector3 spawnPosition)
    {
        int rand = Random.Range(0, terrainChunks.Count);
        lastestChunk =Instantiate(terrainChunks[rand], spawnPosition, Quaternion.identity);
        spawnedChunk.Add(lastestChunk);
    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;
        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunk)
        {
            opDist = Vector3.Distance(player.transform .position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }

    }
}
