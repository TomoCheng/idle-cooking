using Cysharp.Threading.Tasks;
using Tomo.Core;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	// Public
	public override async UniTask Initialize()
	{
		await base.Initialize();
		if (_managerList.Length == 0)
		{
			Debug.LogError("No managers found in GameManager");
		}
		foreach (var manager in _managerList)
		{
			await manager.Initialize();
		}
		//Test
		Tomo.UI.UIManager.Instance.BootView<Kitchen.UI.View_Kitchen>("View_Kitchen", Tomo.UI.ViewLayer.DEFAULT);
	}

	// Private
	private void Awake()
	{
		Initialize().Forget();
	}

	// Serialized properties
	[SerializeField] private SingletonBase[] _managerList;
}
