using System;

namespace QIQO.Business.Accounts.Api.Models
{
    public class EntityAttribute
    {
        public int AttributeKey { get; set; }
        public int EntityKey { get; set; }
        public QIQOEntityType EntityType { get; set; } = QIQOEntityType.Account;
        // public EntityType EntityTypeData { get; set; }
        // public QIQOAttributeType AttributeType { get; set; } = QIQOAttributeType.AccountContact_CNCT_MAIN;
        // public AttributeType AttributeTypeData { get; set; }
        public string AttributeValue { get; set; }
        public int AttributeDataTypeKey { get; set; }
        public QIQOAttributeDataType AttributeDataType { get; set; } = QIQOAttributeDataType.String;
        public string AttributeDisplayFormat { get; set; }
        public string AddedUserID { get; set; }
        public DateTime AddedDateTime { get; set; }
        public string UpdateUserID { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
