using MainScene;
using MainView;
using SpriteCollections;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
{
    [SerializeField]
    private MainSceneConfig m_mainInstallerConfig;
    public override void InstallBindings()
    {
        Container.Bind<HumanSpriteCollection>().FromInstance(m_mainInstallerConfig.HumanSpriteCollection);
        Container.Bind<GeneralHumanVizualizerManager>().AsSingle();
    }
}
