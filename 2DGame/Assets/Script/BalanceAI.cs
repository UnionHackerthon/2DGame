using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceAI : MonoBehaviour
{
    void SetBalance()
    {
        if (UserStatus.completed == true)
        {
            // UserStatus.score += (int)Math.Round((300-UserStatus.score/10) * (Math.Log10(3000 - UserStatus.score)-1)); 3000�� ����
            UserStatus.score += (500 - (UserStatus.hit * 25) > 0) ? 1000 - (UserStatus.hit * 25) : 0 + 400;
        }
        else
        {
            int updatescore = (UserStatus.roomclear - 10) * 30; // max room=20 ����, ���� ���� ���� ����. �� 50% �̻� Ŭ����� ���� ����
            updatescore -= (UserStatus.hit * 7); // �ǰ� Ƚ���� ���� �ִ� 140�� ����, 80% �̻� Ŭ����� ��κ� ���� ����
        }
    }
}


