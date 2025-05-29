namespace ConstructionManagementAssistant.Core.Identity;

public class RefreshToken
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public AppUser User { get; set; }

    public string Token { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime ExpiresOn { get; set; }
    public DateTime? RevokedOn { get; set; }

    //[NotMapped]
    public bool IsExpired => DateTime.UtcNow >= ExpiresOn;

    //[NotMapped]
    public bool IsActive => RevokedOn == null && !IsExpired;
}
