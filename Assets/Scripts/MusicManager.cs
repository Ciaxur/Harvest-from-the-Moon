using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioClip battleMusic;
    public AudioClip victoryFanfare;
//    public bool musicMuted = false;
    public Toggle isMuted;
    public Toggle isPlaying;
    public Slider volumeSlider;
    public bool tutClosed = false;
    public float battleMusicLoopPoint;
    public float battleMusicLoopLength;
    public float victoryLoopPoint;
    public float victoryLoopLength;

    public Toggle soundIsMuted;
    public Slider soundVolumeSlider;

    [Range(0, 1)]
//    public float volume = .5f;

    private AudioSource audioPlayer;
    private AudioSource audioPlayer2;
    private AudioSource currentlyPlaying;

    private AudioClip startBattleMusic;
    private AudioClip loopBattleMusic;
    private AudioClip startVictoryMusic;
    private AudioClip loopVictoryMusic;
    private int lengthClip1;
//    private float lengthClip1Seconds = 7f;
    private int lengthClip2;
//    private float lengthClip2Seconds = 32f;
    private bool inCallback = false;

    private static int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = transform.gameObject.AddComponent<AudioSource>();
        audioPlayer2 = transform.gameObject.AddComponent<AudioSource>();

        if (battleMusic != null) {
            lengthClip1 = (int)(battleMusicLoopPoint * battleMusic.frequency);
            lengthClip2 = (int)(battleMusicLoopLength * battleMusic.frequency);
            createAudioClips(battleMusic, lengthClip1, lengthClip2, ref startBattleMusic, ref loopBattleMusic);
        }

        if (victoryFanfare != null) {
            lengthClip1 = (int)(victoryLoopPoint * victoryFanfare.frequency);
            lengthClip2 = (int)(victoryLoopLength * victoryFanfare.frequency);
	    createAudioClips(victoryFanfare, lengthClip1, lengthClip2, ref startVictoryMusic, ref loopVictoryMusic);
        }

	if (isMuted != null)
	{
            isMuted.isOn = SettingsManager.Instance.musicMuted;
	}
	if (isPlaying != null)
	{
	    isPlaying.isOn = !SettingsManager.Instance.musicMuted;
	}
        setVolumeInner(SettingsManager.Instance.musicVolume);
        if (volumeSlider != null)
	{
	     volumeSlider.value = SettingsManager.Instance.musicVolume;
	}
	if (soundIsMuted != null)
	{
            soundIsMuted.isOn = SettingsManager.Instance.soundsMuted;
	}
        if (soundVolumeSlider != null)
        {
            soundVolumeSlider.value = SettingsManager.Instance.soundsVolume;
        }

        if (tutClosed && !SettingsManager.Instance.musicMuted)
	{
             startPlayingMusic();
	}
    }

    // Update is called once per frame
    void Update()
    {
        setVolumeInner(SettingsManager.Instance.musicVolume);

    }
    private void createAudioClips()
    {
        if (battleMusic != null)
        {
            int len1 = lengthClip1;
            int len2 = lengthClip2;

            int overlapSamples = (int)(.2f * battleMusic.frequency * 0);
            startBattleMusic = AudioClip.Create("startBattleMusic", len1 + overlapSamples, battleMusic.channels, battleMusic.frequency, false);
            loopBattleMusic = AudioClip.Create("loopBattleMusic", len2 + overlapSamples, battleMusic.channels, battleMusic.frequency, false);
            float[] smp1 = new float[(len1 + overlapSamples) * battleMusic.channels];
            float[] smp2 = new float[(len2 + overlapSamples) * battleMusic.channels];
            battleMusic.GetData(smp1, 0);
            battleMusic.GetData(smp2, len1 - overlapSamples);
            startBattleMusic.SetData(smp1, 0);
            loopBattleMusic.SetData(smp2, 0);
        }
    }

    private void createAudioClips(in AudioClip clip, in int loopPoint, in int loopLength, ref AudioClip startMusic, ref AudioClip loopMusic)
    {
        if (clip != null)
        {
            int len1 = loopPoint;
            int len2 = loopLength;

            int overlapSamples = (int)(.2f * clip.frequency * 0);
            startMusic = AudioClip.Create("startMusic" + MusicManager.counter.ToString(), len1 + overlapSamples, clip.channels, clip.frequency, false);
            loopMusic = AudioClip.Create("loopMusic" + MusicManager.counter.ToString(), len2 + overlapSamples, clip.channels, clip.frequency, false);
            float[] smp1 = new float[(len1 + overlapSamples) * clip.channels];
            float[] smp2 = new float[(len2 + overlapSamples) * clip.channels];
            clip.GetData(smp1, 0);
            clip.GetData(smp2, len1 - overlapSamples);
            startMusic.SetData(smp1, 0);
            loopMusic.SetData(smp2, 0);
	    MusicManager.counter++;
        }
    }


    private void startPlayingMusic()
    {
        audioPlayer2.clip = startBattleMusic;
        audioPlayer2.loop = false;
        audioPlayer.clip = loopBattleMusic;
        audioPlayer.loop = true;
        double t0 = AudioSettings.dspTime + .1f;
//        double clipTime1 = lengthClip1 / startBattleMusic.frequency;
        double clipTime1 = battleMusicLoopPoint;
        audioPlayer2.PlayScheduled(t0);
        audioPlayer2.SetScheduledEndTime(t0 + clipTime1);
        audioPlayer.PlayScheduled(t0 + clipTime1);
        audioPlayer.time = .2f * 0;
    }
