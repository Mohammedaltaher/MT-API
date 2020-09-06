USE [Oasis-Aggregator-Concord]
GO

/****** Object:  UserDefinedFunction [dbo].[GenerateClientQuoteReferenceId]    Script Date: 3/26/2020 5:40:26 PM ******/
DROP FUNCTION [dbo].[GenerateClientQuoteReferenceId]
GO

/****** Object:  UserDefinedFunction [dbo].[GenerateClientQuoteReferenceId]    Script Date: 3/26/2020 5:40:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GenerateClientQuoteReferenceId] ()
RETURNS nvarchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @maxNo NUMERIC(18,0)
	DECLARE @result NVARCHAR(20) 

	-- Add the T-SQL statements to compute the return value here
	SELECT @maxNo = ISNULL(MAX(RIGHT(ISNULL(QuoteReferenceId,N'QUT-MMM-YY-999'),CHARINDEX('-',ISNULL(QuoteReferenceId,N'QUT-MMM-YY-999')))),999)
 from ClientQuotation where Year(CreatedDate)=Year(GetDate())
set @result = 'QUT-' + Convert(char(3), GetDate(), 0)+ '-'+ FORMAT(GETDATE(),'yy')+ '-'+ CAST(@maxNo + 1 AS nvarchar)

	RETURN @result

END
GO

