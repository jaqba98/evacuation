using UnityEngine;
using System.IO;
using UnityEngine.AI;
using System.Collections.Generic;

public class OfficeBuilder : MonoBehaviour {
    public string fileName;

    public NavMeshSurface surfaceManager;

    public GameObject segmentFloorPrefab;

    public GameObject segmentWallPrefab;

    public GameObject segmentDoorPrefab;

    public GameObject agentPrefab;

    public GameObject exitPrefab;

    private List<GameObject> agents = new List<GameObject>();

    private List<GameObject> exits = new List<GameObject>();

    GameObject tilePrefab;

    [System.Serializable]
    public class OfficeTile {
        public string type;
        public int posX;
        public int posY;
        public bool spawn;
        public bool exit;
    }

    [System.Serializable]
    public class Office {
        public string name;
        public OfficeTile[] tiles;
    }

    void Start() {
        Office office = ReadOffice();
        RenderTiles(office.tiles);
        RebuildNavMesh();
        SpawnExits();
        SpawnAgents();
    }

    private Office ReadOffice() {
        if (fileName == "") {
            throw new System.Exception($"File name has not been specified!");
        }
        string path = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(path)) {
            string jsonText = File.ReadAllText(path);
            Office data = JsonUtility.FromJson<Office>(jsonText);
            Debug.Log($"File has been read: {path}");
            return data;
        } else {
            throw new System.Exception($"Failed to read file: {path}");
        }
    }

    public void RenderTiles(OfficeTile[] tiles) {
        foreach (OfficeTile tile in tiles) {
            int posX = tile.posX;
            int posY = tile.posY;
            Vector3 vector3 = new Vector3(posX, 0, posY);
            Quaternion quaternion = Quaternion.identity;
            if (tile.type == "floor") {
                tilePrefab = segmentFloorPrefab;
            } else if (tile.type == "wall") {
                tilePrefab = segmentWallPrefab;
            } else if (tile.type == "door") {
                tilePrefab = segmentDoorPrefab;
            }
            GameObject tileObject = Instantiate(tilePrefab, vector3, quaternion);
            tileObject.name = $"tile_{posX}x{posY}";
            if (tile.spawn) {
                RenderAgent(tile.posX, tile.posY);
            }
            if (tile.exit) {
                RenderExit(tile.posX, tile.posY);
            }
        }
    }

    public void RenderAgent(int posX, int posY)
    {
        GameObject placeholder = new GameObject($"agent_{posX}x{posY}");
        placeholder.transform.position = new Vector3(posX, 2, posY);
        agents.Add(placeholder);
    }

    public void SpawnAgents()
    {
        foreach (GameObject placeholder in agents)
        {
            Vector3 pos = placeholder.transform.position;
            GameObject agentObj = Instantiate(agentPrefab, pos, Quaternion.identity);
            agentObj.name = placeholder.name;
            NavMeshAgent agent = agentObj.GetComponent<NavMeshAgent>();
            Destroy(placeholder);
        }
    }

     public void RenderExit(int posX, int posY)
    {
        GameObject placeholder = new GameObject("exit");
        placeholder.transform.position = new Vector3(posX, 2, posY);
        exits.Add(placeholder);
    }

    public void SpawnExits()
    {
        foreach (GameObject placeholder in exits)
        {
            Vector3 pos = placeholder.transform.position;
            GameObject agentObj = Instantiate(exitPrefab, pos, Quaternion.identity);
            agentObj.name = placeholder.name;
            NavMeshAgent agent = agentObj.GetComponent<NavMeshAgent>();
            Destroy(placeholder);
        }
    }

    public void RebuildNavMesh() {
        surfaceManager.BuildNavMesh();
    }
}
