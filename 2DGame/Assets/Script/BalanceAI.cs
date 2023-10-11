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
            // UserStatus.score += (int)Math.Round((300-UserStatus.score/10) * (Math.Log10(3000 - UserStatus.score)-1)); 3000에 수렴
            UserStatus.score += (500 - (UserStatus.hit * 25) > 0) ? 1000 - (UserStatus.hit * 25) : 0 + 400;
        }
        else
        {
            int updatescore = (UserStatus.roomclear - 10) * 30; // max room=20 기준, 값에 따라 추후 수정. 약 50% 이상 클리어시 점수 증가
            updatescore -= (UserStatus.hit * 7); // 피격 횟수에 따라 최대 140점 감점, 80% 이상 클리어시 대부분 점수 증가
        }
    }
}


