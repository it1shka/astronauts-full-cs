using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]public class Info
{
    public float r, g, b, a;
    public int mod;
    public bool[] mods;
    public Info(float r,float g, float b,float a,int mod, bool[] mods)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
        this.mod = mod;
        this.mods = mods;
    }
}

public static class InfoHandler {

    private static string defaultPath = "/info.binary";
    public static void SetInfo(Info info)
    {
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + defaultPath;
        var stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, info);
        stream.Close();
    }

    public static Info GetInfo()
    {
        var path = Application.persistentDataPath + defaultPath;
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            var info = formatter.Deserialize(stream) as Info;
            stream.Close();
            return info;
        }
        else return null;
    }
}