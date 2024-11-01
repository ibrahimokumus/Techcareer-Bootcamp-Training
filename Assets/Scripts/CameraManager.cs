
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Camera[] cameras;
    int currentActiveCameraIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Camera c in cameras) 
        {
            c.gameObject.SetActive(false);// her kamerayi kapatiyoruz, acik varsa
        }
        cameras[currentActiveCameraIndex].gameObject.SetActive(true);// ilk kamerayi defaul kullanilan yaptik
    }

    void Update()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1+i))
            {
                ActivateCamera(i);
                break;
            }

        }

    }

    /// <summary>
    /// ilgili kameraya aktif kamera yapar
    /// </summary>
    /// <param name="index"> aktif olcak kamera indisi</param>
    void ActivateCamera(int newCameraIndex)
    {
        if (currentActiveCameraIndex == newCameraIndex)  return; // zaten kullanimda olan index gonderilmisse, islem yapma
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == newCameraIndex)
            {
                cameras[i].gameObject.SetActive(true); // yeni kamerayi aktiflestir
                cameras[currentActiveCameraIndex].gameObject.SetActive(false);//eski kamerayi kapat
                currentActiveCameraIndex = i; // yeni aktif olan  kamera indisini al
            }
        }
    }
}
