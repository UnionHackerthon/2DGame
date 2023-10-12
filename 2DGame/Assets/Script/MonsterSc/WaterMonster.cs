using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonster : Monster
{
    public Animator waterMonsterAnimator;

    void Start()
    {
        this.gameObject.GetComponent<Animator>();
    }

    private void Update() 
    {
        player = GameObject.FindWithTag("Player").transform;

        transform.position = Vector3.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);
    }
}
