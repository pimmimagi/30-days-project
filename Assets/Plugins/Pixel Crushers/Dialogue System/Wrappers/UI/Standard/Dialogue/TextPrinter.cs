using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UniRx;

public class TextPrinter : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] TMP_Text tmpProText;
    private string writer;
    [SerializeField] private Coroutine coroutine;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;
    [Space(10)]
    [SerializeField] private bool startOnEnable = false;

    [Header("Collision-Based")]
    [SerializeField] private bool clearAtStart = false;
    [SerializeField] private bool startOnCollision = false;
    enum options { clear, complete }
    [SerializeField] options collisionExitOptions;

    [SerializeField] public UnityEvent OnTextPrinted; // Event to notify when text printing is done.

    void Start()
    {
        if (!clearAtStart) return;
        ClearText();
    }

    private void OnEnable()
    {
        if (startOnEnable) StartTypewriter();
    }

    public void SetWriterText(string textToWrite)
    {
        writer = textToWrite;
    }

    public void StartTypewriter()
    {
        ClearText();
        StopAllCoroutines();

        Observable.NextFrame().Subscribe(onNextFrame =>
        {
            if (text != null && this.gameObject.activeInHierarchy) StartCoroutine(TypeWriterText());
            if (tmpProText != null) StartCoroutine(TypeWriterTMP());
        }).AddTo(this);
    }

    public void ClearText()
    {
        if (text != null) text.text = "";
        if (tmpProText != null) tmpProText.text = "";
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator TypeWriterText()
    {
        text.text = leadingCharBeforeDelay ? leadingChar : "";
        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            text.text = text.text.Substring(0, text.text.Length - leadingChar.Length);
            text.text += c + leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        text.text = text.text.Substring(0, text.text.Length - leadingChar.Length);
        OnTextPrinted?.Invoke();
    }

    IEnumerator TypeWriterTMP()
    {
        tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";
        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            tmpProText.text = tmpProText.text.Substring(0, tmpProText.text.Length - leadingChar.Length);
            tmpProText.text += c + leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        tmpProText.text = tmpProText.text.Substring(0, tmpProText.text.Length - leadingChar.Length);
        OnTextPrinted?.Invoke();
    }
}