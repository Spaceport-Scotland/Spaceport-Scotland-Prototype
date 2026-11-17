using System.Collections;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour //WIP
{
    //variables

    [Header("UI")]
    public TextMeshProUGUI requestText;

    [Header("TextTyping")] //controls speed of text typing out
    public float textSpeed = 0.02f;

    Coroutine currentTypingText;

    public void UpdateRequest(string request)
    {
        ShowDialogue(request);
    }//end of update

    public void ShowDialogue(string sentence)//check if typing is in effect, start + stops timer of sequence
    {
        if (currentTypingText != null)
        {
            StopCoroutine(currentTypingText);
            requestText.text = "";
        }

        currentTypingText = StartCoroutine(TypeSentence(sentence));
    }//end of ShowDialogue

    IEnumerator TypeSentence(string sentence) //typing feature
    {
        requestText.text = "";

        foreach (char letter in sentence)
        {
            requestText.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }
    }//end of TextSentence

    public void ClearRequest()
    {
        requestText.text = "";
    }

}//end of class