/*
    public void isMusicMuted()
    {
        if (!inCallback)
        {
            print("toggle music called");
            inCallback = true;
            SettingsManager.Instance.musicMuted = !SettingsManager.Instance.musicMuted;
	    if (isMuted != null)
            {
                isMuted.isOn = SettingsManager.Instance.musicMuted;
            }
            if (isPlaying != null)
            {
                 isPlaying.isOn = !SettingsManager.Instance.musicMuted;
            }
            if (!SettingsManager.Instance.musicMuted)
            {
                if (!audioPlayer.isPlaying && !audioPlayer2.isPlaying && tutClosed)
                {
                    startPlayingMusic();
                }
            }
            else
            {
                audioPlayer.Stop();
                audioPlayer2.Stop();
            }
            inCallback = false;
        }
    }
*/
    public void isMusicMuted(Boolean test)
    {
        if (!inCallback)
        {
            inCallback = true;
            SettingsManager.Instance.musicMuted = test;
	    if (isMuted != null)
            {
                isMuted.isOn = SettingsManager.Instance.musicMuted;
            }
            if (isPlaying != null)
            {
                 isPlaying.isOn = !SettingsManager.Instance.musicMuted;
            }
            if (!SettingsManager.Instance.musicMuted)
            {
                if (!audioPlayer.isPlaying && !audioPlayer2.isPlaying && tutClosed)
                {
                    startPlayingMusic();
                }
            }
            else
            {
                audioPlayer.Stop();
                audioPlayer2.Stop();
            }
            inCallback = false;
        }
    }

    public void isNotMusicMuted(Boolean test)
    {
	test = !test;
        if (!inCallback)
        {
            inCallback = true;
            SettingsManager.Instance.musicMuted = test;
	    if (isMuted != null)
            {
                isMuted.isOn = SettingsManager.Instance.musicMuted;
            }
            if (isPlaying != null)
            {
                 isPlaying.isOn = !SettingsManager.Instance.musicMuted;
            }
            if (!SettingsManager.Instance.musicMuted)
            {
                if (!audioPlayer.isPlaying && !audioPlayer2.isPlaying && tutClosed)
                {
                    startPlayingMusic();
                }
            }
            else
            {
                audioPlayer.Stop();
                audioPlayer2.Stop();
            }
            inCallback = false;
        }
    }

    public void setVolume(float vol)
    {
        SettingsManager.Instance.musicVolume = vol;
    }

    private void setVolumeInner(float vol)
    {
        audioPlayer.volume = vol;
        audioPlayer2.volume = vol;
    }

    public void Pause(bool pause)
    {
        if (pause && !SettingsManager.Instance.musicMuted)
        {
            currentlyPlaying = audioPlayer.isPlaying ? audioPlayer : audioPlayer2;
            currentlyPlaying.Pause();
        }
        else if (!SettingsManager.Instance.musicMuted && tutClosed)
        {
            currentlyPlaying.Play();
        }
    }

    public void closeTut()
    {
        if (!tutClosed)
        {
            tutClosed = true;
            if (!SettingsManager.Instance.musicMuted)
            {
                startPlayingMusic();
            }
        }
    }

    public void startPlayingVictoryMusic()
    {
        if (SettingsManager.Instance.musicMuted) { return; };
	AudioSource other;

        if (audioPlayer.isPlaying)
        {
            currentlyPlaying = audioPlayer;
            other = audioPlayer2;
        }
        else
        {
            currentlyPlaying = audioPlayer2;
            other = audioPlayer;
        }
	currentlyPlaying.Stop();

	other.clip = startVictoryMusic;
	other.loop = false;
	currentlyPlaying.clip = loopVictoryMusic;
	currentlyPlaying.loop = true;

        double t0 = AudioSettings.dspTime + .1f;
        double clipTime1 = victoryLoopPoint;
	other.PlayScheduled(t0);
	other.SetScheduledEndTime(t0 + clipTime1);
	currentlyPlaying.PlayScheduled(t0 + clipTime1);
    }

    public void isSoundMuted(Boolean test)
    {
        if (soundIsMuted != null && !inCallback)
        {
            inCallback = true;
            SettingsManager.Instance.soundsMuted = test;
            soundIsMuted.isOn = SettingsManager.Instance.soundsMuted;
            inCallback = false;
        }
    }

    public void setSoundsVolume(float vol)
    {
        SettingsManager.Instance.soundsVolume = vol;
    }

}
