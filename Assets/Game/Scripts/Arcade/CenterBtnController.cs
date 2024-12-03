
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CenterBtnController : MonoBehaviour
{
    private Button personBtn;
    private Button facilityBtn;
    private Button mapBtn;
    private Button funcBtn;
    void Awake()
    {
        personBtn = transform.Find("PersonBtn").GetComponent<Button>();
        facilityBtn = transform.Find("FacilityBtn").GetComponent<Button>();
        mapBtn = transform.Find("MapBtn").GetComponent<Button>();
        funcBtn = transform.Find("FuncBtn").GetComponent<Button>();
        personBtn.GetComponent<Image>().color = Color.gray;
        personBtn.onClick.AddListener(() =>
        {
            personBtn.GetComponent<Image>().color = Color.gray;
            facilityBtn.GetComponent<Image>().color = Color.white;
            mapBtn.GetComponent<Image>().color = Color.white;
            funcBtn.GetComponent<Image>().color = Color.white;
        });
        facilityBtn.onClick.AddListener(() =>
       {
           personBtn.GetComponent<Image>().color = Color.white;
           facilityBtn.GetComponent<Image>().color = Color.gray;
           mapBtn.GetComponent<Image>().color = Color.white;
           funcBtn.GetComponent<Image>().color = Color.white;
       });
        mapBtn.onClick.AddListener(() =>
       {
           personBtn.GetComponent<Image>().color = Color.white;
           facilityBtn.GetComponent<Image>().color = Color.white;
           mapBtn.GetComponent<Image>().color = Color.gray;
           funcBtn.GetComponent<Image>().color = Color.white;
       });
        funcBtn.onClick.AddListener(() =>
       {
           personBtn.GetComponent<Image>().color = Color.white;
           facilityBtn.GetComponent<Image>().color = Color.white;
           mapBtn.GetComponent<Image>().color = Color.white;
           funcBtn.GetComponent<Image>().color = Color.gray;
       });
    }
}