using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    Transform player;
    

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
    }

}
