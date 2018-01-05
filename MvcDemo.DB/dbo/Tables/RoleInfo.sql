CREATE TABLE [dbo].[RoleInfo] (
    [RoleId]       INT             IDENTITY (1, 1) NOT NULL,
    [RoleName]     NVARCHAR (256)  NOT NULL,
    [AllowActList] NVARCHAR (MAX)  NULL,
    [RemarkText]   NVARCHAR (2048) NULL,
    [Status]       NVARCHAR (32)   NOT NULL,
    [CreateBy]     INT             NOT NULL,
    [CreateDate]   DATETIME        NOT NULL,
    [ModifyBy]     INT             NOT NULL,
    [ModifyDate]   DATETIME        NOT NULL,
    CONSTRAINT [PK_RoleInfo] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'修改時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo', @level2type = N'COLUMN', @level2name = N'ModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'修改者 Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo', @level2type = N'COLUMN', @level2name = N'ModifyBy';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立者 Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo', @level2type = N'COLUMN', @level2name = N'CreateBy';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'狀態', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo', @level2type = N'COLUMN', @level2name = N'Status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'備註', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo', @level2type = N'COLUMN', @level2name = N'RemarkText';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'允許權限', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo', @level2type = N'COLUMN', @level2name = N'AllowActList';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo', @level2type = N'COLUMN', @level2name = N'RoleName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色資訊', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RoleInfo';

