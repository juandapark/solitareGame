using Gameplay.StackZone;
using Unity.Mathematics;
using UnityEngine;

namespace Core.Managers
{
    public class StackZoneManager : MonoBehaviour
    {
        [SerializeField] private StackZone[] stackZones;

        public void Initialise(GameObject cardPrefab)
        {
            InstantiateStackZone(cardPrefab);
        }

        private void InstantiateStackZone(GameObject cardPrefab)
        {
            for (int i = 0; i < stackZones.Length; i++)
            {
                Vector3 position = new Vector3(stackZones[i].transform.position.x, stackZones[i].transform.position.y, -1);
                Instantiate(cardPrefab, position, quaternion.identity, stackZones[i].transform).GetComponent<CardBase>()
                    .SetCardStack(stackZones[i]);
            }
        }
    }
}
