using UnityEngine;
using UnityEngine.UI;

/**
 * This component lets the player show/hide the cursor by clicking ESC.
 * Initially, it hides the cursor.
 */
public class CursorHider : MonoBehaviour {

    [SerializeField] private Image dialogImage1;
    [SerializeField] private Image dialogImage2;

    private bool flag;
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {


        if (flag && Cursor.visible && !dialogImage1.gameObject.activeSelf && !OptionsGame.menuIsActive && !dialogImage2.gameObject.activeSelf)
        {
            Debug.Log("Quit");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            flag = false;
            Debug.Log("Quittttttttttttttttttttttttttttt");
        }

        if (!flag && (OptionsGame.menuIsActive || dialogImage1.gameObject.activeSelf || dialogImage2.gameObject.activeSelf))
        {

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            flag = true;
            Debug.Log("Innnnnnnnnnnnnnnnnnnnn");


        }


    }
}
