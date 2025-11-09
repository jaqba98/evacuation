using UnityEngine;

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
    }

    public void Reload() {
        cursor.Reload();
        rotation.Reload();
        chooser.Reload();
        positionPanel.Reload();
        renderSegments.Reload();
    }

//     public SimulationStore simulationStore;
//     [Header("Services")]
//     public Signal signal;
//     public Cursor cursor;
//     public Chooser chooser;
//     public Rotate rotate;
//     public Segments segments;
//     public PositionPanel positionPanel;
//     public CameraController cameraController;
//     public SegmentManager segmentManager;
//     public void Start() {
//         Init();
//         Reload();
//     }
//     public void Init() {
//         segmentManager.Init(simulationStore);
//         segments.Init();
//     }
//     public void Reload() {
//         segments.Reload();
//         signal.Reload();
//         cursor.Reload();
//         chooser.Reload();
//         rotate.Reload();
//         positionPanel.Reload();
//         cameraController.Reload();
//     }
//     public void Exit() {
//         SceneManager.LoadScene("MainMenu");
//     }
//     public void Plus() {
//         if (simulationStore.cameraSize > 10) {
//             simulationStore.cameraSize -= 5;
//             Reload();
//         }
//     }
//     public void Minus() {
//         if (simulationStore.cameraSize < 100) {
//             simulationStore.cameraSize += 5;
//             Reload();
//         }
//     }
//     public void MoveLeft() {
//         simulationStore.segmentsDomain.ForEach(segmentDomain => segmentDomain.segmentPositionX -= 4);
//         segments.Init();
//     }
//     public void MoveRight() {
//         simulationStore.segmentsDomain.ForEach(segmentDomain => segmentDomain.segmentPositionX += 4);
//         segments.Init();
//     }
}
