using System;
using System.Collections.Generic;
using System.Text;

namespace PrincipalTechProject.Infra.Data.Sql
{
    internal static class SqlStatements
    {
        public static string InsertProduct { get; } =
            $@"INSERT INTO [dbo].[product]
           ([name]
           ,[description]
           ,[stock]
           ,[category]
           ,[status]
           ,[createdDate])
           VALUES
           (@Name
           ,@Description
           ,@Stock
           ,@Category
           ,@Status
           ,@CreatedDate)
           SELECT @@IDENTITY";

        public static string UpdateProduct { get; } =
            $@"UPDATE [dbo].[product]
            SET [name] = ISNULL(NULLIF(@name,''),name),
                [description] = ISNULL(NULLIF(@description,''),description),
                [stock] = ISNULL(NULLIF(@stock,0),stock),
                [category] = ISNULL(NULLIF(@category,0),category)
            WHERE Id = @id";

        public static string DeleteProduct { get; } =
            $@"UPDATE [dbo].[product]
            SET [status] = @newStatus
            WHERE Id = @id";

        public static string SelectProducts { get; } =
            $@"SELECT [id]
              ,[name]
              ,[description]
              ,[stock]
              ,[category]
              ,[status]
              ,[createdDate]
          FROM [dbo].[product](nolock)";

        public static string SelectProductById { get; } =
            $@"SELECT [id]
              ,[name]
              ,[description]
              ,[stock]
              ,[category]
              ,[status]
              ,[createdDate]
          FROM [dbo].[product](nolock)    
          WHERE Id = @Id";
    }
}
