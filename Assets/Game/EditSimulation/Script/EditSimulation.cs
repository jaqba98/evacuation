using UnityEngine;
using UnityEngine.SceneManagement;

public class EditSimulation : MonoBehaviour {
    public DomainManager domainManager;
    public SimulationCommon simulationCommon;
    public Cursor cursor;
    public Rotation rotation;
    public Chooser chooser;
    public Create create;
    public RenderSegments renderSegments;
    public PositionPanel positionPanel;
    public SegmentManager segmentManager;
    public CameraSize cameraSize;

    public void Start() {
        PreInit();
        Init();
        Reload();
    }

    public void PreInit() {
        domainManager.PreInit();
    }

    public void Init() {
        simulationCommon.Init();
        cursor.Init();
        rotation.Init();
        chooser.Init();
        create.Init();
        segmentManager.Init();
        cameraSize.Init();
        renderSegments.Init();
    }

    public void Reload() {
        cursor.Reload();
        rotation.Reload();
        chooser.Reload();
        positionPanel.Reload();
        renderSegments.Reload();
        cameraSize.Reload();
    }

    public void Exit() {
        SceneManager.LoadScene("MainMenu");
    }
}
