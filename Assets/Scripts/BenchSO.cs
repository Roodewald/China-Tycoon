using UnityEngine;

[CreateAssetMenu(fileName = "BenchSO", menuName = "CreateBench", order = 1)]
public class BenchSO : ScriptableObject
{
	public string prefabName;
	public string discription;

	public Sprite icon;

	public int moneyCost;
	public int electricityCost;
	public int profit;

}
