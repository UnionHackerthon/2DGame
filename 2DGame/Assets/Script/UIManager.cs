using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider;

    private void Update() 
    {
        slider.value = GameObject.Find("Player").GetComponent<Player>().hp / 100;
    }
}
