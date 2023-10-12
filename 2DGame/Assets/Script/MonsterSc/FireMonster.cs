using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : Monster
{
    public Animator fireMonsterAnimator;

    void Start()
    {
        mobstatus = GetComponent<MobStatus>();
        this.gameObject.GetComponent<Animator>();
        Balancing();
    }

    private void Update() 
    {
        player = GameObject.FindWithTag("Player").transform;

        transform.position = Vector3.MoveTowards(transform.position, player.position, mobstatus.movespeed * Time.deltaTime);

        if (mobstatus.hp <= 0)
        {
            Die();
        }
    }
}
