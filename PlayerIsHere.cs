using UnityEngine;

public class PlayerIsHere : MonoBehaviour
{
    public float UpPosition;
    public float DownPosition;
    public float Speed;

    private void LateUpdate()
    {
        float newY = Mathf.PingPong(Time.time * Speed, UpPosition - DownPosition) + DownPosition;
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }
}