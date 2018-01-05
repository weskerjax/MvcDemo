CREATE TABLE [dbo].[UserSignInRecord] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Account]    NVARCHAR (256) NOT NULL,
    [SignInIp]   NVARCHAR (48)  NULL,
    [SignInType] NVARCHAR (32)  NULL,
    [StatusCode] NVARCHAR (32)  NULL,
    [StatusMsg]  NVARCHAR (32)  NULL,
    [CreateDate] DATETIME       NOT NULL,
    CONSTRAINT [PK_UserSignInRecord] PRIMARY KEY CLUSTERED ([Id] ASC)
);

