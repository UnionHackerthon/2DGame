using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : Monster
{
    public Animator fireMonsterAnimator;

    void Start()
    {
        this.gameObject.GetComponent<Animator>();

        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update() 
    {
        transform.LookAt(player);

        transform.position = Vector3.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);
    }
}
