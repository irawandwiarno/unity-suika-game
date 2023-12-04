using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Buah : MonoBehaviour
{
    private float OPSIDE_PLAYER_FRUIT = 0.5f;

    private Rigidbody2D rb;
    public JenisBuah jenisBuah;
    public bool followPlayer = false;
    private GameObject player;
    private Player playerScript;

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
        FollowPlayer();
        ExecuteGameOverEvent();
    }

    private void FollowPlayer()
    {
        if (followPlayer)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - OPSIDE_PLAYER_FRUIT, 0f);
        }
    }

    private void ExecuteGameOverEvent()
    {
        if (gameOverRun)
        {
            StartCoroutine(DelayedGameOverEvent());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleTriggerEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HandleTriggerExit(collision);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        HandleCollisionEnter(other);
    }

    private void HandleTriggerEnter(Collider2D collision)
    {
        EndLine endLine = collision.GetComponent<EndLine>();
        if (endLine != null)
        {
            gameOverRun = true;
            GameOver.AddListener(endLine.GameOver);
        }
    }

    private void HandleTriggerExit(Collider2D collision)
    {
        EndLine endLine = collision.GetComponent<EndLine>();
        if (endLine != null)
        {
            gameOverRun = false;
            GameOver.RemoveListener(endLine.GameOver);
        }
    }

    private void HandleCollisionEnter(Collision2D other)
    {
        var BuahScript = other.gameObject.GetComponent<Buah>();
        if (BuahScript != null)
        {
            if (BuahScript.jenisBuah == jenisBuah)
            {
                var transformMean = (other.transform.position + gameObject.transform.position) / 2;
                Destroy(gameObject);
                BuahInfo buahInfo = new BuahInfo(true, jenisBuah, transformMean);
                ScriptManagement.buahInfo = buahInfo;
            }
        }
    }

    private void dropFruid()
    {
        followPlayer = false;
        rb.gravityScale = 1;
    }

    public void addSubcribe()
    {
        playerScript.releaseFruitEvent.AddListener(dropFruid);
    }

    private IEnumerator DelayedGameOverEvent()
    {
        yield return new WaitForSeconds(2);
        GameOver.Invoke();
    }
}
