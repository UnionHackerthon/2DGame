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
        if (hp < 0) {
            clearUi.SetActive(true);
            Time.timeScale = 0f;
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
