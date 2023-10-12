using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBoss : Monster
{
    public Animator fireBossAnimator;

    public float fireTime;

    public int AtDamage;

    void Start()
    {
        this.gameObject.GetComponent<Animator>();

        //player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(Attack());
    }

    private void Update() 
    {
        
        fireBossAnimator.SetBool("Attack", true);
        GameObject.Find("Player").GetComponent<Player>().hp -= AtDamage;
        

        transform.LookAt(player);
    }


    IEnumerator Attack() 
    {
        yield return new WaitForSeconds(fireTime);

        fireBossAnimator.SetBool("Attack", true);
        GameObject.Find("Player").GetComponent<Player>().hp -= AtDamage;
        

    }



    public void EndAttack() 
    {
        fireBossAnimator.SetBool("Attack", false);
        StartCoroutine(Attack());
    }


}
