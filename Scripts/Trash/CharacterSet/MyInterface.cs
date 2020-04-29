using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MyInterface : MonoBehaviour
{
    private Info info;

    public RawImage playerImage;
    public Slider r, g, b, a;
    public TextMeshProUGUI buyOrSet, price, modName, description;
    public GameObject buyOrSetButton;
    public ModeInfo[] modeInfos;
    private int currentMod;

    private bool awaked;
    void Awake()
    {
        awaked = false;
        info = InfoHandler.GetInfo();
        if (info == null) {
            var mods = new bool[modeInfos.Length];
            mods[0] = true;
            info = new Info(1f, 1f, 1f, 1f, 0, mods);
            InfoHandler.SetInfo(info);
        }
        if(info.mods.Length != modeInfos.Length)
        {
            var newmods = new bool[modeInfos.Length];
            for (var i = 0; i < info.mods.Length && i < modeInfos.Length; i++)
                newmods[i] = info.mods[i];
            info.mods = newmods;
            InfoHandler.SetInfo(info);
        }
        currentMod = info.mod;

        r.value = info.r;
        g.value = info.g;
        b.value = info.b;
        a.value = info.a;

        awaked = true;
        UpdateMod();
        UpdateColor();
    }

    public void UpdateColor()
    {
        if (!awaked) return;
        info.r = r.value;
        info.g = g.value;
        info.b = b.value;
        info.a = a.value;
        
        playerImage.color = new Color(
            info.r, info.g, info.b, info.a
        );
    }

    public void UpdateMod()
    {
        var current = modeInfos[currentMod];
        buyOrSetButton.SetActive(true);
        if (info.mods[currentMod])//bought
        {
            buyOrSet.text = "SET";
            price.text = "";
            if (info.mod == currentMod) buyOrSetButton.SetActive(false);
        }
        else//not bought
        {
            buyOrSet.text = "BUY";
            price.text = $"{current.price.ToString()} kills";
        }
        modName.text = current.modeName;
        description.text = current.description;
    }

    public void SetBuy()
    {
        var current = modeInfos[currentMod];
        if (info.mods[currentMod])//bought
        {
            info.mod = currentMod;
        }
        else//not bought
        {
            var kills = PlayerPrefs.GetInt("kills");
            if(kills >= current.price)
            {
                info.mods[currentMod] = true;
                PlayerPrefs.SetInt("kills", kills - current.price);
            }
        }
        UpdateMod();
    }

    public void NextMod()
    {
        currentMod++;
        if (currentMod >= modeInfos.Length) currentMod = 0;
        UpdateMod();
    }
    public void PreviousMod()
    {
        currentMod--;
        if (currentMod < 0) currentMod = modeInfos.Length - 1;
        UpdateMod();
    }

    public void SetChagnes()
    {
        InfoHandler.SetInfo(info);
    }
}

[System.Serializable]public class ModeInfo {
    public string modeName, description;
    public int price;
}
