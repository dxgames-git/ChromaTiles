using UnityEngine;
using System.Collections;

public class LevelCheckMark : MonoBehaviour {

    private bool didPressEasy;
    private bool didPressHard;
    public GameObject checkMark;
    private GameObject easyBox;
    private GameObject hardBox;

	// Use this for initialization
	void Start () {
        didPressEasy = false;
        didPressHard = false;
        easyBox = GameObject.FindGameObjectWithTag("EasySquare");
        hardBox = GameObject.FindGameObjectWithTag("HardSquare");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void pressedEasy() {
        didPressEasy = true;
        if (didPressHard == true) {
            Destroy(checkMark);
        }
        Instantiate(checkMark, new Vector3(easyBox.transform.position.x, easyBox.transform.position.y, easyBox.transform.position.z), easyBox.transform.rotation);
        didPressHard = false;
    }
    public void pressedHard() {
        didPressHard = true;
        if (didPressEasy == true)
        {
            Destroy(checkMark);
        }
        Instantiate(checkMark, new Vector3(hardBox.transform.position.x, hardBox.transform.position.y, hardBox.transform.position.z), hardBox.transform.rotation);
        didPressHard = false;
    }
}
