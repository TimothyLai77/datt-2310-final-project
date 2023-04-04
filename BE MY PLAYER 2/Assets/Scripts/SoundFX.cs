using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public AudioClip arrowSound;
    public AudioClip jumpSound;
    public AudioClip fallingSpikeSound;
    public AudioClip spikeBoomSound;
    public AudioClip appleSound;
    public AudioClip checkpointFinishSound;

    public void HoverSound()
    {
        mySounds.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        mySounds.PlayOneShot(clickSound);
    }

    public void ArrowSound()
    {
        mySounds.PlayOneShot(arrowSound);
    }

    public void JumpSound()
    {
        mySounds.PlayOneShot(jumpSound);
    }

    public void FallingSpikeSound()
    {
        mySounds.PlayOneShot(fallingSpikeSound);
    }

    public void SpikeBoomSound()
    {
        mySounds.PlayOneShot(spikeBoomSound);
    }

    public void AppleSound()
    {
        mySounds.PlayOneShot(appleSound);
    }

    public void CheckpointFinishSound()
    {
        mySounds.PlayOneShot(checkpointFinishSound);
    }
    
    public void Stop()
    {
        mySounds.Stop();
    }
}
