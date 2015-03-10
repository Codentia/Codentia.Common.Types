using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Codentia.Common
{       
    /// <summary>
    /// Collection of data regarding SqlDbOjects
    /// </summary>
    public static class SqlDbObjectCollection
    {
        private static List<SqlDbObject> _list = new List<SqlDbObject>();
        private static SqlDbObject _table = new SqlDbObject(SqlDbObjectType.Table, "U", "DROP TABLE {0}", false);
        private static SqlDbObject _sp = new SqlDbObject(SqlDbObjectType.StoredProcedure, "P", "DROP PROCEDURE {0}", false);
        private static SqlDbObject _scalarFunction = new SqlDbObject(SqlDbObjectType.Function_Scalar, "FN", "DROP FUNCTION {0}", false);
        private static SqlDbObject _inLineFunction = new SqlDbObject(SqlDbObjectType.Function_InLine, "IF", "DROP FUNCTION {0}", false);
        private static SqlDbObject _tableFunction = new SqlDbObject(SqlDbObjectType.Function_Table, "TF", "DROP FUNCTION {0}", false);
        private static SqlDbObject _fk = new SqlDbObject(SqlDbObjectType.FK, "F", "ALTER TABLE {1} DROP CONSTRAINT {0}", true);
        private static SqlDbObject _pk = new SqlDbObject(SqlDbObjectType.PK, "PK", "ALTER TABLE {1} DROP CONSTRAINT {0}", true);
        private static SqlDbObject _view = new SqlDbObject(SqlDbObjectType.View, "V", "DROP VIEW {0}", false);

        /// <summary>
        /// Gets the Table 
        /// </summary>
        public static SqlDbObject Table
        {
            get { return _table; }
        }

        /// <summary>
        /// Gets the StoredProcedure 
        /// </summary>
        public static SqlDbObject StoredProcedure
        {
            get { return _sp; }
        }

        /// <summary>
        /// Gets the ScalarFunction 
        /// </summary>
        public static SqlDbObject ScalarFunction
        {
            get { return _scalarFunction; }
        }

        /// <summary>
        /// Gets the InLineFunction 
        /// </summary>
        public static SqlDbObject InLineFunction
        {
            get { return _inLineFunction; }
        }

        /// <summary>
        /// Gets the TableFunction 
        /// </summary>
        public static SqlDbObject TableFunction
        {
            get { return _tableFunction; }
        }

        /// <summary>
        /// Gets the FK 
        /// </summary>
        public static SqlDbObject FK
        {
            get { return _fk; }
        }

        /// <summary>
        /// Gets the PK 
        /// </summary>
        public static SqlDbObject PK
        {
            get { return _pk; }
        }

        /// <summary>
        /// Gets the View 
        /// </summary>
        public static SqlDbObject View
        {
            get { return _view; }
        }

        /// <summary>
        /// Gets the List 
        /// </summary>
        public static ReadOnlyCollection<SqlDbObject> List
        {
            get 
            {
                if (_list.Count == 0)
                {                    
                    _list.Add(_table);
                    _list.Add(_sp);
                    _list.Add(_fk);
                    _list.Add(_pk);
                    _list.Add(_inLineFunction);
                    _list.Add(_scalarFunction);
                    _list.Add(_tableFunction);
                    _list.Add(_view);
                }

                return _list.AsReadOnly();
            }
        }

        /// <summary>
        /// Get SqlDbObject By XType 
        /// </summary>
        /// <param name="type">type/xType for the object</param>
        /// <returns>SqlDbObject object</returns>
        public static SqlDbObject GetSqlDbObjectByXType(string type)
        {
            IEnumerator<SqlDbObject> ie = _list.GetEnumerator();
            SqlDbObject? obj = null;

            while (ie.MoveNext())
            {
                if (ie.Current.XType == type)
                {
                    obj = ie.Current;
                }
            }

            if (obj == null)
            {
                 throw new ArgumentException(string.Format("Unsupported xtype: {0}", type));
            }
                            
            return (SqlDbObject)obj;                               
        }
    }
}
