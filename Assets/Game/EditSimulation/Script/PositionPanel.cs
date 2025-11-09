using UnityEngine;
using TMPro;

public class PositionPanel : MonoBehaviour {
    public SimulationStore simulationStore;
    public TMP_Text positionText;

    public void Reload() {
        float segmentSize = simulationStore.segmentSize;
        int x = (int)(simulationStore.cursorPosition.x / segmentSize);
        int z = (int)(simulationStore.cursorPosition.z / segmentSize);
        positionText.text = $"X = {x}, Z = {z}";
    }
}
