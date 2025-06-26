using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject ball;
    private Vector3 offset;
    public float lerpRate;

    private BallController ballController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = ball.transform.position - transform.position;
        ballController = ball.GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballController.gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
