CREATE TABLE [dbo].[Table] (
    [Order_Ref_No]   NVARCHAR(MAX)  NOT NULL DEFAULT 0,
    [Customer_Name]  NVARCHAR (MAX) NULL,
    [Customer_Phone] NVARCHAR (MAX) NULL,
    [Order_Date]     NVARCHAR(MAX)  NULL,
    [Order_Time]     NVARCHAR(MAX)  NULL,
    [Rice]           NVARCHAR (MAX) NULL,
    [Sugar]          NVARCHAR (MAX) NULL,
    [Oil]            NVARCHAR (MAX) NULL,
    [Qty1]           INT            NULL,
    [Qty2]           INT            NULL,
    [Qty3]           INT            NULL,
    [Unit_Price1]    NVARCHAR(MAX)     NULL,
    [Unit_Price2]    NVARCHAR(MAX)     NULL,
    [Unit_Price3]    NVARCHAR(MAX)     NULL,
    [Sub_Total1]     NVARCHAR(MAX)     NULL,
    [Sub_Total2]     NVARCHAR(MAX)     NULL,
    [Sub_Total3]     NVARCHAR(MAX)     NULL,
    [Tax]            NVARCHAR(MAX)     NULL,
    [Net_Total]      NVARCHAR(MAX)     NULL,
    [Net_Sub_Total]  NVARCHAR(MAX)     NULL 
);

