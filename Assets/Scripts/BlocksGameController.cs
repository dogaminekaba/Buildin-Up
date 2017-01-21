using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlocksGameController : MonoBehaviour
{
    public static bool gameOver = false;

    [SerializeField]
    private GameObject imageTarget;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject startUI;
    [SerializeField]
    private GameObject inGameUI;
    [SerializeField]
    private GameObject endGameUI;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text endScoreText;

    private Factory blockFactory;
    private GameObject focusObj = null;
    private float focusx;
    private float focusy;
    private float focusz;
    private Color oldColor;
    private Vector3 pos;
    private bool clickEnabled = false;
    private int currentScore = 0;

    // Use this for initialization
    void Start()
    {
        focusx = Screen.width / 2;
        focusz = 50;
        focusy = Screen.height / 2;
        pos = cam.ScreenToWorldPoint(new Vector3(focusx, focusy, focusz));
        focusObj = null;
        startUI.SetActive(true);
        inGameUI.SetActive(false);
        endGameUI.SetActive(false);
        clickEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickEnabled && Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                focusObj = hit.transform.gameObject;
                if (focusObj.CompareTag("BlockGround"))
                    focusObj = null;
                else
                { 
                    oldColor = focusObj.GetComponent<Renderer>().material.color;
                    focusObj.GetComponent<MeshCollider>().isTrigger = true;
                    focusObj.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
        if(focusObj)
        {
            focusObj.transform.parent = cam.transform;
            focusObj.transform.position = pos;
        }
        if (focusObj && Input.GetMouseButtonUp(0))
        {
            focusObj.transform.parent = imageTarget.transform;
            focusObj.GetComponent<Rigidbody>().isKinematic = false;
            focusObj.GetComponent<Rigidbody>().useGravity = true;
            focusObj.GetComponent<MeshCollider>().isTrigger = false;
            focusObj.GetComponent<Renderer>().material.color = oldColor;
            focusObj = null;
            ++currentScore;
        }
        scoreText.text = "SCORE: " + currentScore.ToString();

        if(gameOver)
            endGame();
    }

    public void startGame()
    {
        gameOver = false;
        startUI.SetActive(false);
        inGameUI.SetActive(true);
        endGameUI.SetActive(false);
        clickEnabled = true;
    }

    public void restartGame()
    {
        endGameUI.SetActive(false);
        SceneManager.LoadScene("Main Scene");
    }

    public void endGame()
    {
        startUI.SetActive(false);
        inGameUI.SetActive(false);
        endGameUI.SetActive(true);
        endScoreText.text = "SCORE: " + currentScore;
        gameOver = false;
        clickEnabled = false;
    }

}
