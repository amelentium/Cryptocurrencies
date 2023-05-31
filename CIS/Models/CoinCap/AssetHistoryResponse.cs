using System.Collections.Generic;

namespace CIS.Models.CoinCap;

public class AssetHistoryResponse
{
	public List<CurrencyHistoryValueModel>? Data { get; set; }
}