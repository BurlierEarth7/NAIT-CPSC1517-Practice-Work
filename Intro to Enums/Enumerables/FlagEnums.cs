namespace Enumerables;

// Create a public FlagAttribute Enum called FileOperations
// Add the values "None", "ReadOnly", "Hidden", "Compressed", and "Encrypted"
// Add the Base 2 Values, where None = 0, ReadOnly = 1, etc...

[Flags]
public enum FileOperations {
    None = 0,
    ReadOnly = 1,
    Hidden = 2,
    Compressed = 4,
    Encrypted = 8
}
