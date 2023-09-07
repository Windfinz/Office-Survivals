using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedBorder : MonoBehaviour
{
    [Header("Border")]
    public GameObject SelectedBorderPencil;
    public GameObject SelectedBorderPerfume;

    [SerializeField]
    public Button btnPencil;
    public Button btnPerfume;

    void Start()
    {
        btnPencil.onClick.AddListener(BorderPencilOn);
        btnPerfume.onClick.AddListener(BorderPerfumeOn);
        
    }

    void Awake()
    {
        SelectedBorderPencil.SetActive(false);
        SelectedBorderPerfume.SetActive(false);
    }

    void BorderPencilOn()
    {
        SelectedBorderPencil.SetActive(true);
        SelectedBorderPerfume.SetActive(false);
    }
    void BorderPerfumeOn()
    {
        SelectedBorderPencil.SetActive(false);
        SelectedBorderPerfume.SetActive(true);
    }
}
