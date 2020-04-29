using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : Ultra
{
    private GameObject support, gun;
    protected override void Start()
    {
        base.Start();
        timeBtw = 60f;
        support = Resources.Load("Support", typeof(GameObject)) as GameObject;
        gun = Resources.Load("Shotgun", typeof(GameObject)) as GameObject;
    }

    public override void Ult()
    {
        base.Ult();
        Utils.Throw("SUPPORT", transform.position + new Vector3(0f, 2f, 0f), Utils.Type.RARE);
        Instantiate(support, transform.position + new Vector3(3f, 3f, 0f), Quaternion.identity);
        Instantiate(gun, transform.position + new Vector3(3f, 3f, 0f), Quaternion.identity);
        Instantiate(support, transform.position + new Vector3(-3f, 3f, 0f), Quaternion.identity);
        Instantiate(gun, transform.position + new Vector3(-3f, 3f, 0f), Quaternion.identity);
    }
}
