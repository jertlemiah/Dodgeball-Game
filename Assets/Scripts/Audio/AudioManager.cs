using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary> 
///<para>AudioManager accepts an array of AudioTrack scriptable objects and plays those tracks acrross all scenes.</para>
///<para>When a track is finished, the next in the array is automatically played.</para>
///<para>By default, the array is shuffled before playing the first track.</para>
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    [Header("Fill these out")]
    [Tooltip("The array of AudioTrack scriptable objects the audio manager will play.")] 
    [SerializeField] public AudioTrack[] backgroundTracks; 

    [SerializeField] public AudioSource musicAudioSource;

    [SerializeField] public AudioMixer mixer;

    [SerializeField] bool shuffleList = true;
    

    [Space(10)][Header("Status Info")]
    [SerializeField] string currentTrack; // This is purely for relaying the name of the track to the inspector for readability

    private int currentTrackIndex = 0;
    
    void Awake()
    {
        if(!musicAudioSource) {
            musicAudioSource = GetComponent<AudioSource>(); // This will just grab the default audioSource
        } 
    }
    void Start()
    {
        if(shuffleList)
            Shuffle();
        
        currentTrackIndex = -1; // Must start on -1 because PlayNextTrack increments currentTrackIndex before using it
        PlayNextTrack();
    }
    void Update()
    {
        if(musicAudioSource.isPlaying == false)
        {
            PlayNextTrack();
        }
    }

    /// <summary> 
    /// <para>Shuffles the array of AudioTracks.</para>
    /// </summary>
    public void Shuffle() {
        for (int i = 0; i < backgroundTracks.Length; i++) {
            int rnd = Random.Range(0, backgroundTracks.Length);
            AudioTrack temp = backgroundTracks[rnd];
            backgroundTracks[rnd] = backgroundTracks[i];
            backgroundTracks[i] = temp;
        }
    }

    /// <summary> 
    /// <para>Sets the Master volume for the AudioMixer, used by a UI volume slider.</para>
    /// <para>  float sliderValue - New value for Master volume. Value clamped between 0.0001f and 1f.</para>
    /// </summary>
    /// <param name="sliderValue">New value for Master volume. Intended with use of UI slider. Value clamped between 0.0001f and 1f.</param>
    public void SetVolMaster(float sliderValue)
    {
        sliderValue = Mathf.Clamp(sliderValue,0.0001f,1f);
        mixer.SetFloat("VolMaster",Mathf.Log10(sliderValue)*20);
    }

    /// <summary> 
    /// <para>Sets the Music volume for the AudioMixer, used by a UI volume slider.</para>
    /// <para>  float sliderValue - New value for Music volume. Value clamped between 0.0001f and 1f.</para>
    /// </summary>
    /// <param name="sliderValue">New value for Music volume. Intended with use of UI slider. Value clamped between 0.0001f and 1f.</param>
    public void SetVolMusic(float sliderValue)
    {
        sliderValue = Mathf.Clamp(sliderValue,0.0001f,1f);
        mixer.SetFloat("VolMusic",Mathf.Log10(sliderValue)*20);
    }

    /// <summary> 
    /// <para>Sets the Game Sound Effects volume for the AudioMixer, used by a UI volume slider.</para>
    /// <para>  float sliderValue - New value for Game SFX volume. Value clamped between 0.0001f and 1f.</para>
    /// </summary>
    /// <param name="sliderValue">New value for Game SFX volume. Intended with use of UI slider. Value clamped between 0.0001f and 1f.</param>
    public void SetVolGameSFX(float sliderValue)
    {
        sliderValue = Mathf.Clamp(sliderValue,0.0001f,1f);
        mixer.SetFloat("VolGameSFX",Mathf.Log10(sliderValue)*20);
    }

    /// <summary> 
    /// <para>Sets the UI Sound Effects volume for the AudioMixer, used by a UI volume slider.</para>
    /// <para>  float sliderValue - New value for UI SFX volume. Value clamped between 0.0001f and 1f.</para>
    /// </summary>
    /// <param name="sliderValue">New value for UI SFX  volume. Intended with use of UI slider. Value clamped between 0.0001f and 1f.</param>
    public void SetVolUiSFX(float sliderValue)
    {
        sliderValue = Mathf.Clamp(sliderValue,0.0001f,1f);
        mixer.SetFloat("VolUiSFX",Mathf.Log10(sliderValue)*20);
    }


    public float GetVolMaster()
    {
        float mixerLevel;
        mixer.GetFloat("VolMaster",out mixerLevel);
        return Mathf.Pow(10f,mixerLevel/20);
    }
    public float GetVolMusic()
    {
        float mixerLevel;
        mixer.GetFloat("VolMusic",out mixerLevel);
        return Mathf.Pow(10f,mixerLevel/20);
    }
    public float GetVolGameSFX()
    {
        float mixerLevel;
        mixer.GetFloat("VolGameSFX",out mixerLevel);
        return Mathf.Pow(10f,mixerLevel/20);
    }
    public float GetVolUiSFX()
    {
        float mixerLevel;
        mixer.GetFloat("VolUiSFX",out mixerLevel);
        return Mathf.Pow(10f,mixerLevel/20);
    }

    /// <summary> 
    /// <para>Simply plays the next track in backgroundTracks. Loops to start of array on hitting the end.</para>
    /// </summary>
    public void PlayNextTrack()
    {
        currentTrackIndex++;
        if(currentTrackIndex >= backgroundTracks.Length) { currentTrackIndex=0;}

        musicAudioSource.clip = backgroundTracks[currentTrackIndex].audioClip;
        musicAudioSource.volume = backgroundTracks[currentTrackIndex].volume;
        musicAudioSource.pitch = backgroundTracks[currentTrackIndex].pitch;
        currentTrack = backgroundTracks[currentTrackIndex].trackName;
        musicAudioSource.Play(); 
    }
}
