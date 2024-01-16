using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int[] skillLevels = null;
    public float mainmusicvolume = 1;
    public float specialfx = 1;
    public float lvl1MainVolume;
    public float lvl1FxVolume;
    public bool lvl2;
    public bool lvl3;
    public bool lvl4;
    public bool lvl5;
}