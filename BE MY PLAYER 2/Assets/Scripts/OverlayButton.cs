using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class OverlayButton : MonoBehaviour
{
    public GameObject overlayPanel;

    private void Start()
    {
        overlayPanel.SetActive(false);
    }

    public void ShowOverlay()
    {
        overlayPanel.SetActive(true);

        // Disable all other buttons in the scene
        // DisableOtherButtons();
    }

    public void HideOverlay()
    {
        overlayPanel.SetActive(false);

        // Enable all other buttons in the scene
        //EnableOtherButtons();
    }

    public void CloseButton()
    {
        HideOverlay();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideOverlay();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject != overlayPanel && overlayPanel.activeSelf)
                {
                    HideOverlay();
                }
            }
        }
    }

    //ignore
    //private void DisableOtherButtons()
    //{
        // Find all the clickable buttons in the scene
        //var buttons = FindObjectsOfType<Button>().Where(b => b.interactable).ToArray();

        // Disable all the buttons except for the one that opened the overlay
        //foreach (Button button in buttons)
        //{
            //if (button.gameObject != gameObject)
            //{
              //  button.interactable = false;
            //}
        //}
   // }

   // private void EnableOtherButtons()
    //{
        // Find all the clickable buttons in the scene
       // var buttons = FindObjectsOfType<Button>().Where(b => b.interactable).ToArray();

        // Enable all the buttons except for the one that opened the overlay
       // foreach (Button button in buttons)
       // {
         //   if (button.gameObject != gameObject)
          //  {
                //button.interactable = true;
          //  }
        //}
    //}
}