using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) {
            Destroy(this.gameObject);
            transform.GetComponentInParent<Room>().totalmonsterNum--;
        }
    }
}
