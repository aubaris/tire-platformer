﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip bottle;
    [SerializeField] private AudioClip brokenGlassClip;
    [SerializeField] private AudioClip brokenTV;
    [SerializeField] private AudioClip bubble;
    [SerializeField] private AudioClip dead;
    [SerializeField] private AudioClip doorOpened;
    [SerializeField] private AudioClip doorRammed;
    [SerializeField] private AudioClip fireGhost;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip losePatch;
    [SerializeField] private AudioClip openShelf;
    [SerializeField] private AudioClip pickupKey;
    [SerializeField] private AudioClip pickupPatch;
    [SerializeField] private AudioClip plantGrown;
    [SerializeField] private AudioClip puddle;
    [SerializeField] private AudioClip spikes;
    [SerializeField] private AudioClip skeletonArm;

    private AudioSource[] audioSources;
    [SerializeField] AudioSource musicFriendly;
    [SerializeField] AudioSource musicEvil;
    [SerializeField] AudioSource musicEnd;

    public enum SoundID
    {
        Bottle, BrokenGlass, BrokenTV, Bubble, Dead, DoorOpened, DoorRammed, FireGhost, Jump, LosePatch, OpenShelf, PickupKey, PickupPatch, PlantGrown, Puddle, Spikes, SkeletonArm, Num
    }
    public enum MusicID
    {
        Friendly, Evil, End, Num
    }

    public Dictionary<SoundID, AudioSource> sources;

    private void Start()
    {
        sources = new Dictionary<SoundID, AudioSource>();
        foreach (SoundID id in Enum.GetValues(typeof(SoundID)))
        {
            sources.Add(id, gameObject.AddComponent<AudioSource>());
        }
        sources[SoundID.Bottle].clip = bottle;
        sources[SoundID.BrokenGlass].clip = brokenGlassClip;
        sources[SoundID.BrokenTV].clip = brokenTV;
        sources[SoundID.Bubble].clip = bubble;
        sources[SoundID.Dead].clip = dead;
        sources[SoundID.DoorOpened].clip = doorOpened;
        sources[SoundID.DoorRammed].clip = doorRammed;
        sources[SoundID.FireGhost].clip = fireGhost;
        sources[SoundID.Jump].clip = jump;
        sources[SoundID.LosePatch].clip = losePatch;
        sources[SoundID.OpenShelf].clip = openShelf;
        sources[SoundID.PickupKey].clip = pickupKey;
        sources[SoundID.PickupPatch].clip = pickupPatch;
        sources[SoundID.PlantGrown].clip = plantGrown;
        sources[SoundID.Puddle].clip = puddle;
        sources[SoundID.Spikes].clip = spikes;
        sources[SoundID.SkeletonArm].clip = skeletonArm;

        //musicFriendly = gameObject.AddComponent<AudioSource>();
        //musicFriendly.volume = 0.2f;
        //musicFriendly.loop = true;
        //musicFriendly.Play();

        //musicEvil = gameObject.AddComponent<AudioSource>();
        //musicEvil.volume = 0.0f;
        //musicEvil.loop = true;
        //musicEvil.Play();

    }

    public void PlaySound(SoundID id)
    {
        sources[id].Play();
    }

    public void PlayMusic(MusicID id)
    {
        if (id == MusicID.Evil)
        {
            musicFriendly.volume = 0f;
            musicEvil.volume = 0.2f;
            musicEnd.volume = 0f;
        }
        else if (id == MusicID.Friendly)
        {
            musicFriendly.volume = 0.2f;
            musicEvil.volume = 0f;
            musicEnd.volume = 0f;
        }
        else if (id == MusicID.End)
        {
            musicFriendly.volume = 0.0f;
            musicEvil.volume = 0f;
            musicEnd.volume = 0.2f;
        }
    }
}
