using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MobStatus
{
    public Transform player;
    public GameObject potion;

    public int min;

    public int max;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        transform.LookAt(player);

        transform.position = Vector3.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);
        
    }

    void Die()
    {
        transform.GetComponentInParent<Room>().totalmonsterNum--;
        if (6 == Random.Range(min, max))
        {
            GameObject potionCLone = Instantiate(potion);
            potionCLone.transform.position = this.gameObject.transform.position;
        }
        Destroy(gameObject);
    }
}
