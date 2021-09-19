namespace Common.Phase
{
	public interface IPhaseSolver<T>
	{
		T GetNext(T phase);
	}
}
