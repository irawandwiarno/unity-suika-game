using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buah : MonoBehaviour
{
    private Rigidbody2D rb;
    public JenisBuah jenisBuah;
    public bool followPlayer = false;
    GameObject player;
    Player playerScript;


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
            gameObject.transform.position = player.transform.position;
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
}
