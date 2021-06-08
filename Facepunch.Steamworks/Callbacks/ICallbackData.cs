namespace Steamworks
{
	/// <summary>
	/// Gives us a generic way to get the CallbackId of structs
	/// </summary>
	public interface ICallbackData
	{
		CallbackType CallbackType { get; }
		int DataSize { get; }
	}
}