﻿using UnityEngine;
using System.Collections.Generic;

namespace Poltergeist
{
    public class AudioManager : MonoBehaviour
    {
        public static bool Enabled = true;

        public static AudioManager Instance { get; private set; }

        private AudioSource audioSource;

        void Awake()
        {
            Instance = this;
            this.audioSource = this.gameObject.AddComponent<AudioSource>();
        }

        private Dictionary<string, AudioClip> _clips = new Dictionary<string, AudioClip>();

        public AudioClip FindClip(string name)
        {
            if (_clips.ContainsKey(name))
            {
                return _clips[name];
            }

            AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);
            _clips[name] = clip;
            return clip;
        }

        public void PlaySFX(string name)
        {
            var clip = FindClip(name);
            if (clip == null)
            {
                return;
            }

            audioSource.PlayOneShot(clip);
        }
    }

}
