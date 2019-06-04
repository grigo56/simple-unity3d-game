using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SoundArray{
	
	[SerializeField]
	private AudioClip[] _sounds;


	public void PlaySound(AudioSource source, float volume = 1f)
	{
		if(!source || _sounds.Length == 0)
			return;		
		
		int clipToPlay = UnityEngine.Random.Range(0,_sounds.Length);
		source.PlayOneShot(_sounds[clipToPlay], App.Instance.Settings.SoundSettings.VolumeFactor * volume);
	}
	
}
