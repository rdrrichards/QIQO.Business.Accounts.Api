using System;

namespace QIQO.Business.Accounts.Api.Models
{
    public class Comment
    {
        public int CommentKey { get; set; }
        public int EntityKey { get; set; }
        public int EntityTypeKey { get; set; }
        public QIQOCommentType CommentType { get; set; }
        public string CommentValue { get; set; }
        public string AddedUserID { get; set; }
        public DateTime AddedDateTime { get; set; }
        public string UpdateUserID { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
