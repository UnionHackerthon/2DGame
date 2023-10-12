using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoss : Monster
{
    public Animator fireBossAnimator;

    public int AtDamage;

    public int BtDamage;

    public float fireTime;

    void Start()
    {
        this.gameObject.GetComponent<Animator>();

        StartCoroutine(Attack());

        player = GameObject.FindWithTag("Player").transform;

        fireBossAnimator.SetBool("Attack", false);
        fireBossAnimator.SetBool("BAttack", false);
    }


    IEnumerator Attack() 
    {
        yield return new WaitForSeconds(fireTime);

        if (50 > Random.Range(0f, 100f)) {
            fireBossAnimator.SetBool("Attack", true);
            GameObject.Find("Player").GetComponent<Player>().hp -= AtDamage;
        } else {
            fireBossAnimator.SetBool("BAttack", true);
            GameObject.Find("Player").GetComponent<Player>().hp -= BtDamage;
        }
    }

    public void EndAttack() 
    {
        fireBossAnimator.SetBool("Attack", false);
        StartCoroutine(Attack());
    }

    public void EndBAttack() 
    {
        fireBossAnimator.SetBool("BAttack", false);
        StartCoroutine(Attack());
    }
}
