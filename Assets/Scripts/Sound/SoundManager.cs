using System.Linq;
using UnityEngine;

public class SoundManager : SingletonBehaviour<SoundManager>
{

    [SerializeField] private SoundDataSO soundDataSO;

    public void PlayClipAtPosition(string clipName,Vector3 position, float volume = 1f)
    {
        AudioClip clip = GetClipFromName(clipName);
        AudioSource.PlayClipAtPoint(clip, position,volume);
    }

    private AudioClip GetClipFromName(string name)
    {
        var soundData = soundDataSO.clipDataList.Where(clip => (clip.AudioClipName == name)).FirstOrDefault();

        if (soundData != null)
        {
            return soundData.AudioClip;
        }
        else
        {
            Debug.LogWarning($"No Clip Found {name}");
            return null;
        }
        
    }

    public void Stop(string name)
    {

    }

}
