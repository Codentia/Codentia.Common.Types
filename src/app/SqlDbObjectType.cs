using System;
using System.Collections.Generic;
using System.Text;

namespace Codentia.Common
{
    /// <summary>
    /// Types of Modes which can be used in FrontUp
    /// </summary>
    public enum SqlDbObjectType
    {
        /// <summary>
        /// FK (Foreign Key)
        /// </summary>
        FK = 1,

        /// <summary>
        /// InLine Function
        /// </summary>
        Function_InLine = 2,

        /// <summary>
        /// Scalar Function
        /// </summary>
        Function_Scalar = 3,

        /// <summary>
        /// Table Function
        /// </summary>
        Function_Table = 4,

        /// <summary>
        /// IX (Index)
        /// </summary>
        IX = 5,

        /// <summary>
        /// PK (Primary Key)
        /// </summary>
        PK = 6,

        /// <summary>
        /// Stored Procedure
        /// </summary>
        StoredProcedure = 7,

        /// <summary>
        /// Table Object
        /// </summary>
        Table = 8,

        /// <summary>
        /// View Object
        /// </summary>
        View = 9            
    }
}
