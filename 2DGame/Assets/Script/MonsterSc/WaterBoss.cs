using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoss : Monster
{
    public Animator fireBossAnimator;

    public int AtDamage;

    public int BtDamage;

    public float fireTime;

    public GameObject clearUi;

    void Start()
    {
        this.gameObject.GetComponent<Animator>();

        StartCoroutine(Attack());

        player = GameObject.FindWithTag("Player").transform;
    }


    private void Update() 
    {
        if (mobstatus.hp <= 0) {
            clearUi.SetActive(true);
            Time.timeScale = 0f;
            UserStatus.completed = true;
            GameObject.Find("BackEndManager").GetComponent<BalanceAI>().SetBalance();
        }
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
