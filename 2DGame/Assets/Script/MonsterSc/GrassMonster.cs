using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMonster : Monster
{

    public Animator grassMonsterAnimator;

    void Start()
    {
        this.gameObject.GetComponent<Animator>();

        
    }

    private void Update() 
    {

        player = GameObject.FindWithTag("Player").transform;

        transform.position = Vector3.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);

        if (hp <= 0)
        {
            Die();
        }
    }
}
