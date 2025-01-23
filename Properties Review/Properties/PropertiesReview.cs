namespace Properties;

public class PropertiesReview
{

    #region AutoImplemented
    // Write an auto-implemented string property named "FirstName". Make it read and write accessible
    // Also give FirstName a default value of "Rebecca"
    public string FirstName { get; set; } = "Rebecca";
    #endregion AutoImplemented


    #region FullyImplemented
    // Write a fully-implemented string property named "LastName". Make it read and write accessible
    // Use a private variable named _LastName to manage your data
    // Add verification to make sure that it is not null or whitespace
    // If the given value is null, or whitespace, throw an ArgumentNullException
    // Trim your value before setting it to your variable
    private string _LastName;
    public string LastName
    {
        get => _LastName;
        set {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException();
            //We always trim our data as there is a risk that it was not done when the data was entered by the user
            //or that extra whitespace was added somewhere along the line.
            _LastName = value.Trim();
        }
    }
        #endregion ManuallyImplemented
    }
