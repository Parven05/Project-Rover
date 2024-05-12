using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDataSO", menuName = "ScriptableObject/SoundData")]
public class SoundDataSO : ScriptableObject
{
    public List<ClipData> clipDataList;

    [System.Serializable]
    public class ClipData
    {
        public string AudioClipName;
        public AudioClip AudioClip;
    }
}
