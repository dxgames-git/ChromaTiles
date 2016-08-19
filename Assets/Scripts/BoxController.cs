using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour
{

    //Death Scene
    private UIManager deadPanel;

    //Setting the Box's color
    private GameObject box;
    private GameObject theCamera;
    public Color boxColor;

    //Score
    private ScoreManager scoreUp;

    //Particle System
    public GameObject glowParticle;

    // Use this for initialization
    void Start()
    {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");

        Color[] color = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>().color;
        int[] numbers = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>().numbers;
        int picker = numbers[(int) (Random.value * numbers.Length)];
        gameObject.GetComponent<SpriteRenderer>().color = color[picker];
        boxColor = color[picker];

        deadPanel = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        scoreUp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + 10f < theCamera.transform.position.y)
        {
            Destroy(gameObject, 0.3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SpriteRenderer>().color.Equals(boxColor))
        {
            GameObject glowEffect = (GameObject) Instantiate(glowParticle, new Vector3(0, other.gameObject.transform.position.y, -8f), gameObject.transform.rotation);
            glowEffect.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
            //Increase Score
            Destroy(gameObject, 0.05f);
            scoreUp.touchRightBox();
        }
        else
        {
            deadPanel.isDead = true;
        }
    }

}
