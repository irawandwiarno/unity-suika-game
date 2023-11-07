using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buah : MonoBehaviour
{
    private Rigidbody2D rb;
    public JenisBuah jenisBuah;
    public bool followPlayer = false;
    GameObject player;
    Player playerScript;

    public UnityEvent GameOver;
    private bool gameOverRun = false;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (followPlayer)
        {
            gameObject.transform.position =  new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, 0f) ;
        }
        if(gameOverRun)
        {
            ExecuteGameOverEvent();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndLine endLine = collision.GetComponent<EndLine>();
        if (endLine != null)
        {
            Debug.Log(jenisBuah + "Enter");
            gameOverRun = true;
            GameOver.AddListener(endLine.GameOver);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EndLine endLine = collision.GetComponent<EndLine>();
        if (endLine != null)
        {
            Debug.Log(jenisBuah + "Exit");
            gameOverRun = false;
            GameOver.RemoveListener(endLine.GameOver);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var buahClass = other.gameObject.GetComponent<Buah>();
        if (buahClass != null)
        {
            if (buahClass.jenisBuah == jenisBuah && jenisBuah != JenisBuah.semangka)
            {
                var transformMean = (other.transform.position + gameObject.transform.position) / 2;
                Destroy(gameObject);
                ScriptManagement.lokasi = transformMean;
                ScriptManagement.namaBuah = jenisBuah;
                ScriptManagement.ubahBuah = true;
            }
        }

    }


    private void dropFruid()
    {
        followPlayer = false;
        rb.gravityScale = 1;
        playerScript.OnTouchRellase.RemoveListener(dropFruid);
    }

    public void addSubcribe()
    {
        playerScript.OnTouchRellase.AddListener(dropFruid);
    }

    public void ExecuteGameOverEvent()
    {
        if (gameOverRun)
        {
            StartCoroutine(DelayedGameOverEvent());
        }
    }

    private IEnumerator DelayedGameOverEvent()
    {
        yield return new WaitForSeconds(2);
        GameOver.Invoke();
    }
}
