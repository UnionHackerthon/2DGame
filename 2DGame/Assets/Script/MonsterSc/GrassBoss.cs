using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBoss : Monster
{
    public Animator fireBossAnimator;

    public float fireTime;

    public int Atdamage;

    void Start()
    {
        this.gameObject.GetComponent<Animator>();

        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update() 
    {
        if (3f > Vector3.Distance(player.transform.position, this.transform.position)) {
            fireBossAnimator.SetBool("Attack", true);
            GameObject.Find("Player").GetComponent<Player>().hp -= damage;
        }
    }

    public void EndAttack() 
    {
        fireBossAnimator.SetBool("Attack", false);
    }
}
