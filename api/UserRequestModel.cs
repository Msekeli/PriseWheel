// UserRequestModel.cs
public class UserRequestModel
{
    public string UserId { get; set; }
    public DateTime RequestTime { get; set; }
}

// SpinResponseModel.cs
public class SpinResponseModel
{
    public int Angle { get; set; } // or whatever data your spin endpoint returns
}

// SpinAvailabilityResponseModel.cs
public class SpinAvailabilityResponseModel
{
    public bool CanSpin { get; set; }
}

