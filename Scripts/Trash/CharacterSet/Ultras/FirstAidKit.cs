using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : Ultra
{
    public float heal = 25f;
    private HealthModule healthModule;
    private GameObject particles;
    protected override void Start()
    {
        base.Start();
        healthModule = GetComponent<HealthModule>();
        particles = Resources.Load("greenCrosses", typeof(GameObject) ) as GameObject;
    }
    public override void Ult()
    {
        base.Ult();
        healthModule.TakeDamage(-heal);
        Instantiate(particles, transform.position, Quaternion.identity);
        Utils.Throw($"+{heal} HP", transform.position + new Vector3(0f, 2f, 0f), Utils.Type.RARE);
    }
}