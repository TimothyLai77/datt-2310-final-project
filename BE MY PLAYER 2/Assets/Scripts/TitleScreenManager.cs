using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject logo;

    [SerializeField] private GameObject elementsToMove;

    [SerializeField] private GameObject centerAnchor;
    [SerializeField] private GameObject topAnchor;
    [SerializeField] private GameObject rightAnchor;
    [SerializeField] private GameObject bottomAnchor;
    [SerializeField] private GameObject leftAnchor;

    private Vector3 centerAnchorPosition = new Vector3();
    private Vector3 topAnchorPosition = new Vector3();
    private Vector3 rightAnchorPosition = new Vector3();
    private Vector3 bottomAnchorPosition = new Vector3();
    private Vector3 leftAnchorPosition = new Vector3();

    public static bool introShown;

    // Start is called before the first frame update
    void Start()
    {
        centerAnchorPosition = centerAnchor.transform.localPosition;
        topAnchorPosition = topAnchor.transform.localPosition;
        rightAnchorPosition = rightAnchor.transform.localPosition;
        bottomAnchorPosition = bottomAnchor.transform.localPosition;
        leftAnchorPosition = leftAnchor.transform.localPosition;

        LeanTween.rotateAround(logo, Vector3.forward, -360, 15f).setDelay(2f).setLoopClamp();
        introShown = false;




    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moveToCenter ()
    {
        LeanTween.moveLocal(elementsToMove, centerAnchorPosition, .7f).setDelay(.1f).setEase(LeanTweenType.easeInOutQuad);
    }
    public void moveToTop()
    {
        LeanTween.moveLocal(elementsToMove, topAnchorPosition, .7f).setDelay(.1f).setEase(LeanTweenType.easeInOutQuad);
    }
    public void moveToRight()
    {
        LeanTween.moveLocal(elementsToMove, rightAnchorPosition, .7f).setDelay(.1f).setEase(LeanTweenType.easeInOutQuad);
    }
    public void moveToBottom()
    {
        LeanTween.moveLocal(elementsToMove, bottomAnchorPosition, .7f).setDelay(.1f).setEase(LeanTweenType.easeInOutQuad);
    }
    public void moveToLeft()
    {
        LeanTween.moveLocal(elementsToMove, leftAnchorPosition, .7f).setDelay(.1f).setEase(LeanTweenType.easeInOutQuad);
    }

    public void toMainHubScene()
    {
        SceneManager.LoadScene("MainHub");
    }
}