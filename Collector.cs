using UnityEngine;

public class Collector : MonoBehaviour
{
    private Vector3 _parentPosition = new Vector3(0.93f, -0.38f, 0f);

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject.CompareTag("Kova") || collision.gameObject.CompareTag("Baret") || collision.gameObject.CompareTag("El"))
            {
                collision.transform.SetParent(transform);
                collision.transform.localPosition = _parentPosition;
            }
        }
    }
}