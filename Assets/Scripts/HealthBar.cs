using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class HealthBar : MonoBehaviour
{
    


    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    

    public void CmdSetHealth(int health)
    {
        slider.value = health;
    }

}