
-- 使用者資料

DELETE FROM [dbo].[UserRole];
DELETE FROM [dbo].[UserInfo];
DELETE FROM [dbo].[RoleInfo];

GO
DBCC CHECKIDENT('[dbo].[UserInfo]', RESEED, 0);
DBCC CHECKIDENT('[dbo].[RoleInfo]', RESEED, 0);

GO



SET IDENTITY_INSERT [dbo].[UserInfo] ON

INSERT [dbo].[UserInfo] ([UserId], [Account], [UserName], [Password], [Email], [AllowActList], [DenyActList], [Status], [DepartmentId], [ExtensionNum], [UserTitle], [RemarkText], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) 
	VALUES (1, N'system', N'系統', N'', N'', NULL, NULL, N'Disable', 0, NULL, NULL, NULL, 1, getdate(), 1, getdate());

-- admin Admin1234	
INSERT [dbo].[UserInfo] ([UserId], [Account], [UserName], [Password], [Email], [AllowActList], [DenyActList], [Status], [DepartmentId], [ExtensionNum], [UserTitle], [RemarkText], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) 
	VALUES (2, N'admin', N'Admin', N'YP50QG5/NT7ZefNQ8vu2ouhpCl+n0bDDKYPR2LP5X2c=', N'admin@a.b', NULL, NULL, N'Enable', 0, NULL, NULL, NULL, 1, getdate(), 1, getdate());

SET IDENTITY_INSERT [dbo].[UserInfo] OFF




SET IDENTITY_INSERT [dbo].[RoleInfo] ON

INSERT [dbo].[RoleInfo] ([RoleId], [RoleName], [AllowActList], [RemarkText], [Status], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) 
	VALUES (1, N'管理者', N'RoleSetting,UserSetting,UserActSetting', NULL, N'Enable', 1, getdate(), 1, getdate());

	
		
		 

SET IDENTITY_INSERT [dbo].[RoleInfo] OFF

INSERT [dbo].[UserRole] ([UserId], [RoleId], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) 
	VALUES (2, 1, 1, getdate(), 1, getdate());
	
