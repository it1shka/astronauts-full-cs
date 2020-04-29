using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
public abstract class Ultra : MonoBehaviour
{
    public float timeBtw = 30f;
    public GameObject button;
    protected float currentTime;
    protected virtual void Start()
    {
        currentTime = 0f;
    }

    protected virtual void Update()
    {
        button?.SetActive(currentTime <= 0f);
        currentTime -= Time.deltaTime;
        if (CnInputManager.GetButtonDown("Ultra") && currentTime <= 0f)
            Ult();

    }

    public virtual void Ult()
    {
        currentTime = timeBtw;
    }
}
