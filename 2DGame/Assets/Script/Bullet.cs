using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private float deamge;

    public Vector3 target;

    public float speed;

    public void Update() 
    {
        Vector3 dir = target - transform.position;

        this.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }


    public void OnTriggerEnter2D(Collider2D other) {
        // if (other.CompareTag("Player")) {
        //     other.GetComponent<Player>().Hp -= deamge;
        // } else if (other.CompareTag("Monster")) {
        //     other.GetComponent<Monster>().Hp -= deamge;
        // }
        if (other.CompareTag("Monster")) {
            Destroy(this.gameObject);
        }
    }


    // private  IEnumerator Attack()
    // {
    //     aClone = Instantiate(Bullet, this.transform);
    //     bul = aClone.GetComponent<Bullet>();
    //     bul.target = target;
    //     yield return new WaitForSeconds(FireTime);
    // }
}
