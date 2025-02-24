namespace UnalColombia.Common.Interfaces
{
    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }
        Guid CreatedUserId { get; set; }
        DateTime? LastUpdatedDate { get; set; }
        Guid? LastUpdatedUserId { get; set; }
    }
}
