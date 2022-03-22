using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    public float master;

    private void Awake()
    {
        master = PlayerPrefs.GetFloat("volume");
        if (Instance == null) { Instance = this; }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * master;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void changeVolume()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume * master;
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Play("MenuTheme");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            sounds[3].source.Pause();
            Play("MenuTheme");
        }
        else
        {
            if (sounds[3].source.isPlaying) return;
            sounds[4].source.Pause();
            Play("GameTheme");
        }
    }

    public void Play(string songName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == songName);
        s?.source.Play();
    }
}
