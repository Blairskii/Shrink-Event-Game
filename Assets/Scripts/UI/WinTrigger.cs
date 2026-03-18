using UnityEngine;
using TMPro;

public class SimpleTriggerUI : MonoBehaviour
{
    public GameObject canvas; 
    public TMP_Text text;

    private void Start()
    {
        canvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
            text.text = "You Win";
        }
    }
}