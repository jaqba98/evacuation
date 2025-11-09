using UnityEngine;
using System.Collections.Generic;

public class SimulationStore : MonoBehaviour {
    public float segmentSize;
    public Vector3 cursorPosition;
    public Vector3 cursorRotation;
    public List<GameObject> segments;
    public int currentSegmentIndex;
    public GameObject currentSegment;
    public List<SegmentDomain> segmentDomains;
    public string path;
    public int cameraSize;
    public bool canBuildSegment;
    public int maxCursorPositionLeft;
    public int maxCursorPositionRight;
    public int maxCursorPositionUp;
    public int maxCursorPositionDown;

    // [Header("Store Variables")]
    // public string simulationName;
    // public string simulationType;
    // public int simulationTimer;
    // public SimulationDomain simulationDomain;
    // public bool canBuildSegment;
    // public float cursorPositionX;
    // public float cursorPositionZ;
    // public bool frozen;
    // public int currentSegment;
    // public GameObject currentSegmentPrefab;
    // public float cursorRotation;
    // public List<SegmentDomain> segmentsDomain;
    // public List<GameObject> spawns;
    // public List<GameObject> exits;
    // public int people;
    // public int survivors;
    // public float panic;
    // public int cameraSize;
    // public int currentAgent = 0;
    // public List<GameObject> agents;
    // public List<GameObject> segments;

    // public void Awake() {
    //     Debug.Log(PlayerPrefs.GetString("simulationData"));
    //     simulationName = PlayerPrefs.GetString("simulationName");
    //     simulationType = PlayerPrefs.GetString("simulationType");
    //     string timerString = PlayerPrefs.GetString("simulationTimer", "");
    //     if (!int.TryParse(timerString, out simulationTimer)) {
    //         simulationTimer = 30;
    //     }
    //     simulationDomain = JsonUtility.FromJson<SimulationDomain>(PlayerPrefs.GetString("simulationData"));
    //     canBuildSegment = true;
    //     cursorPositionX = simulationDomain.cursorPositionX;
    //     cursorPositionZ = simulationDomain.cursorPositionZ;
    //     frozen = false;
    //     currentSegment = 0;
    //     cursorRotation = simulationDomain.cursorRotation;
    //     segmentsDomain = simulationDomain.segments;
    //     survivors = 0;
    //     string panicString = PlayerPrefs.GetString("simulationPanic", "0.5");
    //     if (float.TryParse(panicString, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float parsedPanic)) {
    //         panic = Mathf.Clamp01(parsedPanic);
    //     } else {
    //         panic = 0.5f;
    //     }
    //     cameraSize = simulationDomain.cameraSize;
    // }
}
