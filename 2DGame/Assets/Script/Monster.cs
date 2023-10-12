using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MobStatus
{
    public Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        transform.LookAt(player);

        transform.position = Vector3.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);
        
    }


}
