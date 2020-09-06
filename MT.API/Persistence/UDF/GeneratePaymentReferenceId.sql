USE [Oasis-Aggregator-Concord]
GO

/****** Object:  UserDefinedFunction [dbo].[GeneratePaymentReferenceId]    Script Date: 3/27/2020 9:46:46 PM ******/
DROP FUNCTION [dbo].[GeneratePaymentReferenceId]
GO

/****** Object:  UserDefinedFunction [dbo].[GeneratePaymentReferenceId]    Script Date: 3/27/2020 9:46:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Omran.I.Ahmed.Ibrahim>
-- Create date: <2020>
-- Description:	<Generate Quotation Request Id>
-- =============================================
CREATE FUNCTION [dbo].[GeneratePaymentReferenceId]()

RETURNS NVARCHAR(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @maxNo NUMERIC(18,0)
	DECLARE @result NVARCHAR(20) 
	-- Add the T-SQL statements to compute the return value here
SELECT @maxNo = ISNULL(MAX(RIGHT(ISNULL(PaymentReferenceId,N'PAY-MMM-YY-999'),CHARINDEX('-',ISNULL(PaymentReferenceId,N'PAY-MMM-YY-999')))),999)
 from ClientPayment where Month(CreatedDate)=Month(GetDate()) and  Year(CreatedDate)=Year(GetDate())
set @result = 'PAY-' + Convert(char(3), GetDate(), 0)+ '-'+ FORMAT(GETDATE(),'yy')+ '-'+ CAST(@maxNo + 1 AS nvarchar)

	RETURN @result

END
GO

