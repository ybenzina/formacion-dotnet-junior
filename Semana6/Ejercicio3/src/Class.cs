using System;

namespace Downloader;

internal class CacheManager
{
    private static CacheManager? s_cacheManager;

    private CacheManager()
    {

    }

    public static CacheManager Instance
	{
		get
		{
			if (s_cacheManager == null)
			{
				s_cacheManager = new CacheManager();
			}
			return s_cacheManager;
		}
	}

	private readonly Dictionary<string, object> _keyValuePairs = new Dictionary<string, object>();

	public void AddToCache(string key, object value)
	{
		_keyValuePairs[key] = value;
	}

	public object? GetFromCache(string key)
	{
		_keyValuePairs.TryGetValue(key, out object? value);
		return value;
	}
}
