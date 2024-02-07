using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHUDManager : MonoBehaviour
{
    [Header("Math")]
    [SerializeField] GameObject mathCanvasGO;
    [SerializeField] GameObject questionAndAnswersGO;

    [SerializeField] Slider leftTimer;
    [SerializeField] Slider rightTimer;
    [SerializeField] TextMeshProUGUI questionText;
	[SerializeField] TextMeshProUGUI answer1ButtonText;
	[SerializeField] TextMeshProUGUI answer2ButtonText;
	[SerializeField] TextMeshProUGUI answer3ButtonText;
	[SerializeField] TextMeshProUGUI answer4ButtonText;

    public void showMathCanvas() { mathCanvasGO.SetActive(true); }
    public void hideMathCanvas() { mathCanvasGO.SetActive(false); }
    public void showQuestionAndAnswers() {  questionAndAnswersGO.SetActive(true); }
    public void hideQuestionAndAnswers() { questionAndAnswersGO.SetActive(false); }
}
