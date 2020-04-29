using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultUltra : Ultra {
    private Movement movement;
    private GameObject particles;
    protected override void Start()
    {
        base.Start();
        timeBtw = 20f;
        movement = GetComponent<Movement>();
        particles = Resources.Load("fuels", typeof(GameObject)) as GameObject;
    }
    public override void Ult()
    {
        base.Ult();
        movement.currentJetpack = movement.maxJetpack;
        Instantiate(particles, transform.position, Quaternion.identity);
        Utils.Throw("JETPACK FILLED", transform.position + new Vector3(0f, 2f, 0f), Utils.Type.RARE);
    }
}
