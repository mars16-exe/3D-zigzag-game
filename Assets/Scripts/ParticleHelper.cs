using UnityEngine;

public class ParticleAutoReturn : MonoBehaviour
{
    private ParticlePool pool;
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        pool = ParticlePool.Instance;
    }

    private void OnDisable()
    {
        pool.ReturnToPool(ps);
    }
}