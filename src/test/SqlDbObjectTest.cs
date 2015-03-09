using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace MattchedIT.Common.Types.Test
{
    /// <summary>
    /// SqlDbObject Test 
    /// </summary>
    [TestFixture]
    public class SqlDbObjectTest
    {
        /// <summary>
        /// Scenario: Check enum values are same as expected    
        /// Expected: All test pass
        /// </summary>
        [Test]
        public void _001_SqlDbObjectType_ParameterTypeCheck()
        {
            Assert.That((int)SqlDbObjectType.FK == 1, Is.True);
            Assert.That((int)SqlDbObjectType.Function_InLine == 2, Is.True);
            Assert.That((int)SqlDbObjectType.Function_Scalar == 3, Is.True);
            Assert.That((int)SqlDbObjectType.Function_Table == 4, Is.True);
            Assert.That((int)SqlDbObjectType.IX == 5, Is.True);
            Assert.That((int)SqlDbObjectType.PK == 6, Is.True);
            Assert.That((int)SqlDbObjectType.StoredProcedure == 7, Is.True);
            Assert.That((int)SqlDbObjectType.Table == 8, Is.True);
            Assert.That((int)SqlDbObjectType.View == 9, Is.True);
        }

        /// <summary>
        /// Scenario: Check enum values are same as expected    
        /// Expected: All test pass
        /// </summary>
        [Test]
        public void _002_SqlDbObjectCollection()
        {
            // test all values

            // Table
            Assert.That(SqlDbObjectCollection.Table.SqlDbObjectType, Is.EqualTo(SqlDbObjectType.Table));
            Assert.That(SqlDbObjectCollection.Table.XType, Is.EqualTo("U"));
            Assert.That(SqlDbObjectCollection.Table.DropObjectTemplate, Is.EqualTo("DROP TABLE {0}"));
            Assert.That(SqlDbObjectCollection.Table.NeedsTableNameForDrop, Is.False);

            // StoredProcedure
            Assert.That(SqlDbObjectCollection.StoredProcedure.SqlDbObjectType, Is.EqualTo(SqlDbObjectType.StoredProcedure));
            Assert.That(SqlDbObjectCollection.StoredProcedure.XType, Is.EqualTo("P"));
            Assert.That(SqlDbObjectCollection.StoredProcedure.DropObjectTemplate, Is.EqualTo("DROP PROCEDURE {0}"));
            Assert.That(SqlDbObjectCollection.StoredProcedure.NeedsTableNameForDrop, Is.False);

            // FK
            Assert.That(SqlDbObjectCollection.FK.SqlDbObjectType, Is.EqualTo(SqlDbObjectType.FK));
            Assert.That(SqlDbObjectCollection.FK.XType, Is.EqualTo("F"));
            Assert.That(SqlDbObjectCollection.FK.DropObjectTemplate, Is.EqualTo("ALTER TABLE {1} DROP CONSTRAINT {0}"));
            Assert.That(SqlDbObjectCollection.FK.NeedsTableNameForDrop, Is.True);

            // PK
            Assert.That(SqlDbObjectCollection.PK.SqlDbObjectType, Is.EqualTo(SqlDbObjectType.PK));
            Assert.That(SqlDbObjectCollection.PK.XType, Is.EqualTo("PK"));
            Assert.That(SqlDbObjectCollection.PK.DropObjectTemplate, Is.EqualTo("ALTER TABLE {1} DROP CONSTRAINT {0}"));
            Assert.That(SqlDbObjectCollection.PK.NeedsTableNameForDrop, Is.True);

            // View
            Assert.That(SqlDbObjectCollection.View.SqlDbObjectType, Is.EqualTo(SqlDbObjectType.View));
            Assert.That(SqlDbObjectCollection.View.XType, Is.EqualTo("V"));
            Assert.That(SqlDbObjectCollection.View.DropObjectTemplate, Is.EqualTo("DROP VIEW {0}"));
            Assert.That(SqlDbObjectCollection.View.NeedsTableNameForDrop, Is.False);

            // Inline Function
            Assert.That(SqlDbObjectCollection.InLineFunction.SqlDbObjectType, Is.EqualTo(SqlDbObjectType.Function_InLine));
            Assert.That(SqlDbObjectCollection.InLineFunction.XType, Is.EqualTo("IF"));
            Assert.That(SqlDbObjectCollection.InLineFunction.DropObjectTemplate, Is.EqualTo("DROP FUNCTION {0}"));
            Assert.That(SqlDbObjectCollection.InLineFunction.NeedsTableNameForDrop, Is.False);
          
            // Scalar Function
            Assert.That(SqlDbObjectCollection.ScalarFunction.SqlDbObjectType, Is.EqualTo(SqlDbObjectType.Function_Scalar));
            Assert.That(SqlDbObjectCollection.ScalarFunction.XType, Is.EqualTo("FN"));
            Assert.That(SqlDbObjectCollection.ScalarFunction.DropObjectTemplate, Is.EqualTo("DROP FUNCTION {0}"));
            Assert.That(SqlDbObjectCollection.ScalarFunction.NeedsTableNameForDrop, Is.False);

            // Table Function
            Assert.That(SqlDbObjectCollection.TableFunction.SqlDbObjectType, Is.EqualTo(SqlDbObjectType.Function_Table));
            Assert.That(SqlDbObjectCollection.TableFunction.XType, Is.EqualTo("TF"));
            Assert.That(SqlDbObjectCollection.TableFunction.DropObjectTemplate, Is.EqualTo("DROP FUNCTION {0}"));
            Assert.That(SqlDbObjectCollection.TableFunction.NeedsTableNameForDrop, Is.False);    
        }

        /// <summary>
        /// Scenario: Get SqlDbObjectCollection List and check values
        /// Expected: All test pass
        /// </summary>
        [Test]
        public void _003_SqlDbObjectCollection_List()
        {
            ReadOnlyCollection<SqlDbObject> list = SqlDbObjectCollection.List;

            IEnumerator<SqlDbObject> ie = list.GetEnumerator();
            int count = 0;
            while (ie.MoveNext())
            {
                Assert.That(list[count].NeedsTableNameForDrop, Is.EqualTo(ie.Current.NeedsTableNameForDrop));
                Assert.That(list[count].DropObjectTemplate, Is.EqualTo(ie.Current.DropObjectTemplate));
                Assert.That(list[count].XType, Is.EqualTo(ie.Current.XType));
                Assert.That(list[count].SqlDbObjectType, Is.EqualTo(ie.Current.SqlDbObjectType));

                count++;
            }
        }

        /// <summary>
        /// Scenario: Check enum values are same as expected    
        /// Expected: All test pass
        /// </summary>
        [Test]
        public void _004_SqlDbObjectCollection_GetSqlDbObjectByXType_UnsupportedType()
        {
            Assert.That(delegate { SqlDbObject obj = SqlDbObjectCollection.GetSqlDbObjectByXType("UNSUPPORT"); }, Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Unsupported xtype: UNSUPPORT"));
        }

        /// <summary>
        /// Scenario: Check enum values are same as expected    
        /// Expected: All test pass
        /// </summary>
        [Test]
        public void _005_SqlDbObjectCollection_GetSqlDbObjectByXType()
        {
            ReadOnlyCollection<SqlDbObject> list = SqlDbObjectCollection.List;
            Assert.That(SqlDbObjectCollection.GetSqlDbObjectByXType("IF"), Is.EqualTo(SqlDbObjectCollection.InLineFunction));
            Assert.That(SqlDbObjectCollection.GetSqlDbObjectByXType("F"), Is.EqualTo(SqlDbObjectCollection.FK));
            Assert.That(SqlDbObjectCollection.GetSqlDbObjectByXType("PK"), Is.EqualTo(SqlDbObjectCollection.PK));
            Assert.That(SqlDbObjectCollection.GetSqlDbObjectByXType("FN"), Is.EqualTo(SqlDbObjectCollection.ScalarFunction));
            Assert.That(SqlDbObjectCollection.GetSqlDbObjectByXType("P"), Is.EqualTo(SqlDbObjectCollection.StoredProcedure));
            Assert.That(SqlDbObjectCollection.GetSqlDbObjectByXType("U"), Is.EqualTo(SqlDbObjectCollection.Table));
            Assert.That(SqlDbObjectCollection.GetSqlDbObjectByXType("TF"), Is.EqualTo(SqlDbObjectCollection.TableFunction));
            Assert.That(SqlDbObjectCollection.GetSqlDbObjectByXType("V"), Is.EqualTo(SqlDbObjectCollection.View));
        }
    }
}
