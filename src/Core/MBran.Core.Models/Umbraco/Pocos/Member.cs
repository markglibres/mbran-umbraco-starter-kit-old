namespace MBran.Core.Models
{
    public partial class Member : BasePoco, IMember
    {
        public virtual bool UmbracoMemberApproved { get; set; }
        public virtual string UmbracoMemberComments { get; set; }
        public virtual string UmbracoMemberFailedPasswordAttempts { get; set; }
        public virtual string UmbracoMemberLastLockoutDate { get; set; }
        public virtual string UmbracoMemberLastLogin { get; set; }
        public virtual string UmbracoMemberLastPasswordChangeDate { get; set; }
        public virtual bool UmbracoMemberLockedOut { get; set; }
        public virtual string UmbracoMemberPasswordRetrievalAnswer { get; set; }
        public virtual string UmbracoMemberPasswordRetrievalQuestion { get; set; }
    }
}
