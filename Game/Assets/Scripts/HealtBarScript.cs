using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarScript : MonoBehaviour
{
    public int maxHealth;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void CreateHealtBar(int maxHealth)
    {
        this.maxHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);
    }


    public void setHealth(int health){
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
