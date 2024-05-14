using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDataSO", menuName = "ScriptableObject/SoundData")]
public class SoundDataSO : ScriptableObject
{
    public List<ClipData> clipDataList;
}

[System.Serializable]
public class ClipData
{
    public SoundName SoundName;
    public SoundType SoundType;
    public bool Loopable;
    public bool PlayOnAwake;
    public AudioClip AudioClip;
    [HideInInspector]
    public AudioSource AudioSource;
}

public enum SoundName
{
    PickEffect,
    Stereo_Surgion
    //More Names
}

public enum SoundType
{
    Sfx,
    Music
}
