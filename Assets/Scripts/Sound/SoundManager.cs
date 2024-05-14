using System.Linq;
using UnityEngine;

public class SoundManager : SingletonBehaviour<SoundManager>
{
    [SerializeField] private SoundDataSO soundDataSO;

    protected override void Awake()
    {
        base.Awake();

        InitializeSoundSources();
    }

    private void InitializeSoundSources()
    {
        for (int i = 0; i < soundDataSO.clipDataList.Count; i++)
        {
            if (soundDataSO.clipDataList[i].SoundType == SoundType.Music)
            {
                GameObject go = new($"{soundDataSO.clipDataList[i].SoundName}_AudioSource");
                go.transform.parent = transform; go.transform.localPosition = Vector3.zero;

                soundDataSO.clipDataList[i].AudioSource = go.AddComponent<AudioSource>();
                soundDataSO.clipDataList[i].AudioSource.clip = soundDataSO.clipDataList[i].AudioClip;
                soundDataSO.clipDataList[i].AudioSource.playOnAwake = soundDataSO.clipDataList[i].PlayOnAwake;
                soundDataSO.clipDataList[i].AudioSource.loop = soundDataSO.clipDataList[i].Loopable;
            }
        }
    }

    public void Play(SoundName soundName, float volume = 1f)
    {
        ClipData clipData = GetClipData(soundName);

        if(clipData.SoundType == SoundType.Sfx)
        {
            if (gameObject.TryGetComponent(out AudioSource audioSource))
            {
                audioSource.PlayOneShot(clipData.AudioClip, volume); // this Component Only used To Play Sfx 
            }
            else
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.PlayOneShot(clipData.AudioClip, volume);
            }
        }
        else if(clipData.SoundType == SoundType.Music)
        {
            clipData.AudioSource.Play();
        }
    }

    public void PlayOneShotClipAtPosition(SoundName soundName,Vector3 position, float volume = 1f)
    {
        ClipData clipData = GetClipData(soundName);
        AudioSource.PlayClipAtPoint(clipData.AudioClip, position,volume);
    }

    public void PauseSound()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.Pause();
        }
    }

    public void ResumeSound()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.UnPause();
        }
    }

    public void StopAllSounds()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Stop();
        }
    }

    private ClipData GetClipData(SoundName soundName)
    {
        ClipData clipData = soundDataSO.clipDataList.Where(clip => (clip.SoundName == soundName)).FirstOrDefault();

        if (clipData != null)
        {
            return clipData;
        }
        else
        {
            Debug.LogWarning($"No Clip Found {soundName}");
            return null;
        }
    }

}
