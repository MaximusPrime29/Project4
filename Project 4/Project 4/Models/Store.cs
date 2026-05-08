using System;

public class Store
{
	public int StoreId { get; set; }
	public string StoreName { get; set; }
	public string StoreLocation { get; set; }

	public Store( int storeId, string storeName, string storeLocation)
	{
		StoreId = storeId;
		StoreName = storeName;
		StoreLocation = storeLocation;
	}
}
