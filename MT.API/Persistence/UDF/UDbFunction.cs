using Microsoft.EntityFrameworkCore;
using System;

namespace  AggriPortal.API.Persistence.UDF
{
    public static class UDbFunction
    {

        [DbFunction("GenerateQuotationRequetId", "dbo")]
        public static void GenerateQuotationRequetId(this DbContext context)
        {
            string fnName = "GenerateQuotationRequetId";
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    string sqlDrop = $"IF OBJECT_ID('dbo.{fnName}', N'FN') IS NOT NULL " +
                        $"DROP FUNCTION dbo.{fnName}";
#pragma warning disable CS0618 // Type or member is obsolete
                    context.Database.ExecuteSqlCommand(sqlDrop);
#pragma warning restore CS0618 // Type or member is obsolete

                    string sqlCreate = $"CREATE FUNCTION {fnName} ()" +
                        @"  RETURNS NVARCHAR(20)
                              AS 
                              BEGIN
                              DECLARE @result AS NVARCHAR(50)
                              DECLARE @maxNo AS NUMERIC(18,2)
                              SELECT @maxNo = MAX(REVERSE(LEFT(REVERSE(ISNULL(RequestId,N'QUT-MMM-YY-1000')),CHARINDEX('-',REVERSE(ISNULL(RequestId,N'QUT-MMM-YY-1000'))) - 1))) FROM QuotationRequest
                                   WHERE YEAR(CreatedDate) = YEAR(GetDate())
                              IF(@maxNo = 1000)
                                set @result = 'QUT-' + Convert(char(3), GetDate(), 0)+ '-'+ FORMAT(GETDATE(),'yy')+ '-'+  CAST(@maxNo AS nvarchar)
                              ELSE 
                                set @result = 'QUT-' + Convert(char(3), GetDate(), 0)+ '-'+ FORMAT(GETDATE(),'yy')+ '-'+ CAST(@maxNo + 1 AS nvarchar)
                              RETURN @result 
                              END";
#pragma warning disable CS0618 // Type or member is obsolete
                    context.Database.ExecuteSqlCommand(sqlCreate);
#pragma warning restore CS0618 // Type or member is obsolete
                    transaction.Commit();
                }
                catch (Exception )
                {
                    //I left this in because you normally would catch the expection and return an error.
                    throw;
                }
            }
        }
    }
}
