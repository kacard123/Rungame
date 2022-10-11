using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestRenderer : MonoBehaviour
{
    [System.Serializable]
    public class QuestDataProperty
    {
        public Sprite sprite;
        public string description;
    }

    public Button previousPageButton, nextPageButton;
    public Image questImg;
    public TextMeshProUGUI descriptionTxt;

    public List<QuestDataProperty> questData;

    int currentPage; //=0초기값 / 이 변수로 현재 몇 페이지에 있는지를 담는다

    void Start()
    {
        UpdateUI();
    }


    //현재 페이지에 맞는 버튼의 상태를 넣는다
    //다음에 넘어갈 페이지가 있어야 버튼에 불이 들어오게
    void UpdateUI()
    {   //현재 페이지 앞에 데이터의 유무
        //false가 들어오면 interactable이 안 됨
        previousPageButton.interactable = currentPage > 0;
        nextPageButton.interactable = currentPage < questData.Count - 1;
        //다음으로 이동할 페이지가 있다는 의미
        UpdateContent();
    }
    //현재 페이지에 맞는 콘텐츠 띄우기
    void UpdateContent()
    {
        //questData 가장 앞에있는 요소의 스프라이트가 들어가게 됨
        questImg.sprite = questData[currentPage].sprite;

        StopAllCoroutines(); //코루틴함수가 작동->다시 첨부터 호출해야함...?->취소처리
        StartCoroutine(AppearTextOneByOne(0.05f));//시간차는 ~초 /  새로 다시 호출
    }

    IEnumerator AppearTextOneByOne(float interval)
    {
        int index = 1;
        //현재 출력해야 할 문자 -> questData의 currentPage
        string description = questData[currentPage].description;

        while (index <= description.Length)
        {
            descriptionTxt.text = description.Substring(0, index); //0~index 빼낸다
            yield return new WaitForSeconds(interval); //interval만큼 실행하다 대기 / 시간차주기
            index++;

        }
    }

    //버튼을 클릭하면 다음 페이지로 이동
    public void OnClickPrevButton()
    {
        Debug.Log("click prev button");

        currentPage--;

        UpdateUI();
    }

    public void OnClickNextButton()
    {
        Debug.Log("click next button");

        currentPage++;

        UpdateUI();
    }
}