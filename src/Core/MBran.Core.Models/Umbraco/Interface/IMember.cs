namespace MBran.Core.Models
{
    public partial interface IMember
    {
        bool UmbracoMemberApproved { get; set; }
        string UmbracoMemberComments { get; set; }
        string UmbracoMemberFailedPasswordAttempts { get; set; }
        string UmbracoMemberLastLockoutDate { get; set; }
        string UmbracoMemberLastLogin { get; set; }
        string UmbracoMemberLastPasswordChangeDate { get; set; }
        bool UmbracoMemberLockedOut { get; set; }
        string UmbracoMemberPasswordRetrievalAnswer { get; set; }
        string UmbracoMemberPasswordRetrievalQuestion { get; set; }
    }
}
