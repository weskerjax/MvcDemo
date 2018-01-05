CREATE TABLE [dbo].[UserPreference]
(
	[UserId]       INT            NOT NULL,
	[Name]			NVARCHAR (256)  NOT NULL,
	[Value]		NVARCHAR (MAX)  NULL,
	[CreateDate]   DATETIME        NOT NULL,
	[ModifyDate]   DATETIME        NOT NULL,
	CONSTRAINT [PK_UserPreference] PRIMARY KEY CLUSTERED ([UserId] ASC, [Name] ASC)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'使用者喜好設定',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'UserPreference',
	@level2type = NULL,
	@level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'使用者Id',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'UserPreference',
	@level2type = N'COLUMN',
	@level2name = N'UserId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'名稱',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'UserPreference',
	@level2type = N'COLUMN',
	@level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'值',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'UserPreference',
	@level2type = N'COLUMN',
	@level2name = N'Value'
GO

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'建立時間',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'UserPreference',
	@level2type = N'COLUMN',
	@level2name = N'CreateDate'
GO

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
	@value = N'修改時間',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'UserPreference',
	@level2type = N'COLUMN',
	@level2name = N'ModifyDate'