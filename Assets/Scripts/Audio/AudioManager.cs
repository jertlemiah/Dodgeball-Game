using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
/// <summary> 
///<para>AudioManager accepts an array of AudioTrack scriptable objects and plays those tracks acrross all scenes.</para>
///<para>When a track is finished, the next in the array is automatically played.</para>
///<para>By default, the array is shuffled before playing the first track.</para>
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] public List<AudioTrack> currentTracks = new List<AudioTrack>(); 
    [SerializeField] public AudioTrack mainMenuTrack;
    [SerializeField] public AudioTrack loadingScreenTrack;

    [SerializeField] public AudioSource musicAudioSource;

    [SerializeField] public AudioMixer mixer;

    [SerializeField] bool shuffleListOnStart = true;
    

    [Space(10)][Header("Status Info")]
    [SerializeField] string currentTrack; // This is purely for relaying the name of the track to the inspector for readability

    private int currentTrackIndex = 0;
    public bool stopMusic = false;
    
    void Awake()
    {
        if(!musicAudioSource) {
            musicAudioSource = GetComponent<AudioSource>(); // This will just grab the default audioSource
            musicAudioSource.outputAudioMixerGroup = mixer.outputAudioMixerGroup;
        } 
        // EventManagerSO.E_SceneLoaded += LoadNewSceneMusic;
    }

    void OnDisable()
    {
        // EventManagerSO.E_SceneLoaded -= LoadNewSceneMusic;
    }

    void Start ()
    {
        if (shuffleListOnStart)
            Shuffle ();
        
        currentTrackIndex = -1; // Must start on -1 because PlayNextTrack increments currentTrackIndex before using it
        // PlayNextTrack();
    }
    void Update ()
    {
        if(!mixer){
            Debug.LogWarning("AudioManager does not have a mixer set");
            return;
        }
        if (stopMusic){
            musicAudioSource.Stop();
        } else if (musicAudioSource.isPlaying == false && currentTracks.Count > 0) {
            PlayNextTrack();
        }
    }

    public void PlayLoadingMusic()
    {
        ChangePlaylist(loadingScreenTrack);
    }

    public void ChangePlaylist(AudioTrack newTrack)
    {
        List<AudioTrack> newTracks = new List<AudioTrack>();
        newTracks.Add(newTrack);
        ChangePlaylist(newTracks);
    }
    public void ChangePlaylist(List<AudioTrack> newPlaylist)
    {
        if(newPlaylist.Count>0){
            currentTracks.Clear();
            currentTracks = newPlaylist;
            musicAudioSource.Stop();
            PlayNextTrack();
        } else {
            Debug.LogWarning("Function 'ChangePlayList' was called, but the 'newPlaylist' argument had no tracks to switch to.");
        }
        
    }

    // this overload is broken
    public void ChangePlaylist(SceneIndex sceneIndex)
    {
        List<AudioTrack> newTracks = new List<AudioTrack>();
        if(sceneIndex == SceneIndex.TITLE_SCREEN){
            newTracks.Add(mainMenuTrack);
        } 
        if(newTracks.Count > 0){
            ChangePlaylist(newTracks);
        }
        

    }

    // void LoadNewSceneMusic(SceneIndex sceneIndex)
    // {
    //     List<AudioTrack> newTracks = new List<AudioTrack>();
    //     switch(sceneIndex){
    //         case SceneIndex.TITLE_SCREEN:
    //             newTracks.Add(mainMenuTrack);
    //             ChangePlaylist(newTracks);
    //             break;
    //         // case SceneIndex.:
    //         //     newTracks.Add(mainMenuTrack);
    //         //     ChangePlaylist(newTracks);
    //         //     break;
    //         default:
    //             break;
    //     }
        
    // }

    /// <summary> 
    /// <para>Shuffles the array of AudioTracks.</para>
    /// </summary>
    public void Shuffle() {
        for (int i = 0; i < currentTracks.Count; i++) {
            int rnd = Random.Range(0, currentTracks.Count);
            AudioTrack temp = currentTracks[rnd];
            currentTracks[rnd] = currentTracks[i];
            currentTracks[i] = temp;
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
        if(mixer != null && mixer.GetFloat("VolMaster",out mixerLevel)){
            return Mathf.Pow(10f,mixerLevel/20);
        } else {
            return 1f;
        }
    }
    public float GetVolMusic()
    {
        float mixerLevel;
        if(mixer != null && mixer.GetFloat("VolMusic",out mixerLevel)){
            return Mathf.Pow(10f,mixerLevel/20);
        } else {
            return 1f;
        }
    }
    public float GetVolGameSFX()
    {
        float mixerLevel;
        if(mixer != null && mixer.GetFloat("VolGameSFX",out mixerLevel)){
            return Mathf.Pow(10f,mixerLevel/20);
        } else {
            return 1f;
        }
    }
    public float GetVolUiSFX()
    {
        float mixerLevel;
        if(mixer != null && mixer.GetFloat("VolUiSFX",out mixerLevel)){
            return Mathf.Pow(10f,mixerLevel/20);
        } else {
            return 1f;
        }
        
    }

    /// <summary> 
    /// <para>Simply plays the next track in backgroundTracks. Loops to start of array on hitting the end.</para>
    /// </summary>
    public void PlayNextTrack()
    {
        if(currentTracks.Count == 0) {return;}
        currentTrackIndex++;
        if(currentTrackIndex >= currentTracks.Count) { currentTrackIndex=0;}

        musicAudioSource.clip = currentTracks[currentTrackIndex].audioClip;
        musicAudioSource.volume = currentTracks[currentTrackIndex].volume;
        musicAudioSource.pitch = currentTracks[currentTrackIndex].pitch;
        currentTrack = currentTracks[currentTrackIndex].trackName;
        musicAudioSource.Play(); 
    }
}
