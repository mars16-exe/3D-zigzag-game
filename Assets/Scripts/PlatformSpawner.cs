using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    private Vector3 lastPos;
    private float size;

    private BallController ball;
    private void Start()
    {
        ball = BallController.Instance;
        
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatform();
        }
        
        InvokeRepeating(nameof(SpawnPlatform), 2f, 0.2f);
    }

    private void Update()
    {
        
    }

    private void SpawnPlatform()
    {
        if (ball.gameOver)
        {
            CancelInvoke(nameof(SpawnPlatform));
        }
        
        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }
    }

    private void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        
        Instantiate(platform, pos, Quaternion.identity);
        SpawnDiamond(pos);
    }

    private void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        
        Instantiate(platform, pos, Quaternion.identity);
        SpawnDiamond(pos);
    }

    private void SpawnDiamond(Vector3 position)
    {
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, position + (Vector3.up), diamond.transform.rotation);
        }
    }
}

