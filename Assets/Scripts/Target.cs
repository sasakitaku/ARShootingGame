using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class Target : MonoBehaviour {
	[SerializeField]
    GameObject targetPrefab;
	public bool createtarget = false;
    void Update () {
        if(createtarget == false) {
            _executeHitTest ();
        }
    }
    private void _executeHitTest() {
        // 画面上のランダムな座標を元にARPointをセット
        var screenPosition = Camera.main.ScreenToViewportPoint(new Vector3 (Screen.width * Random.value, Screen.height * Random.value));
        ARPoint point = new ARPoint {
            x = screenPosition.x,
            y = screenPosition.y
        };

        // HitTestを実行する
        List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
        if (hitResults.Count > 0) {
            foreach (var hitResult in hitResults) {
                Vector3 position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
                _createTarget(position);
                break;
            }
        }
    }
    private void _createTarget(Vector3 position) {
        GameObject target = Instantiate (targetPrefab, position, Quaternion.identity); 
		createtarget = true; 
    }
}