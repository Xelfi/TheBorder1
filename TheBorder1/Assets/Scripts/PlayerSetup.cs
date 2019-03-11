using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera sceneCamera;
    
    private void Start()
    {
        if (!isLocalPlayer)
        {
            //boucle pour désactiver les components des autres joueurs sur notre instance
            for(int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null) //si il y a une camera
            {
                Camera.main.transform.gameObject.SetActive(false); //récupérer la main camera et la desactiver (et donc désactiver l'audioListener)
            }
            
        }
    }

    private void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.transform.gameObject.SetActive(true); //réactiver la caméra quand le joueur déconnecte
        }
    }
}
