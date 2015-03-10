using System;
using System.Collections.Generic;
using System.Text;

namespace Codentia.Common
{
    /// <summary>
    /// SqlDbObject structure
    /// </summary>
    public struct SqlDbObject
    {
        private SqlDbObjectType _sqlType;
        private string _type;
        private string _dropObjectTemplate;
        private bool _needsTableNameForDrop;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDbObject"/> struct.
        /// </summary>
        /// <param name="sqlType">SqlDbObjectType enum</param>
        /// <param name="type">type/xType for use in querying sysobjects</param>
        /// <param name="dropObjectTemplate">Template used for dropping object</param>
        /// <param name="needsTableNameForDrop">decides whether the table Name is also used in the drop template</param>
        public SqlDbObject(SqlDbObjectType sqlType, string type, string dropObjectTemplate, bool needsTableNameForDrop)
        {
            _sqlType = sqlType;
            _type = type;
            _dropObjectTemplate = dropObjectTemplate;
            _needsTableNameForDrop = needsTableNameForDrop;
        }

        /// <summary>
        /// Gets the SqlDbObjectType
        /// </summary>
        public SqlDbObjectType SqlDbObjectType 
        {
           get 
           {
                return _sqlType;
           }
        }

        /// <summary>
        /// Gets the XType
        /// </summary>
        public string XType
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// Gets the DropObjectTemplate
        /// </summary>
        public string DropObjectTemplate
        {
            get
            {
                return _dropObjectTemplate;
            }
        }

        /// <summary>
        /// Gets a value indicating whether it needs the table name for dropping
        /// </summary>
        public bool NeedsTableNameForDrop
        {
            get
            {
                return _needsTableNameForDrop;
            }
        }               
    }
}
