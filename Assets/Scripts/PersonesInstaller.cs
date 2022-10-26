using UnityEngine;
using Zenject;

public class PersonesInstaller : MonoInstaller
{
    [SerializeField] private GameObject mageObject;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject player;
  
    public override void InstallBindings()
    {
        Container.Bind<MageController>().FromComponentOn(mageObject).AsSingle();
        Container.Bind<GameManager>().FromComponentOn(gameManager).AsSingle();
        Container.Bind<PlayerController>().FromComponentOn(player).AsSingle();
    }
}