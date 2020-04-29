using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform firePoint;
    public float timeBtwShots = .1f;
    private float currentTime;
    public GameObject bullet;
    public LayerMask layerMask;
    public float checkDist = 30f;
    public Healthbar bar;
    private HealthModule module;
    void Start()
    {
        currentTime = 0f;
        module = GetComponent<HealthModule>();
    }

    void Update()
    {
        bar.value = module.health / module.maxHealth;
        currentTime -= Time.deltaTime;
        var physRay = Physics2D.Raycast(firePoint.position, firePoint.right, checkDist, layerMask);
        var ray = physRay && physRay.transform.tag == "Enemy";
        if (ray && currentTime <= 0f) { 
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            currentTime = timeBtwShots;
        }
    }
}
