using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    // �O�o�[�o��


public class NewBehaviourScript : MonoBehaviour
{

    public Text questionText;
    public Text resultText;
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public Text TextA;
    public Text TextB;
    public Text TextC;
    public Text TextD;
    private List<Question> questions;
    private int currentQuestionIndex = 0;
    void Start()
    {
        
        // ��l�ư��D
        InitializeQuestions();

        // ��ܲĤ@�Ӱ��D
        ShowQuestion();

        buttonA.onClick.AddListener(MyButtonClickA);
        buttonB.onClick.AddListener(MyButtonClickB);
        buttonC.onClick.AddListener(MyButtonClickC);
        buttonD.onClick.AddListener(MyButtonClickD);


    }
    void InitializeQuestions()
    {
        questions = new List<Question>();

        // �[�J���D
        questions.Add(new Question(
            "���өu�`�O�˵����D�n�ͪ����H",
            new Dictionary<char, string>
            {
                {'A', "�K�u"},
                {'B', "�L�u"},
                {'C', "��u"},
                {'D', "�V�u"}
            },
            'A'));

        questions.Add(new Question(
            "�˵��O�q�ˤl�����ӳ����ͪ��X�Ӫ��H",
            new Dictionary<char, string>
            {
                {'A', "�˸�"},
                {'B', "�˸`"},
                {'C', "�a�U�ڲ�"},
                {'D', "�˷F"}
            },
            'C'));

        questions.Add(new Question(
            "�U�C��̫D�˵��H",
            new Dictionary<char, string>
            {
                {'A', "��˵�"},
                {'B', "�t�յ�"},
                {'C', "�ۦ˵�"},
                {'D', "�b��"}
            },
            'B'));
    }
    void ShowQuestion()
    {
        // ��ܰ��D���e
        questionText.text = questions[currentQuestionIndex].Content;
        int index = 0;
        foreach (var option in questions[currentQuestionIndex].Options)
        {

            GameObject answerText = GameObject.Find("Text" + option.Key);
            answerText.GetComponentInChildren<Text>().text = option.Value;
            index++;
        }
    }
    void MyButtonClickA()
    {
        CheckAnswer('A');
    }
    void MyButtonClickB()
    {
        CheckAnswer('B');
    }
    void MyButtonClickC()
    {
        CheckAnswer('C');
    }
    void MyButtonClickD()
    {
        CheckAnswer('D');
    }
    void Update()
    {
        

        //ResetButtons();
    }
  
    public void CheckAnswer(char selectedOption)
    {
        
        if (questions[currentQuestionIndex].CheckAnswer(selectedOption))
        {
            resultText.text = "����F�I";
            NextQuestion();

        }
        else
        {
            resultText.text = $"�����F�A���T���׬O {questions[currentQuestionIndex].Options[questions[currentQuestionIndex].CorrectAnswer]}";
        }
    }
    public void NextQuestion()
    {
        // ���ܤU�@�Ӱ��D
        currentQuestionIndex++;

        // �ˬd�O�_�w�g�^�����Ҧ����D
        if (currentQuestionIndex < questions.Count)
        {
            // ��ܤU�@�Ӱ��D
            resultText.text="~~�е��D~~";
            ShowQuestion();

        }
        else
        {
            // �Y�w�^�����Ҧ����D�A�i�H�b�o�̳B�z�����C�����޿�
            Debug.Log("�w�^�����Ҧ����D�I");
        }
    }
    void ResetButtons()
    {

        buttonA.interactable = true; // ���m���s���i�椬���A�]�i�Q�I���^
        buttonA.onClick.RemoveAllListeners(); // �����Ҧ����s�I���ƥ��ť��
        buttonB.interactable = true; // ���m���s���i�椬���A�]�i�Q�I���^
        buttonB.onClick.RemoveAllListeners(); // �����Ҧ����s�I���ƥ��ť��
        buttonC.interactable = true; // ���m���s���i�椬���A�]�i�Q�I���^
        buttonC.onClick.RemoveAllListeners(); // �����Ҧ����s�I���ƥ��ť��
        buttonD.interactable = true; // ���m���s���i�椬���A�]�i�Q�I���^
        buttonD.onClick.RemoveAllListeners(); // �����Ҧ����s�I���ƥ��ť��


    }
    //void Update()
    //{
    //    //Press the space key to change the Text message
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        m_MyText.text = "My text has now changed.";
    //    }
    //}
}
public class Question
{
    public string Content { get; set; }
    public Dictionary<char, string> Options { get; set; }
    public char CorrectAnswer { get; set; }

    public Question(string content, Dictionary<char, string> options, char correctAnswer)
    {
        Content = content;
        Options = options;
        CorrectAnswer = correctAnswer;
    }

    public bool CheckAnswer(char selectedOption)
    {
        return char.ToUpper(selectedOption) == char.ToUpper(CorrectAnswer);
    }
}