namespace RacMAN.API;

/// <summary>
/// Abstraction for any API that allows reading/writing memory to a game
/// </summary>
public abstract class MemoryAPI
{
    /// <summary>
    /// Get the unique game title ID, such as NPEA00385
    /// </summary>
    /// <returns>Returns a 9 character long string with 4 letters followed by 5 numbers.</returns>
    public abstract string GetGameTitleID();

    /// <summary>
    /// Gets the human-readable name for the current game.
    /// </summary>
    /// <returns>game name</returns>
    public abstract string GetGameTitle();

    public abstract byte[] ReadMemory(uint addr, uint size);

    public abstract void WriteMemory(uint addr, byte[] bytes);

    /// <summary>
    /// Subscribe to a remote memory address, so the value is sent every time it is changed.
    /// </summary>
    /// <param name="addr"></param>
    /// <param name="size"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public abstract int SubMemory(uint addr, uint size, Action<byte[]> callback);

    public abstract int FreezeMemory(uint addr, byte[] value);

    public abstract void ReleaseSubID(int id);

    /// <summary>
    /// Show a message box on the server. Maybe should be deleted
    /// because it kinda only exists on ratchetron
    /// </summary>
    /// <param name="text">The message to be displayed</param>
    public abstract void Notify(string text);

    /// <summary>
    /// Disconnect the API and free all resources used.
    /// </summary>
    public abstract void Disconnect();

    public event EventHandler GameChanged;
}

/// <summary>
/// The type of API that is connected
/// </summary>
public enum APIType
{
    /// <summary>
    /// Not connected to anything, API is null.
    /// </summary>
    None,
    /// <summary>
    /// Ratchetron API for PS3 console
    /// </summary>
    PS3,

    /// <summary>
    /// RPCS3 PS3 Emulator
    /// </summary>
    RPCS3,

    /// <summary>
    /// PCSX2 PS2 Emulator
    /// </summary>
    PCSX2
}
