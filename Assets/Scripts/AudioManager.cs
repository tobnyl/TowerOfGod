using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSourcePrefab;

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get { return _instance; }
    }

    private List<AudioClip> audioClipsQueue; 

    void Awake()
    {
        audioClipsQueue = new List<AudioClip>();

        if (_instance == null)
        {
            _instance = GetComponent<AudioManager>();
        }
    }

    //void LateUpdate()
    //{
    //    foreach (var audioClip in audioClipsQueue)
    //    {
    //        Play(audioClip, 1, 1, 1, 1);
    //    }

    //    audioClipsQueue.Clear();
    //}

    //public void AddAudioClipToQueue(AudioClip clip, float minVol, float maxVol)
    //{
    //    if (!audioClipsQueue.Contains(clip))
    //    {
    //        audioClipsQueue.Add(clip);
    //    }

        
    //}

    public void Play(AudioClip clip, float minVol = 1.0f, float maxVol = 1.0f, float minPitch = 1.0f, float maxPitch = 1.0f)
    {
        AudioSource audioSource = Instantiate(AudioSourcePrefab, transform.position, transform.rotation) as AudioSource;
        audioSource.transform.parent = this.transform;

        // TODO: add audiomixergroup to audiosource...

        if (minPitch != 1.0f || maxPitch != 1.0f)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
        }

        if (minVol != 1.0f || maxVol != 1.0f)
        {
            audioSource.volume = Random.Range(minVol, maxVol);
        }

        AudioSourceExtended audioSourceExtended = audioSource.GetComponent<AudioSourceExtended>();
        audioSourceExtended.Duration = clip.length;

        audioSource.clip = clip;
        audioSource.Play();
    }
}