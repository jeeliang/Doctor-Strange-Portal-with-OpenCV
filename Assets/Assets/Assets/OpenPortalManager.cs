using System.Collections.Generic;
using UnityEngine;

public class OpenPortalManager : MonoBehaviour
{
    public List<GameObject> openedPortals;
    // Update is called once per frame

    public void addPortalToList(GameObject newGeneratedPortal) {
        if (openedPortals.Count == 2) {
            openedPortals[0].GetComponentInChildren<PortalBehaviour>().portalDestruct();
            openedPortals.RemoveAt(0);
        }

        openedPortals.Add(newGeneratedPortal);

        if (openedPortals.Count == 2) {
            openedPortals[0].GetComponent<Portal>().screen.enabled=true;
            openedPortals[1].GetComponent<Portal>().screen.enabled=true;
            openedPortals[0].GetComponent<Portal>().linkedPortal = openedPortals[1].GetComponent<Portal>();
            openedPortals[1].GetComponent<Portal>().linkedPortal = openedPortals[0].GetComponent<Portal>();
        }
    }

    public void destroyAllPortals() {
        for (int counter = 0; counter < openedPortals.Count; counter++)
        {
            openedPortals[counter].GetComponentInChildren<PortalBehaviour>().portalDestruct();
        }

        openedPortals.Clear();
    }
}
