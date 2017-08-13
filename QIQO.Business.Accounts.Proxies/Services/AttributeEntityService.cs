using System;
using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Accounts.Proxies.Models;

namespace QIQO.Business.Accounts.Proxies.Services
{
    public class AttributeEntityService : IAttributeEntityService
    {
        public EntityAttribute Map(AttributeData ent)
        {
            return new EntityAttribute {
                AttributeKey = ent.AttributeKey,
                EntityKey = ent.EntityKey,
                EntityType = (QIQOEntityType)ent.EntityTypeKey,
                AttributeDataType = (QIQOAttributeDataType)ent.AttributeDataTypeKey,
                AttributeDataTypeKey = ent.AttributeTypeKey,
                AttributeValue = ent.AttributeValue,
                AttributeDisplayFormat = ent.AttributeDisplayFormat,
                AddedDateTime = ent.AuditAddDatetime,
                AddedUserID = ent.AuditAddUserId,
                UpdateDateTime = ent.AuditUpdateDatetime,
                UpdateUserID = ent.AuditUpdateUserId
            };
        }

        public AttributeData Map(EntityAttribute ent)
        {
            return new AttributeData()
            {
                AttributeKey = ent.AttributeKey,
                EntityKey = ent.EntityKey,
                EntityTypeKey = (int)ent.EntityType,
                // AttributeTypeKey = (int)ent.AttributeType,
                AttributeValue = ent.AttributeValue,
                AttributeDataTypeKey = ent.AttributeDataTypeKey,
                AttributeDisplayFormat = ent.AttributeDisplayFormat
            };

        }
    }

}
