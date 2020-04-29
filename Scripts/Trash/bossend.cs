using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossend : MonoBehaviour
{
    public GameObject boss, escape;
    private void Update()
    {
        if (!boss)
        {
            escape.SetActive(true);
            Destroy(this);
        }
    }
}
