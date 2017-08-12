﻿using QIQO.Business.Core.Contracts;

namespace QIQO.Business.Accounts.Data.Entities
{
    public class AttributeData : CommonData, IEntity
    {
        public int AttributeKey { get; set; }
        public int EntityKey { get; set; }
        public int EntityTypeKey { get; set; }
        public int AttributeTypeKey { get; set; }
        public string AttributeValue { get; set; }
        public int AttributeDataTypeKey { get; set; }
        public string AttributeDisplayFormat { get; set; }

        public int EntityRowKey
        {
            get { return AttributeKey; }
            set { AttributeKey = value; }
        }
    }
}
