using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    private GameObject heldObject;
    public LayerMask mask;
    RaycastHit2D hit;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    private void Update()
    {
        hit = Physics2D.Raycast(transform.position, transform.right, 1f, mask);

        Debug.DrawLine(transform.position, hit.point, Color.red);

        if (Input.GetKeyDown(KeyCode.E) && hit.collider is not null)
        {
            if (hit.collider is not null)
            {
                heldObject = hit.collider.gameObject;
                heldObject.transform.parent = transform;
            }
            else
            {
                heldObject = null;
            }
        }
        if (heldObject is not null)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (hit.collider is not null)
                {
                    heldObject.transform.parent = null;
                    heldObject = null;
                }
            }
        }
    }
}