using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private float deamge;

    public float speed;

    public void Move(Vector3 target, Vector3 playerPos) 
    {
        // 총알 방향 설정
        Vector3 dir = target - playerPos;
        dir.Normalize();

        // 총알 방향으로 이동
        Vector3 pos = dir * speed;
        GetComponent<Rigidbody>().velocity = pos;
    }

    public void OnTriggerEnter(Collider other) {    

        if (other.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Monster")) {
            other.transform.GetComponentInParent<Room>().totalmonsterNum--;
            Destroy(other.gameObject);
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
