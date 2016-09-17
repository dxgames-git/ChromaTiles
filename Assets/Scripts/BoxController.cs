using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour
{

    //Death Scene
    private UIManager deadPanel;

    //Setting the Box's color
    private GameObject box;

    //Score
    private ScoreManager scoreUp;

    // Use this for initialization
    void Start()
    {
        deadPanel = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        scoreUp = Camera.main.GetComponent<ScoreManager>();
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
        if (other.gameObject.GetComponent<SpriteRenderer>().color.Equals(gameObject.GetComponent<SpriteRenderer>().color))
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
