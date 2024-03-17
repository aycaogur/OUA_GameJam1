using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private Vector3 _parentPosition = new Vector3(-1f, -0.3f, 0f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tabela"))
        {
            transform.SetParent(collision.transform);
            transform.localPosition = _parentPosition;

            GetComponent<Collider2D>().enabled = false;
        }
    }
}