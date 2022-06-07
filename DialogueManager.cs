using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Ink.Runtime;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Text dialogueText;
    public GameObject defaultCircle;
    [SerializeField] private GameObject[] choices;
    private Text[] choicesText;
    private Story currentStory;
    private bool dialogueIsPlaying;
    private static GameObject cameraToActivate;
    private static GameObject player;
    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("WARNING: Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance(GameObject _cameraToActivate, GameObject _player)
    {
        cameraToActivate = _cameraToActivate;
        player = _player;
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;

        choicesText = new Text[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<Text>();
            index++;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        defaultCircle.SetActive(false);
        cameraToActivate.SetActive(true);
        player.SetActive(false);

        ContinueStory();
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && currentStory.currentChoices.Count == 0 && !PauseMenu.GameIsPaused)
        {
            ContinueStory();
        }
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        defaultCircle.SetActive(true);
        cameraToActivate.SetActive(false);
        player.SetActive(true);
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        DisplayChoices();
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentStory.Continue()));
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        if (currentStory.currentChoices.Count > choices.Length)
        {
            Debug.Log("WARNING: More choices were given than the UI can support. Number of choices given: " + currentStory.currentChoices.Count);
        }

        int index = 0;

        foreach(Choice choice in currentStory.currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        int index = 0;
        foreach (Choice choice in currentStory.currentChoices)
        {
            choices[index].gameObject.SetActive(false);
            index++;
        }
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

}
