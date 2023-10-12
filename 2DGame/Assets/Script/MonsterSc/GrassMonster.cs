using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMonster : Monster
{

    public Animator grassMonsterAnimator;

    void Start()
    {
        this.gameObject.GetComponent<Animator>();

        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);
    }
}
