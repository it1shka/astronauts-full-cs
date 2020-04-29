using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : Ultra
{
    public float radius = 100f;
    public float damage = .5f;
    public float force = 75f;
    protected override void Start()
    {
        base.Start();
        timeBtw = 10f;
    }
    public override void Ult()
    {
        base.Ult();
        var enemies = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(var elem in enemies){
            if (elem.tag != "Enemy") continue;
            var scr = elem.GetComponent<HealthModule>();
            scr.TakeDamage(damage);
            var rb = elem.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
        Utils.Throw("IMPULSE", transform.position + new Vector3(0f, 2f, 0f), Utils.Type.RARE);
    }
}
