USE [Oasis-Aggregator-Concord]
GO

/****** Object:  UserDefinedFunction [dbo].[GenerateQuotationRequestId]    Script Date: 3/26/2020 5:39:01 PM ******/
DROP FUNCTION [dbo].[GenerateQuotationRequestId]
GO

/****** Object:  UserDefinedFunction [dbo].[GenerateQuotationRequestId]    Script Date: 3/26/2020 5:39:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Omran.I.Ahmed.Ibrahim>
-- Create date: <2020>
-- Description:	<Generate Quotation Request Id>
-- =============================================
CREATE FUNCTION [dbo].[GenerateQuotationRequestId]()

RETURNS NVARCHAR(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @maxNo NUMERIC(18,0)
	DECLARE @result NVARCHAR(20) 
	-- Add the T-SQL statements to compute the return value here
SELECT @maxNo = ISNULL(MAX(RIGHT(ISNULL(RequestReferenceId,N'REQ-MMM-YY-999'),CHARINDEX('-',ISNULL(RequestReferenceId,N'REQ-MMM-YY-999')))),999)
 from QuotationRequest where Year(CreatedDate)=Year(GetDate())
set @result = 'REQ-' + Convert(char(3), GetDate(), 0)+ '-'+ FORMAT(GETDATE(),'yy')+ '-'+ CAST(@maxNo + 1 AS nvarchar)

	RETURN @result

END
GO


