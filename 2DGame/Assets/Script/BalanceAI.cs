using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceAI : MonoBehaviour
{
    public bool gamelock = false;
    public void SetBalance()
    {
        gamelock = true;
        int updatescore = 0;
        if (UserStatus.completed == true)
        {
            updatescore += (500 - (UserStatus.hit * 25) > 0) ? 1000 - (UserStatus.hit * 25) : 0 + 400; // Ŭ����� 400��, ��Ʈ Ƚ���� �ִ� 500 -> 400~900
        }
        else
        {
            updatescore += -200; // Ŭ���� ���н� 200�� ����
        }
        updatescore = UserStatus.killcount * 10; // ���� ���̸� 10�� �߰�
        updatescore -= (UserStatus.hit * 7); // �ǰݽ� 5�� ����

        UserStatus.score += updatescore;
        UserStatus.hit = 0;
        UserStatus.killcount = 0;
        UserStatus.completed = false;

        Player p = GameObject.FindWithTag("Player").GetComponent<Player>();
        p.hp = p.maxhp;
        GameObject.Find("BackEndManager").GetComponent<InGameRankMain>().scriptableObject.score = UserStatus.score;
        GameObject.Find("BackEndManager").GetComponent<InGameRankMain>().PostScore();
    }
}


