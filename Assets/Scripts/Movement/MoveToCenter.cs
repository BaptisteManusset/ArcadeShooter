using UnityEngine;
using UnityEngine.AI;
namespace Movement {
	public class MoveToCenter : MonoBehaviour {
		NavMeshAgent m_meshAgent;
		
		private void Start() {
			m_meshAgent = GetComponent<NavMeshAgent>();
			m_meshAgent.SetDestination( Vector3.zero );
		}
	}
}