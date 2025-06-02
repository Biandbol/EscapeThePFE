using TMPro;
using UnityEngine;

public class sacrificeSystem : MonoBehaviour
{
    public TextMeshProUGUI hintText;

    [Header("Tag Configuration")]
    public string wheatTag = "Wheat";
    public string wineTag = "Wine";
    public string oilTag = "Oil";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(wheatTag))
        {
            ShowHint("The wheat will feed the earth—look to the tiles.");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag(wineTag))
        {
            ShowHint("The wine pleases the gods—listen closely to the notes.");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag(oilTag))
        {
            ShowHint("The oil burns bright—illuminate the ancient words.");
            Destroy(other.gameObject);
        }
    }

    private void ShowHint(string message)
    {
        hintText.text = message;
        hintText.gameObject.SetActive(true);
    }
}
