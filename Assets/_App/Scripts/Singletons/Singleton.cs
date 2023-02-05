using UnityEngine;

namespace Jackal
{
	/// <summary>
	/// Singleton pattern. And it will create new if not exist
	/// </summary>
	public class Singleton<T> : MonoBehaviour	where T : Component
	{
		protected static T _instance;

		/// <summary>
		/// Singleton design pattern
		/// </summary>
		/// <value>The instance.</value>
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindObjectOfType<T> ();
					if (_instance == null)
					{
						GameObject obj = new GameObject (typeof(T).Name);
						//obj.hideFlags = HideFlags.HideAndDontSave;
						_instance = obj.AddComponent<T> ();
					}
				}
				return _instance;
			}
		}

	    /// <summary>
	    /// On awake, we initialize our instance. Make sure to call base.Awake() in override if you need awake.
	    /// </summary>
	    protected virtual void Awake ()
		{
			if (!Application.isPlaying)
			{
				return;
			}

			_instance = this as T;			
		}
	}
}
