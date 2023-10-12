using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player;
    public GameObject potion;
    public MobStatus mobstatus;

    public int min;

    public int max;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet")) {
            mobstatus.hp -= other.GetComponent<Bullet>().damage;
        }
    }

    public void Balancing()
    {
        mobstatus.hp = (int)Mathf.Round(mobstatus.hp * mobstatus.multiple);
        mobstatus.damage = (int)Mathf.Round(mobstatus.damage * mobstatus.multiple);
        mobstatus.movespeed = (int)Mathf.Round(mobstatus.movespeed * mobstatus.multiple);
    }
    protected void Die()
    {
        transform.GetComponentInParent<Room>().totalmonsterNum--;
        if (6 == Random.Range(min, max))
        {
            GameObject potionCLone = Instantiate(potion);
            potionCLone.transform.position = this.gameObject.transform.position;
        }
        UserStatus.killcount++;
        Destroy(gameObject);
    }
}
