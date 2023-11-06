using UnityEngine.SceneManagement;
using UnityEngine;

public class ScriptManagement : MonoBehaviour
{
    static public bool ubahBuah = false;
    static public JenisBuah namaBuah;
    static public Vector3 lokasi;
    public GameObject[] prefebs;
    public GameObject AnkorSpawn;
    public GameObject player;
    SpawnFruit spawnScript;
    public bool stayFruit = false;



    private GameObject fruitNext;

    private void Start()
    {
        spawnScript = AnkorSpawn.gameObject.GetComponent<SpawnFruit>();
        spawnBuah();
    }
    private void Update()
    {
        checkFruitInPlayer();
        gabunginBuah();
    }

    private void gabunginBuah()
    {
        if (ubahBuah == true)
        {
            ubahBuah = false;
            int index = nextBuahIndex();
            if (index > 0)
            {
                Instantiate(prefebs[index], lokasi, Quaternion.identity);
            }
        }
    }

    private int nextBuahIndex()
    {
        if (JenisBuah.cerry == namaBuah)
        {
            return 1;
        }
        if (JenisBuah.stawberry == namaBuah)
        {
            return 2;
        }
        if (JenisBuah.anggur == namaBuah)
        {
            return 3;
        }
        if (JenisBuah.jeruk == namaBuah)
        {
            return 4;
        }
        if (JenisBuah.apel == namaBuah)
        {
            return 5;
        }
        if (JenisBuah.kelapa == namaBuah)
        {
            return 6;
        }
        if (JenisBuah.nanas == namaBuah)
        {
            return 7;
        }
        if (JenisBuah.melon == namaBuah)
        {
            return 8;
        }

        return 0;
    }


    private void spawnBuah()
    {

        fruitNext = spawnScript.setSpawn(prefebs[Random.Range(0, 4)]);
        fruitNext.GetComponent<Rigidbody2D>().gravityScale = 0;

    }

    private void checkFruitInPlayer()
    {
        if (!Player.fruitExist)
        {
            Player.fruitExist = true;
            Buah buahScript = fruitNext.GetComponent<Buah>();
            buahScript.followPlayer = true;
            buahScript.addSubcribe();
            spawnBuah();
        }
    }

    

}


