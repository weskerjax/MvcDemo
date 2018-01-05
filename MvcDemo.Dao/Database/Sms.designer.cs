﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcDemo.Dao.Database
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MvcDemo")]
	public partial class SmsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 擴充性方法定義
    partial void OnCreated();
    partial void InsertRoleInfo(RoleInfo instance);
    partial void UpdateRoleInfo(RoleInfo instance);
    partial void DeleteRoleInfo(RoleInfo instance);
    partial void InsertUserSignInRecord(UserSignInRecord instance);
    partial void UpdateUserSignInRecord(UserSignInRecord instance);
    partial void DeleteUserSignInRecord(UserSignInRecord instance);
    partial void InsertUserInfo(UserInfo instance);
    partial void UpdateUserInfo(UserInfo instance);
    partial void DeleteUserInfo(UserInfo instance);
    partial void InsertUserRole(UserRole instance);
    partial void UpdateUserRole(UserRole instance);
    partial void DeleteUserRole(UserRole instance);
    partial void InsertUserPreference(UserPreference instance);
    partial void UpdateUserPreference(UserPreference instance);
    partial void DeleteUserPreference(UserPreference instance);
    #endregion
		
		public SmsDataContext() : 
				base(global::MvcDemo.Dao.Properties.Settings.Default.HLH_SMSConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SmsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SmsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SmsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SmsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<RoleInfo> RoleInfo
		{
			get
			{
				return this.GetTable<RoleInfo>();
			}
		}
		
		public System.Data.Linq.Table<UserSignInRecord> UserSignInRecord
		{
			get
			{
				return this.GetTable<UserSignInRecord>();
			}
		}
		
		public System.Data.Linq.Table<UserInfo> UserInfo
		{
			get
			{
				return this.GetTable<UserInfo>();
			}
		}
		
		public System.Data.Linq.Table<UserRole> UserRole
		{
			get
			{
				return this.GetTable<UserRole>();
			}
		}
		
		public System.Data.Linq.Table<UserPreference> UserPreference
		{
			get
			{
				return this.GetTable<UserPreference>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.RoleInfo")]
	public partial class RoleInfo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RoleId;
		
		private string _RoleName;
		
		private string _AllowActList;
		
		private string _RemarkText;
		
		private string _Status;
		
		private int _CreateBy;
		
		private System.DateTime _CreateDate;
		
		private int _ModifyBy;
		
		private System.DateTime _ModifyDate;
		
		private EntitySet<UserRole> _SMS_UserRole;
		
    #region 擴充性方法定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRoleIdChanging(int value);
    partial void OnRoleIdChanged();
    partial void OnRoleNameChanging(string value);
    partial void OnRoleNameChanged();
    partial void OnAllowActListChanging(string value);
    partial void OnAllowActListChanged();
    partial void OnRemarkTextChanging(string value);
    partial void OnRemarkTextChanged();
    partial void OnStatusChanging(string value);
    partial void OnStatusChanged();
    partial void OnCreateByChanging(int value);
    partial void OnCreateByChanged();
    partial void OnCreateDateChanging(System.DateTime value);
    partial void OnCreateDateChanged();
    partial void OnModifyByChanging(int value);
    partial void OnModifyByChanged();
    partial void OnModifyDateChanging(System.DateTime value);
    partial void OnModifyDateChanged();
    #endregion
		
		public RoleInfo()
		{
			this._SMS_UserRole = new EntitySet<UserRole>(new Action<UserRole>(this.attach_SMS_UserRole), new Action<UserRole>(this.detach_SMS_UserRole));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int RoleId
		{
			get
			{
				return this._RoleId;
			}
			set
			{
				if ((this._RoleId != value))
				{
					this.OnRoleIdChanging(value);
					this.SendPropertyChanging();
					this._RoleId = value;
					this.SendPropertyChanged("RoleId");
					this.OnRoleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string RoleName
		{
			get
			{
				return this._RoleName;
			}
			set
			{
				if ((this._RoleName != value))
				{
					this.OnRoleNameChanging(value);
					this.SendPropertyChanging();
					this._RoleName = value;
					this.SendPropertyChanged("RoleName");
					this.OnRoleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AllowActList", DbType="NVarChar(MAX)")]
		public string AllowActList
		{
			get
			{
				return this._AllowActList;
			}
			set
			{
				if ((this._AllowActList != value))
				{
					this.OnAllowActListChanging(value);
					this.SendPropertyChanging();
					this._AllowActList = value;
					this.SendPropertyChanged("AllowActList");
					this.OnAllowActListChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RemarkText", DbType="NVarChar(2048)")]
		public string RemarkText
		{
			get
			{
				return this._RemarkText;
			}
			set
			{
				if ((this._RemarkText != value))
				{
					this.OnRemarkTextChanging(value);
					this.SendPropertyChanging();
					this._RemarkText = value;
					this.SendPropertyChanged("RemarkText");
					this.OnRemarkTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="NVarChar(32) NOT NULL", CanBeNull=false)]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateBy", DbType="Int NOT NULL")]
		public int CreateBy
		{
			get
			{
				return this._CreateBy;
			}
			set
			{
				if ((this._CreateBy != value))
				{
					this.OnCreateByChanging(value);
					this.SendPropertyChanging();
					this._CreateBy = value;
					this.SendPropertyChanged("CreateBy");
					this.OnCreateByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyBy", DbType="Int NOT NULL")]
		public int ModifyBy
		{
			get
			{
				return this._ModifyBy;
			}
			set
			{
				if ((this._ModifyBy != value))
				{
					this.OnModifyByChanging(value);
					this.SendPropertyChanging();
					this._ModifyBy = value;
					this.SendPropertyChanged("ModifyBy");
					this.OnModifyByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifyDate
		{
			get
			{
				return this._ModifyDate;
			}
			set
			{
				if ((this._ModifyDate != value))
				{
					this.OnModifyDateChanging(value);
					this.SendPropertyChanging();
					this._ModifyDate = value;
					this.SendPropertyChanged("ModifyDate");
					this.OnModifyDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="RoleInfo_UserRole", Storage="_SMS_UserRole", ThisKey="RoleId", OtherKey="RoleId")]
		public EntitySet<UserRole> UserRole
		{
			get
			{
				return this._SMS_UserRole;
			}
			set
			{
				this._SMS_UserRole.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_SMS_UserRole(UserRole entity)
		{
			this.SendPropertyChanging();
			entity.RoleInfo = this;
		}
		
		private void detach_SMS_UserRole(UserRole entity)
		{
			this.SendPropertyChanging();
			entity.RoleInfo = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserSignInRecord")]
	public partial class UserSignInRecord : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Account;
		
		private string _SignInIp;
		
		private string _SignInType;
		
		private string _StatusCode;
		
		private string _StatusMsg;
		
		private System.DateTime _CreateDate;
		
    #region 擴充性方法定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnAccountChanging(string value);
    partial void OnAccountChanged();
    partial void OnSignInIpChanging(string value);
    partial void OnSignInIpChanged();
    partial void OnSignInTypeChanging(string value);
    partial void OnSignInTypeChanged();
    partial void OnStatusCodeChanging(string value);
    partial void OnStatusCodeChanged();
    partial void OnStatusMsgChanging(string value);
    partial void OnStatusMsgChanged();
    partial void OnCreateDateChanging(System.DateTime value);
    partial void OnCreateDateChanged();
    #endregion
		
		public UserSignInRecord()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Account", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string Account
		{
			get
			{
				return this._Account;
			}
			set
			{
				if ((this._Account != value))
				{
					this.OnAccountChanging(value);
					this.SendPropertyChanging();
					this._Account = value;
					this.SendPropertyChanged("Account");
					this.OnAccountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SignInIp", DbType="NVarChar(48)")]
		public string SignInIp
		{
			get
			{
				return this._SignInIp;
			}
			set
			{
				if ((this._SignInIp != value))
				{
					this.OnSignInIpChanging(value);
					this.SendPropertyChanging();
					this._SignInIp = value;
					this.SendPropertyChanged("SignInIp");
					this.OnSignInIpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SignInType", DbType="NVarChar(32)")]
		public string SignInType
		{
			get
			{
				return this._SignInType;
			}
			set
			{
				if ((this._SignInType != value))
				{
					this.OnSignInTypeChanging(value);
					this.SendPropertyChanging();
					this._SignInType = value;
					this.SendPropertyChanged("SignInType");
					this.OnSignInTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusCode", DbType="NVarChar(32)")]
		public string StatusCode
		{
			get
			{
				return this._StatusCode;
			}
			set
			{
				if ((this._StatusCode != value))
				{
					this.OnStatusCodeChanging(value);
					this.SendPropertyChanging();
					this._StatusCode = value;
					this.SendPropertyChanged("StatusCode");
					this.OnStatusCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusMsg", DbType="NVarChar(32)")]
		public string StatusMsg
		{
			get
			{
				return this._StatusMsg;
			}
			set
			{
				if ((this._StatusMsg != value))
				{
					this.OnStatusMsgChanging(value);
					this.SendPropertyChanging();
					this._StatusMsg = value;
					this.SendPropertyChanged("StatusMsg");
					this.OnStatusMsgChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserInfo")]
	public partial class UserInfo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _Account;
		
		private string _UserName;
		
		private string _Email;
		
		private string _Password;
		
		private string _AllowActList;
		
		private string _DenyActList;
		
		private string _Status;
		
		private System.Nullable<int> _DepartmentId;
		
		private string _ExtensionNum;
		
		private string _UserTitle;
		
		private string _RemarkText;
		
		private int _CreateBy;
		
		private System.DateTime _CreateDate;
		
		private int _ModifyBy;
		
		private System.DateTime _ModifyDate;
		
		private EntitySet<UserRole> _SMS_UserRole;
		
    #region 擴充性方法定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnAccountChanging(string value);
    partial void OnAccountChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnAllowActListChanging(string value);
    partial void OnAllowActListChanged();
    partial void OnDenyActListChanging(string value);
    partial void OnDenyActListChanged();
    partial void OnStatusChanging(string value);
    partial void OnStatusChanged();
    partial void OnDepartmentIdChanging(System.Nullable<int> value);
    partial void OnDepartmentIdChanged();
    partial void OnExtensionNumChanging(string value);
    partial void OnExtensionNumChanged();
    partial void OnUserTitleChanging(string value);
    partial void OnUserTitleChanged();
    partial void OnRemarkTextChanging(string value);
    partial void OnRemarkTextChanged();
    partial void OnCreateByChanging(int value);
    partial void OnCreateByChanged();
    partial void OnCreateDateChanging(System.DateTime value);
    partial void OnCreateDateChanged();
    partial void OnModifyByChanging(int value);
    partial void OnModifyByChanged();
    partial void OnModifyDateChanging(System.DateTime value);
    partial void OnModifyDateChanged();
    #endregion
		
		public UserInfo()
		{
			this._SMS_UserRole = new EntitySet<UserRole>(new Action<UserRole>(this.attach_SMS_UserRole), new Action<UserRole>(this.detach_SMS_UserRole));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Account", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string Account
		{
			get
			{
				return this._Account;
			}
			set
			{
				if ((this._Account != value))
				{
					this.OnAccountChanging(value);
					this.SendPropertyChanging();
					this._Account = value;
					this.SendPropertyChanged("Account");
					this.OnAccountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(256)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(256)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AllowActList", DbType="NVarChar(MAX)")]
		public string AllowActList
		{
			get
			{
				return this._AllowActList;
			}
			set
			{
				if ((this._AllowActList != value))
				{
					this.OnAllowActListChanging(value);
					this.SendPropertyChanging();
					this._AllowActList = value;
					this.SendPropertyChanged("AllowActList");
					this.OnAllowActListChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DenyActList", DbType="NVarChar(MAX)")]
		public string DenyActList
		{
			get
			{
				return this._DenyActList;
			}
			set
			{
				if ((this._DenyActList != value))
				{
					this.OnDenyActListChanging(value);
					this.SendPropertyChanging();
					this._DenyActList = value;
					this.SendPropertyChanged("DenyActList");
					this.OnDenyActListChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="NVarChar(32) NOT NULL", CanBeNull=false)]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DepartmentId", DbType="Int")]
		public System.Nullable<int> DepartmentId
		{
			get
			{
				return this._DepartmentId;
			}
			set
			{
				if ((this._DepartmentId != value))
				{
					this.OnDepartmentIdChanging(value);
					this.SendPropertyChanging();
					this._DepartmentId = value;
					this.SendPropertyChanged("DepartmentId");
					this.OnDepartmentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExtensionNum", DbType="NVarChar(16)")]
		public string ExtensionNum
		{
			get
			{
				return this._ExtensionNum;
			}
			set
			{
				if ((this._ExtensionNum != value))
				{
					this.OnExtensionNumChanging(value);
					this.SendPropertyChanging();
					this._ExtensionNum = value;
					this.SendPropertyChanged("ExtensionNum");
					this.OnExtensionNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserTitle", DbType="NVarChar(256)")]
		public string UserTitle
		{
			get
			{
				return this._UserTitle;
			}
			set
			{
				if ((this._UserTitle != value))
				{
					this.OnUserTitleChanging(value);
					this.SendPropertyChanging();
					this._UserTitle = value;
					this.SendPropertyChanged("UserTitle");
					this.OnUserTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RemarkText", DbType="NVarChar(2048)")]
		public string RemarkText
		{
			get
			{
				return this._RemarkText;
			}
			set
			{
				if ((this._RemarkText != value))
				{
					this.OnRemarkTextChanging(value);
					this.SendPropertyChanging();
					this._RemarkText = value;
					this.SendPropertyChanged("RemarkText");
					this.OnRemarkTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateBy", DbType="Int NOT NULL")]
		public int CreateBy
		{
			get
			{
				return this._CreateBy;
			}
			set
			{
				if ((this._CreateBy != value))
				{
					this.OnCreateByChanging(value);
					this.SendPropertyChanging();
					this._CreateBy = value;
					this.SendPropertyChanged("CreateBy");
					this.OnCreateByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyBy", DbType="Int NOT NULL")]
		public int ModifyBy
		{
			get
			{
				return this._ModifyBy;
			}
			set
			{
				if ((this._ModifyBy != value))
				{
					this.OnModifyByChanging(value);
					this.SendPropertyChanging();
					this._ModifyBy = value;
					this.SendPropertyChanged("ModifyBy");
					this.OnModifyByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifyDate
		{
			get
			{
				return this._ModifyDate;
			}
			set
			{
				if ((this._ModifyDate != value))
				{
					this.OnModifyDateChanging(value);
					this.SendPropertyChanging();
					this._ModifyDate = value;
					this.SendPropertyChanged("ModifyDate");
					this.OnModifyDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserInfo_UserRole", Storage="_SMS_UserRole", ThisKey="UserId", OtherKey="UserId")]
		public EntitySet<UserRole> UserRole
		{
			get
			{
				return this._SMS_UserRole;
			}
			set
			{
				this._SMS_UserRole.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_SMS_UserRole(UserRole entity)
		{
			this.SendPropertyChanging();
			entity.UserInfo = this;
		}
		
		private void detach_SMS_UserRole(UserRole entity)
		{
			this.SendPropertyChanging();
			entity.UserInfo = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserRole")]
	public partial class UserRole : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private int _RoleId;
		
		private int _CreateBy;
		
		private System.DateTime _CreateDate;
		
		private int _ModifyBy;
		
		private System.DateTime _ModifyDate;
		
		private EntityRef<RoleInfo> _SMS_RoleInfo;
		
		private EntityRef<UserInfo> _SMS_UserInfo;
		
    #region 擴充性方法定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnRoleIdChanging(int value);
    partial void OnRoleIdChanged();
    partial void OnCreateByChanging(int value);
    partial void OnCreateByChanged();
    partial void OnCreateDateChanging(System.DateTime value);
    partial void OnCreateDateChanged();
    partial void OnModifyByChanging(int value);
    partial void OnModifyByChanged();
    partial void OnModifyDateChanging(System.DateTime value);
    partial void OnModifyDateChanged();
    #endregion
		
		public UserRole()
		{
			this._SMS_RoleInfo = default(EntityRef<RoleInfo>);
			this._SMS_UserInfo = default(EntityRef<UserInfo>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._SMS_UserInfo.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int RoleId
		{
			get
			{
				return this._RoleId;
			}
			set
			{
				if ((this._RoleId != value))
				{
					if (this._SMS_RoleInfo.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRoleIdChanging(value);
					this.SendPropertyChanging();
					this._RoleId = value;
					this.SendPropertyChanged("RoleId");
					this.OnRoleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateBy", DbType="Int NOT NULL")]
		public int CreateBy
		{
			get
			{
				return this._CreateBy;
			}
			set
			{
				if ((this._CreateBy != value))
				{
					this.OnCreateByChanging(value);
					this.SendPropertyChanging();
					this._CreateBy = value;
					this.SendPropertyChanged("CreateBy");
					this.OnCreateByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyBy", DbType="Int NOT NULL")]
		public int ModifyBy
		{
			get
			{
				return this._ModifyBy;
			}
			set
			{
				if ((this._ModifyBy != value))
				{
					this.OnModifyByChanging(value);
					this.SendPropertyChanging();
					this._ModifyBy = value;
					this.SendPropertyChanged("ModifyBy");
					this.OnModifyByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifyDate
		{
			get
			{
				return this._ModifyDate;
			}
			set
			{
				if ((this._ModifyDate != value))
				{
					this.OnModifyDateChanging(value);
					this.SendPropertyChanging();
					this._ModifyDate = value;
					this.SendPropertyChanged("ModifyDate");
					this.OnModifyDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="RoleInfo_UserRole", Storage="_SMS_RoleInfo", ThisKey="RoleId", OtherKey="RoleId", IsForeignKey=true)]
		public RoleInfo RoleInfo
		{
			get
			{
				return this._SMS_RoleInfo.Entity;
			}
			set
			{
				RoleInfo previousValue = this._SMS_RoleInfo.Entity;
				if (((previousValue != value) 
							|| (this._SMS_RoleInfo.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._SMS_RoleInfo.Entity = null;
						previousValue.UserRole.Remove(this);
					}
					this._SMS_RoleInfo.Entity = value;
					if ((value != null))
					{
						value.UserRole.Add(this);
						this._RoleId = value.RoleId;
					}
					else
					{
						this._RoleId = default(int);
					}
					this.SendPropertyChanged("RoleInfo");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserInfo_UserRole", Storage="_SMS_UserInfo", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public UserInfo UserInfo
		{
			get
			{
				return this._SMS_UserInfo.Entity;
			}
			set
			{
				UserInfo previousValue = this._SMS_UserInfo.Entity;
				if (((previousValue != value) 
							|| (this._SMS_UserInfo.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._SMS_UserInfo.Entity = null;
						previousValue.UserRole.Remove(this);
					}
					this._SMS_UserInfo.Entity = value;
					if ((value != null))
					{
						value.UserRole.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("UserInfo");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserPreference")]
	public partial class UserPreference : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _Name;
		
		private string _Value;
		
		private System.DateTime _CreateDate;
		
		private System.DateTime _ModifyDate;
		
    #region 擴充性方法定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnValueChanging(string value);
    partial void OnValueChanged();
    partial void OnCreateDateChanging(System.DateTime value);
    partial void OnCreateDateChanged();
    partial void OnModifyDateChanging(System.DateTime value);
    partial void OnModifyDateChanged();
    #endregion
		
		public UserPreference()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(256) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="NVarChar(MAX)")]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifyDate
		{
			get
			{
				return this._ModifyDate;
			}
			set
			{
				if ((this._ModifyDate != value))
				{
					this.OnModifyDateChanging(value);
					this.SendPropertyChanging();
					this._ModifyDate = value;
					this.SendPropertyChanged("ModifyDate");
					this.OnModifyDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
