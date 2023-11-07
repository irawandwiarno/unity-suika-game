using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

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

    public TextMeshProUGUI scoreText;
    static public int score = 0;




    private GameObject fruitNext;

    private void Start()
    {
        spawnScript = AnkorSpawn.gameObject.GetComponent<SpawnFruit>();
        spawnBuah();
        scoreText.text = score.ToString();
    }
    private void Update()
    {
        checkFruitInPlayer();
        gabunginBuah();
    }

    private void gabunginBuah()
    {
        if (ubahBuah)
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
            score += 5;
            scoreText.text = score.ToString();
            return 1;
        }
        if (JenisBuah.stawberry == namaBuah)
        {
            score += 10;
            scoreText.text = score.ToString();
            return 2;
        }
        if (JenisBuah.anggur == namaBuah)
        {
            score += 15;
            scoreText.text = score.ToString();
            return 3;
        }
        if (JenisBuah.jeruk == namaBuah)
        {
            score += 20;
            scoreText.text = score.ToString();
            return 4;
        }
        if (JenisBuah.apel == namaBuah)
        {
            score += 25;
            scoreText.text = score.ToString();
            return 5;
        }
        if (JenisBuah.kelapa == namaBuah)
        {
            score += 30;
            scoreText.text = score.ToString();
            return 6;
        }
        if (JenisBuah.nanas == namaBuah)
        {
            score += 35;
            scoreText.text = score.ToString();
            return 7;
        }
        if (JenisBuah.melon == namaBuah)
        {
            score += 40;
            scoreText.text = score.ToString();
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


