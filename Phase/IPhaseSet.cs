namespace Common.Phase
{
	public interface IPhaseSet<T>
	{
		IPhase GetPhase(T currentPhase);
	}
}