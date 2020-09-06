USE [Oasis-Aggregator-Concord]
GO

/****** Object:  UserDefinedFunction [dbo].[GeneratePolicyRequestId]    Script Date: 01/23/2020 10:14:34 AM ******/
DROP FUNCTION [dbo].[GeneratePolicyRequestId]
GO

/****** Object:  UserDefinedFunction [dbo].[GeneratePolicyRequestId]    Script Date: 01/23/2020 10:14:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Omran.I.A.Ibrahim>
-- Create date: <23-01-2020>
-- Description:	<Generate policy request pattren function and set it as default value to column>
-- =============================================
CREATE FUNCTION [dbo].[GeneratePolicyRequestId] ()
RETURNS NVARCHAR(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @maxNo NUMERIC(18,0)
	DECLARE @result NVARCHAR(20) 
	-- Add the T-SQL statements to compute the return value here
	SELECT @maxNo = ISNULL(MAX(RIGHT(ISNULL(PolicyRequestId,N'POL-MMM-YY-999'),CHARINDEX('-',ISNULL(PolicyRequestId,N'POL-MMM-YY-999')))),999)
 from [Policy] where Year(CreatedDate)=Year(GetDate())
set @result = 'POL-' + Convert(char(3), GetDate(), 0)+ '-'+ FORMAT(GETDATE(),'yy')+ '-'+ CAST(@maxNo + 1 AS nvarchar)
	RETURN @result

END
GO

