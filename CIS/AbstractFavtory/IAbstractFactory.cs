namespace CIS.AbstractFavtory
{
	public interface IAbstractFactory<T> where T : class
	{
		T Create();
	}
}