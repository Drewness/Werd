namespace Backend.Enumerations
{
    public enum ReturnStatus
    {
        Accepted = 0,
        Rejected = 1,
        ReadyToRelease = 2,
        CchReview = 3,
        SchemaValidationError = 4,
    }
}