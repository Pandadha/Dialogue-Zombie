using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text healthtext;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        healthtext.text = slider.value.ToString() + "/120";
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        healthtext.text = slider.value.ToString() + "/120";
    }

}
