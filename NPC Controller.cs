using UnityEngine;


public class NPCController : MonoBehaviour
{
    public float hareketHizi = 3f;
    public Transform hedefNokta;
    public float durmaMesafesi = 3f;
    public float maxEtkilesimSuresi = 3f;
    public Animator anim4;
    public Animator animIdle;
    public bool npc;

    private bool durmaDurumu = false;
    private bool etkilesimdeMi = false;
    private bool spaceBasildiMi = false;
    private float etkilesimBaslangicZamani;
    private GameObject player;

    public GameObject start;
    public GameObject finish;
    private Rigidbody2D rb;
    private Transform currentPoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        currentPoint = finish.transform;
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == finish.transform)
        {
            rb.velocity = new Vector2(hareketHizi, 0);
        }
        else
        {
            rb.velocity = new Vector2(-hareketHizi, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == finish.transform)
        {
            currentPoint = start.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == start.transform)
        {
            currentPoint = finish.transform;
        }

        if (!durmaDurumu)
        {
            if (!etkilesimdeMi && !spaceBasildiMi)
            {
                if (hedefNokta != null && Vector3.Distance(transform.position, hedefNokta.position) < durmaMesafesi)
                {
                    durmaDurumu = true;
                    hareketHizi = 0f;
                }
            }
            else
            {
                if (Time.time < (etkilesimBaslangicZamani + maxEtkilesimSuresi))
                {
                    return;
                }
                else
                {
                    etkilesimdeMi = true;
                }
            }
        }
        else
        {
            durmaDurumu = false;
            hareketHizi = 0f;
            if (anim4 != null && !spaceBasildiMi)
            {
                anim4.SetBool("npc", npc);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(start.transform.position, 0.5f);
        Gizmos.DrawWireSphere(finish.transform.position, 0.5f);
        Gizmos.DrawLine(start.transform.position, finish.transform.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tabela1"))
        {
            etkilesimdeMi = true;
            npc = true;
            etkilesimBaslangicZamani = Time.time;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tabela1"))
        {
            etkilesimdeMi = false;
            npc = false;
        }
    }

    void LateUpdate()
    {
        if (player.GetComponent<PlayerInteract>().canInteract)
        {
            spaceBasildiMi = false;
            hareketHizi = 3f;
            if (anim4 != null && anim4.GetBool("npc"))
            {
                anim4.SetBool("npc", npc);

            }
        }
        else
        {
            spaceBasildiMi = true;
            if (anim4 != null && !spaceBasildiMi)
            {
                anim4.SetBool("npc", npc);

            }

        }
    }
}


