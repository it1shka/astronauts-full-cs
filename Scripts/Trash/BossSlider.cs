using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossSlider : MonoBehaviour
{
    public Slider slider;
    public HealthModule health;
    public GameObject text;
    public void Update()
    {
        slider.value = health.health / health.maxHealth;
        if(health.health <= 0f)
        {
            Destroy(slider.gameObject);
            text.SetActive(true);
            Destroy(this);
        }
    }
}
