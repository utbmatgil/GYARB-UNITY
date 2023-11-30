using UnityEngine;
using UnityEngine.UI;

public class NoteReaderScript : MonoBehaviour
{
    public GameObject Note1Text;
    public GameObject NotePaperBackground;
    public Transform Note1;
    public GameObject InterText;

    void Start()
    {
        Note1Text.SetActive(false);
        NotePaperBackground.SetActive(false);

    }

    void Update()
    {
        float dist = Vector3.Distance(Note1.position, transform.position);
        if (dist < 2)
        {
            InterText.SetActive(true);

        }

    }
}
