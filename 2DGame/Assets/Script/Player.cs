using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Singleton<Player>
{
    public static Player self;
    public float speed = 5.0f;

    public float maxhp = 100f;
    public float hp = 100f;

    public float horizontal;
    public float vertical;

    public bool isMoveStatus = true;

    public Camera mainCamera;

    Renderer chRenderer;

    public Slider hpSlider;

    public float a;

    public bool b;

    public GameObject bulletPrefab;

    void Start()
    {
        if (self == null)
            self = this;

        chRenderer = this.gameObject.GetComponent<Renderer>();
        b = true;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) {
            GameObject bulletClone = Instantiate(bulletPrefab);
            bulletClone.transform.position = this.gameObject.transform.position;
            bulletClone.GetComponent<Bullet>().Move(mainCamera.ScreenToWorldPoint(Input.mousePosition), this.transform.position);
        }

        if (hp <= 0) {
            Time.timeScale = 0f;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Door" && GameObject.Find("RoomController").GetComponent<RoomController>().currRoom.totalmonsterNum==0)
        {
            FadeInOut.Instance.setFade(true, 1.35f);

            GameObject nextRoom = collision.gameObject.transform.parent.GetComponent<Door>().nextRoom;
            Door nextDoor = collision.gameObject.transform.parent.GetComponent<Door>().SideDoor;

            // 진행 방향을 파악 후 캐릭터 위치 지정
            Vector3 currPos = new Vector3(nextDoor.transform.position.x, 0.5f, nextDoor.transform.position.z) + (nextDoor.transform.localRotation * (Vector3.forward * 3));

            Player.Instance.transform.position = currPos;

            for (int i = 0; i < RoomController.Instance.loadedRooms.Count; i++) {
                if (nextRoom.GetComponent<Room>().parent_Position == RoomController.Instance.loadedRooms[i].parent_Position) {
                    RoomController.Instance.loadedRooms[i].childRooms.gameObject.SetActive(true);
                } else {
                    RoomController.Instance.loadedRooms[i].childRooms.gameObject.SetActive(false);
                }
            }

            FadeInOut.Instance.setFade(false, 0.15f);
        }

        if (collision.CompareTag("Potion") && maxhp > hp) {
            hp += collision.GetComponent<HpPotion>().value;
            if(hp > maxhp) {
                hp = maxhp;
            }
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Monster") && b) {
            StartCoroutine(ColorChange());
            UserStatus.hit++;
            hp -= 10;
            b = false;
            hpSlider.value = hp / 100;
        }
    }

    IEnumerator ColorChange() 
    {
        for (int i = 0; i < 3; i++) {
            chRenderer.material.color = Color.red;
            yield return new WaitForSeconds((float)a/3);
            chRenderer.material.color = Color.black;
        }
        b = true;
    }
}
