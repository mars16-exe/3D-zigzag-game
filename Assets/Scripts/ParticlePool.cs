using UnityEngine;
using System.Collections.Generic;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool Instance;
    
    [SerializeField] private ParticleSystem particlePrefab;
    [SerializeField] private int poolSize = 6;
    
    private Queue<ParticleSystem> particlePool = new Queue<ParticleSystem>();
    private Transform poolParent;

    private void Awake()
    {
        Instance = this;
        
        // Create container for pooled particles
        poolParent = new GameObject("Particle Pool").transform;
        
        // Pre-instantiate particles
        for (int i = 0; i < poolSize; i++)
        {
            ParticleSystem ps = Instantiate(particlePrefab, poolParent);
            ps.gameObject.SetActive(false);
            particlePool.Enqueue(ps);
        }
    }

    public void PlayParticle(Vector3 position)
    {
        // Get particle from pool (or create new one if pool is empty)
        ParticleSystem ps = GetParticle();
        
        // Position and activate
        ps.transform.position = position;
        ps.gameObject.SetActive(true);
        ps.Play();
    }

    private ParticleSystem GetParticle()
    {
        if (particlePool.Count > 0)
        {
            return particlePool.Dequeue();
        }
        
        // If pool is empty, create one more (though with poolSize=6 this shouldn't happen)
        Debug.LogWarning("Particle pool empty! Creating extra particle.");
        ParticleSystem newPS = Instantiate(particlePrefab, poolParent);
        newPS.gameObject.SetActive(false);
        return newPS;
    }

    // Call this from the particle system's OnDisable event
    public void ReturnToPool(ParticleSystem ps)
    {
        ps.gameObject.SetActive(false);
        particlePool.Enqueue(ps);
    }
}