using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth : Ultra
{
    private bool isCoroutineRunning;
    public float invisTime = 10f;
    private GameObject particles;
    protected override void Start()
    {
        base.Start();
        timeBtw = 40f;
        particles = Resources.Load("smoke", typeof(GameObject)) as GameObject;
        isCoroutineRunning = false;
    }
    public override void Ult()
    {
        base.Ult();
        Instantiate(particles, transform.position, Quaternion.identity);
        Utils.Throw("INVISIBLE", transform.position + new Vector3(0f, 2f, 0f), Utils.Type.RARE);
        if (!isCoroutineRunning)
            StartCoroutine(Invisible());
    }

    IEnumerator Invisible()
    {
        isCoroutineRunning = true;
        tag = "Untagged";
        yield return new WaitForSeconds(invisTime);
        tag = "Player";
        isCoroutineRunning = false;
        yield break;
    }
}
