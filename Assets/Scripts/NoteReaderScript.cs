using UnityEngine;
using UnityEngine.UI;

public class NoteReaderScript : MonoBehaviour
{
    public GameObject Note1Text;
    public GameObject NotePaperBackground;
    public Transform Note1;

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

            if (Input.GetKeyDown(KeyCode.E))
            {
                Note1Text.SetActive(true);
                NotePaperBackground.SetActive(true);
            }
        }
        else if (dist > 2)
        {
            Note1Text.SetActive(false);
            NotePaperBackground.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Note1Text.SetActive(false);
            NotePaperBackground.SetActive(false);
        }
    }

}
