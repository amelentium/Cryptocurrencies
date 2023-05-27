using CIS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIS.Services
{
	public interface ICurrencyService
	{
		Task<List<CurrencyModel>?> GetAssets();
		Task<CurrencyModel?> GetAssetById(string id);
	}
}