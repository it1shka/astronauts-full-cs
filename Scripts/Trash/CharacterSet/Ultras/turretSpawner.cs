using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretSpawner : Ultra
{
    private GameObject turret;
    protected override void Start()
    {
        base.Start();
        turret = Resources.Load("turret", typeof(GameObject)) as GameObject;
    }
    public override void Ult()
    {
        base.Ult();
        Instantiate(turret, transform.position + new Vector3(0f, 3f, 0f), transform.rotation);
    }
}
