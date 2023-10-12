using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MobStatus
{
    public Transform player;
    public GameObject potion;

    public int min;

    public int max;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet")) {
            hp -= other.GetComponent<Bullet>().damage;
        }
    }
    protected void Die()
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
