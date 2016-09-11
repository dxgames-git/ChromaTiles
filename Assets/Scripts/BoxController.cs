using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour
{

    //Death Scene
    private UIManager deadPanel;

    //Setting the Box's color
    private GameObject box;
    public Color boxColor;

    //Score
    private ScoreManager scoreUp;

    // Use this for initialization
    void Start()
    {
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
        transform.Rotate(Vector3.forward * -90 * Time.deltaTime);
        if (transform.position.y + 10f < Camera.main.transform.position.y)
        {
            Destroy(gameObject, 0.3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SpriteRenderer>().color.Equals(boxColor))
        {
            GameObject.Find("Tiles").GetComponent<EffectController>().fadeOut(0.4f);
            other.gameObject.transform.parent.gameObject.GetComponent<AudioSource>().PlayDelayed(0f);
            //Increase Score
            scoreUp.touchRightBox();
            Destroy(gameObject);
        }
        else
        {
            deadPanel.isDead = true;
        }
    }

}
