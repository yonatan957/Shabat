using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shabat.DAL
{
    internal class SeedService
    {
        private DBconnections _dbconnections;
        public SeedService(DBconnections dbconnections)
        {
            _dbconnections = dbconnections;
        }

        public void EnsureTablesAndSeedData()
        {
            string sqlQuery = @"use Shabat;
                                
                                DECLARE @TableCreated INT = 0;

                                BEGIN TRANSACTION;

                                BEGIN TRY

                                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Categories' )
                                    BEGIN
                                            CREATE TABLE Guest(
                                        ID INT IDENTITY(1,1),
                                        Name NVARCHAR(50)UNIQUE,
                                        PRIMARY KEY (ID))

                                        CREATE TABLE Categories(
                                        ID INT IDENTITY(1,1),
                                        Name NVARCHAR(50) UNIQUE,
                                        PRIMARY KEY (ID))

                                        CREATE TABLE Food(
                                        ID INT IDENTITY(1,1),
                                        GuestID INT, 
                                        CategoryID INT,
                                        FoodName NVARCHAR(50),
                                        FOREIGN KEY(GuestID) REFERENCES Guest(ID),
                                        FOREIGN KEY(CategoryID) REFERENCES Categories(ID),
                                        UNIQUE (GuestID, FoodName)
                                        )
                                            INSERT INTO Categories (Name)
                                            VALUES (N'דגים'), (N'בשר'), (N'משקאות'), (N'סלטים'), (N'קינוחים');
                                            SET @TableCreated = 1; 
                                    END
                                    COMMIT TRANSACTION;
                                END TRY
                                BEGIN CATCH

                                    ROLLBACK TRANSACTION;
                                    SET @TableCreated = 0; 
	                                END CATCH
                                SELECT @TableCreated AS IsCreated;";
            _dbconnections.ExecuteNoneQuery(sqlQuery, null);
            DataTable ressult = _dbconnections.ExecuteQuery("select count(*) as test from Categories;", null);
            if (ressult.Rows.Count <= 0)
            {
                throw new Exception("seed failed...");
            }       
        }
    }   
}
