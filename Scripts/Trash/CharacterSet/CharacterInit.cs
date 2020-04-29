using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInit : MonoBehaviour
{
    private Info info;
    private int chosenMod;
    private float r, g, b, a;
    private SpriteRenderer spriteRenderer;
    private Ultra ultraScript;

    private void Awake()
    {
        info = InfoHandler.GetInfo();
        if(info == null)
        {
            r = 1f; g = 1f;
            b = 1f; a = 1f;
            chosenMod = 0;
        }
        else
        {
            r = info.r;
            g = info.g;
            b = info.b;
            a = info.a;
            chosenMod = info.mod;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(r, g, b, a);
        switch (chosenMod) {
            case 0:
                ultraScript = gameObject.AddComponent<DefaultUltra>();
                break;
            case 1:
                ultraScript = gameObject.AddComponent<FirstAidKit>();
                break;
            case 2:
                ultraScript = gameObject.AddComponent<Impulse>();
                break;
            case 3:
                ultraScript = gameObject.AddComponent<turretSpawner>();
                break;
            case 4:
                ultraScript = gameObject.AddComponent<Stealth>();
                break;
            case 5:
                ultraScript = gameObject.AddComponent<Support>();
                break;

        }

        ultraScript.button = GameObject.Find("Ultra");
    }
}
