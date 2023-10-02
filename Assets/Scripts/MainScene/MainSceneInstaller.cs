using MainScene;
using MainView;
using SpriteCollections;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
{
    [SerializeField]
    private MainSceneConfig m_mainInstallerConfig;

    [SerializeField] private StatesController _statesController;

    [SerializeField] private SpawnController _spawnController;

    [SerializeField] private CardModel _card;

    [SerializeField] private PcController _pcController;

    [SerializeField] private SanctionsController _sanctionsController;

    [SerializeField] private EndofDayController _endofDayController;

    public override void InstallBindings()
    {
        Container.Bind<HumanSpriteCollection>().FromInstance(m_mainInstallerConfig.HumanSpriteCollection);
        Container.Bind<GeneralHumanVizualizerManager>().AsSingle();
        Container.Bind<StatesController>().FromInstance(_statesController);
        Container.Bind<SpawnController>().FromInstance(_spawnController);
        Container.Bind<CardModel>().FromInstance(_card);
        Container.Bind<PcController>().FromInstance(_pcController);
        Container.Bind<SanctionsController>().FromInstance(_sanctionsController);
        Container.Bind<EndofDayController>().FromInstance(_endofDayController);
    }
}
