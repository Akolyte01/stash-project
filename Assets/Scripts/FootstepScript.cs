﻿using UnityEngine;
using System.Collections;

public class FootstepScript : MonoBehaviour
{
    AudioSource source;
    public AudioClip footstep0;
    public AudioClip footstep1;
    public AudioClip footstep2;
    public string surface0tag;
    public string surface1tag;
    public string surface2tag;
    private string currentSurface;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void triggerFootstep()
    {
        
        if (currentSurface == surface0tag)
        {
            source.PlayOneShot(footstep0, .7f);
        }
        else if (currentSurface == surface1tag)
        {
            source.PlayOneShot(footstep1, .5f);
        }
        else if (currentSurface == surface2tag)
        {
            source.PlayOneShot(footstep2, .7f);
        }
        else {  source.PlayOneShot(footstep1, .5f); }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal == Vector3.up)
        {
            currentSurface = hit.gameObject.tag;
        }
    }
}
