using UnityEngine;
using UnityEngine.UI;

public class NoteReaderScript : MonoBehaviour
{
    public GameObject Note1Text;
    public GameObject NotePaperBackground;
    public Transform Note1;
    public GameObject IntereactText;
    public Transform player;

    void Start()
    {
        Note1Text.SetActive(false);
        NotePaperBackground.SetActive(false);

    }

    void Update()
    {
        float dist = Vector3.Distance(Note1.position, player.position);

        if (dist < 2)
        {
            IntereactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Note1Text.SetActive(true);
                NotePaperBackground.SetActive(true);
            }
        }
        else if (dist > 2)
        {
            IntereactText.SetActive(false);
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
