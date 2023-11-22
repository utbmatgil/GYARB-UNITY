using UnityEngine;
using UnityEngine.UI;

public class ToggleTextField : MonoBehaviour
{
    public GameObject textFieldObject;
    public GameObject YouWinText;
    public Transform door;
    public InputField NumPad;
    public GameObject InterText;
    private string Code;
    private string CorrectCode = "1234";

    void Start()
    {
        // Initially, set the Text Input Field to be inactive (not visible).
        textFieldObject.SetActive(false);
        InterText.SetActive(false);
    }

    void Update()
    {
        float dist = Vector3.Distance(door.position, transform.position);
        InterText.SetActive(false);

        if (dist < 2)
        {
            InterText.SetActive(true);
    
            if (Input.GetKeyDown(KeyCode.E))
            {
                textFieldObject.SetActive(true);
                NumPad.Select();
                NumPad.ActivateInputField();
            }

            else if (Input.GetKeyDown(KeyCode.Return))
            {
                textFieldObject.SetActive(false);
                NumPad.Select();
                Code = NumPad.text;
                Debug.Log(Code);
                if (Code == CorrectCode)
                {
                    Debug.Log("You Win");
                    YouWinText.SetActive(true);
                }
                else
                {
                    Debug.Log("You Loose");
                }
                NumPad.text = "";
                
            }
        }
    }
}
