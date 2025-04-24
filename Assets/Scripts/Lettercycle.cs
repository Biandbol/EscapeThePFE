using System.Linq;
using TMPro;
using UnityEngine;

public class CycleLetter : MonoBehaviour
{

    private TMP_Text letterText;
    private int currentCharIndex = 0;
    private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    void Start()
    {
        letterText = GetComponent<TMP_Text>();
        currentCharIndex = alphabet.ToList().IndexOf(letterText.text[0]);
    }

    public void NextLetter()
    {
        currentCharIndex = (currentCharIndex + 1) % 26;
        letterText.text = alphabet[currentCharIndex].ToString();
    }

    public void PreviousLetter()
    {
        currentCharIndex = (currentCharIndex - 1 + 26) % 26;
        letterText.text = alphabet[currentCharIndex].ToString();
    }






}