using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBoss : Monster
{
    public Animator fireBossAnimator;

    public float fireTime;

    public int Atdamage;

    public GameObject clearUi;

    void Start()
    {
        this.gameObject.GetComponent<Animator>();

        player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(Attack());
    }

    private void Update() 
    {
        if (mobstatus.hp <= 0) {
            GameObject.Find("GameUI").transform.Find("Clear").gameObject.SetActive(true);
            UserStatus.completed = true;
            GameObject.Find("BackEndManager").GetComponent<BalanceAI>().SetBalance();
            Die();
        }
    }

    IEnumerator Attack() 
    {
        yield return new WaitForSeconds(fireTime);

        fireBossAnimator.SetBool("Attack", true);
        GameObject.Find("Player").GetComponent<Player>().hp -= Atdamage;
        

    }

    public void EndAttack() 
    {
        fireBossAnimator.SetBool("Attack", false);
        StartCoroutine(Attack());
    }
}
