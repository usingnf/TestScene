using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum ParticleType
{
    Destroy = 0,
}
public class EffectManager : Singleton<EffectManager>
{
    [Header("Particles")]
    [SerializeField] private GameObject[] particlesType;

    private List<ParticleSystem> particles = new List<ParticleSystem>();
    private void Awake()
    {
        Instance = this;
    }
    
    public async void Play(ParticleType type, Vector3 pos, float time)
    {
        ParticleSystem p = null;
        foreach (ParticleSystem particle in particles)
        {
            if(!particle.gameObject.activeSelf)
            {
                p = particle;
                break;
            }
        }
        if(p == null)
        {
            p = Instantiate(particlesType[(int)type], pos, Quaternion.identity, this.transform).GetComponent<ParticleSystem>();
            particles.Add(p);
        }
        else
        {
            p.transform.position = pos;
            p.gameObject.SetActive(true);
        }
        p.Play();
        await Task.Delay((int)(time * 1000));
        if(p != null)
            p.gameObject.SetActive(false);
    }
}
