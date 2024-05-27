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


	//awake anýnda
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

		satirlar = new Queue<DiyalogAlani>();

		diyalogGorunum.SetActive(false);//baþlangýçta görünmez olsun
    }

	public void DiyalogBaslat(Dialogue dialogue)
	{
		diyalogAktiflik = true;
		diyalogGorunum.SetActive(true);//trigger anýnda görünür olsun

		satirlar.Clear();

		foreach (DiyalogAlani dialogueLine in dialogue.diyalogSatirlari)//diðer script içindeki alana eriþim
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

		//trigger'daki karakter icon ve isim deðerleri
		karakterIcon.sprite = mevcutSatir.karakter.icon;//konuþan karakterin ikonu görünsün
		karakterAdi.text = mevcutSatir.karakter.isim;//konuþan karakterin adý görünsün

		StopAllCoroutines();

		StartCoroutine(TypeSentence(mevcutSatir));
	}

	IEnumerator TypeSentence(DiyalogAlani dialogueLine)
	{
		diyalogYazisi.text = "";
		foreach (char letter in dialogueLine.satir.ToCharArray())
		{
			diyalogYazisi.text += letter;
			yield return new WaitForSeconds(yaziHizi);//yazýlacak karakter sayýsý
		}
	}

	void DiyalogBitir()
	{
		diyalogAktiflik = false;
		Debug.Log("DaiyalogBitti");
		diyalogGorunum.SetActive(false);//görünmez olsun
	}
}
