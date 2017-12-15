namespace MBran.Core.Models
{
    public partial class Member : IMember
    {
        public bool UmbracoMemberApproved { get; set; }
        public string UmbracoMemberComments { get; set; }
        public string UmbracoMemberFailedPasswordAttempts { get; set; }
        public string UmbracoMemberLastLockoutDate { get; set; }
        public string UmbracoMemberLastLogin { get; set; }
        public string UmbracoMemberLastPasswordChangeDate { get; set; }
        public bool UmbracoMemberLockedOut { get; set; }
        public string UmbracoMemberPasswordRetrievalAnswer { get; set; }
        public string UmbracoMemberPasswordRetrievalQuestion { get; set; }
    }
}
