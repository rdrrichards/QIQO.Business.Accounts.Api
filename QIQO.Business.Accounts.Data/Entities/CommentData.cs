using QIQO.Business.Core.Contracts;

namespace QIQO.Business.Accounts.Data.Entities
{
    public class CommentData : CommonData, IEntity
    {
        public int CommentKey { get; set; }
        public int EntityKey { get; set; }
        public int EntityType { get; set; }
        public int CommentTypeKey { get; set; }
        public string CommentValue { get; set; }

        public int EntityRowKey
        {
            get { return CommentKey; }
            set { CommentKey = value; }
        }
    }
}
