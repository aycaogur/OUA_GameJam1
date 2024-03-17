using UnityEngine;

public class InteractUnlem : MonoBehaviour
{
    public GameObject UnlemImage;    

    private void Start()
    {
        UnlemImage.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tabela1") || collision.CompareTag("Tabela2") || collision.CompareTag("Tabela3"))
        {
            UnlemImage.SetActive(true);           
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tabela1") || collision.CompareTag("Tabela2") || collision.CompareTag("Tabela3"))
        {
            UnlemImage.SetActive(false);          
        }
    }    
}