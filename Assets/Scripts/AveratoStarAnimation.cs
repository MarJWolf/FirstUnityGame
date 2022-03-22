using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveratoStarAnimation : MonoBehaviour
{
    public ParticleSystem StarParticles;

    void Start()
    {
        var main = StarParticles.main;
        main.loop = false;
        
    }
}
