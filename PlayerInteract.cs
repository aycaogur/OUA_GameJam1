using System.Collections;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Animator anim1;
    [SerializeField] private Animator anim2;
    [SerializeField] private Animator anim3;
    public bool tabela1;
    public bool tabela2;
    public bool tabela3;

    public bool canInteract = true;
    private float coolDownTime = 2f;

    public GameObject kova;
    // diger iki obje eklenecek+unityden

    private void Update()
    {
        float interactRange = 2f;
        Collider2D[] ColliderArray = Physics2D.OverlapCircleAll(transform.position, interactRange);
        foreach (Collider2D collider in ColliderArray)
        {
            if (collider.TryGetComponent(out npcInteractable npcInteractable))
            {
                if (Input.GetKeyDown(KeyCode.Space) && canInteract)
                {
                    canInteract = false;
                    StartCoroutine("Beklet", coolDownTime);

                    if (collider.CompareTag("Tabela1") && !tabela1)
                    {
                        if (IsValidKova())
                        {
                            npcInteractable.Interact();
                            anim1.SetBool("Tabela1", tabela1);
                            UI.instance.AddScore();
                        }
                    }
                    else if (collider.CompareTag("Tabela2") && !tabela2)
                    {
                        // void eklencek
                        npcInteractable.Interact();
                        anim2.SetBool("Tabela2", tabela2);
                        UI.instance.AddScore();
                    }
                    else if (collider.CompareTag("Tabela3") && !tabela3)
                    {
                        // void eklencek
                        npcInteractable.Interact();
                        anim3.SetBool("Tabela3", tabela3);
                        UI.instance.AddScore();
                    }
                }
            }
        }
    }
    // diger iki obje icin void yazilacak
    private bool IsValidKova()
    {
        return kova != null && kova.gameObject.activeSelf && kova.CompareTag("kova");
    }


    public IEnumerator Beklet(float coolDownTime)
    {
        yield return new WaitForSeconds(coolDownTime);
        canInteract = true;
    }

    public npcInteractable getInteractableObject()
    {
        float interactRange = 2f;
        Collider2D[] ColliderArray = Physics2D.OverlapCircleAll(transform.position, interactRange);
        foreach (Collider2D collider in ColliderArray)
        {
            if (collider.TryGetComponent(out npcInteractable npcInteractable))
            {
                return npcInteractable;
            }
        }
        return null;
    }
}
