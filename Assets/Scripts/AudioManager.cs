using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private string sceneName;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() {
        // Play("MainMenuMusic");

        /*sceneName = SceneManager.GetActiveScene().name;
        if(sceneName.Equals("MainMenu"))
            Play("MainMenuMusic");
        else if(sceneName.Equals("Maze1Final"))
            Play("LevelMusic1");
        else if(sceneName.Equals("Maze3Final"))
            Play("LevelMusic2");
        else if(sceneName.Equals("Maze5Final"))
            Play("LevelMusic3");
        else if(sceneName.Equals("PlatformPrototype"))
            Play("BossMusic");*/
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop() {
        foreach(Sound s in sounds) {
            s.source.Stop();
        }
    }
}
