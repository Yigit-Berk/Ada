using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DiyalogYonetimi : MonoBehaviour
{
    public static DiyalogYonetimi Instance;

	public Image karakterIcon;
	public TextMeshProUGUI karakterAdi;
    public TextMeshProUGUI diyalogYazisi;
	public GameObject diyalogGorunum;

    private Queue<DiyalogAlani> satirlar;
    
	public bool diyalogAktiflik = false;

	public float yaziHizi = 0.2f;


	//awake an�nda
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

		satirlar = new Queue<DiyalogAlani>();

		diyalogGorunum.SetActive(false);//ba�lang��ta g�r�nmez olsun
    }

	public void DiyalogBaslat(Dialogue dialogue)
	{
		diyalogAktiflik = true;
		diyalogGorunum.SetActive(true);//trigger an�nda g�r�n�r olsun

		satirlar.Clear();

		foreach (DiyalogAlani dialogueLine in dialogue.diyalogSatirlari)//di�er script i�indeki alana eri�im
		{
			satirlar.Enqueue(dialogueLine);
		}

        SonrakiDiyaloguGoster();
	}

	public void SonrakiDiyaloguGoster()
	{
		if (satirlar.Count == 0)
		{
            DiyalogBitir();//diyalog yoksa bitir
			return;
		}

		DiyalogAlani mevcutSatir = satirlar.Dequeue();

		//trigger'daki karakter icon ve isim de�erleri
		karakterIcon.sprite = mevcutSatir.karakter.icon;//konu�an karakterin ikonu g�r�ns�n
		karakterAdi.text = mevcutSatir.karakter.isim;//konu�an karakterin ad� g�r�ns�n

		StopAllCoroutines();

		StartCoroutine(TypeSentence(mevcutSatir));
	}

	IEnumerator TypeSentence(DiyalogAlani dialogueLine)
	{
		diyalogYazisi.text = "";
		foreach (char letter in dialogueLine.satir.ToCharArray())
		{
			diyalogYazisi.text += letter;
			yield return new WaitForSeconds(yaziHizi);//yaz�lacak karakter say�s�
		}
	}

	void DiyalogBitir()
	{
		diyalogAktiflik = false;
		Debug.Log("DaiyalogBitti");
		diyalogGorunum.SetActive(false);//g�r�nmez olsun
	}
}
