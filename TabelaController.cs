using UnityEngine;

public class TabelaController : MonoBehaviour
{
    [SerializeField] private Material oldMat;
    private Material originalMat;
    public float interactDistance = 4f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMat = spriteRenderer.material;
    }

    private void Update()
    {
        ChangeColor();
    }

    public void ChangeColor()
    {
        Collider2D collison = Physics2D.OverlapCircle(transform.position, interactDistance);
        if (collison != null && collison.CompareTag("npc"))
        {
            if (spriteRenderer.color != Color.white)
                spriteRenderer.color = Color.white;
            else
                spriteRenderer.color = Color.red;
        }
    }
}