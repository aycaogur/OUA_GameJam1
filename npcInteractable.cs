
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class npcInteractable : MonoBehaviour
{

    public void Interact()
    {
        StartCoroutine(TabelaDegisim());
    }

    public IEnumerator TabelaDegisim()
    {
        transform.DOScale(new Vector3(4, 4, 4), 3f);
        yield return new WaitForSeconds(2f);
        transform.DOScale(new Vector3(2, 2, 2), 3f);
    }
}
