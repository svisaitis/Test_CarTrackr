﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarTrackr.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="ASPNETDB")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(CarTrackr.Domain.User instance);
    partial void UpdateUser(CarTrackr.Domain.User instance);
    partial void DeleteUser(CarTrackr.Domain.User instance);
    partial void InsertCar(CarTrackr.Domain.Car instance);
    partial void UpdateCar(CarTrackr.Domain.Car instance);
    partial void DeleteCar(CarTrackr.Domain.Car instance);
    partial void InsertRefuelling(CarTrackr.Domain.Refuelling instance);
    partial void UpdateRefuelling(CarTrackr.Domain.Refuelling instance);
    partial void DeleteRefuelling(CarTrackr.Domain.Refuelling instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ASPNETDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CarTrackr.Domain.User> Users
		{
			get
			{
				return this.GetTable<CarTrackr.Domain.User>();
			}
		}
		
		public System.Data.Linq.Table<CarTrackr.Domain.Car> Cars
		{
			get
			{
				return this.GetTable<CarTrackr.Domain.Car>();
			}
		}
		
		public System.Data.Linq.Table<CarTrackr.Domain.Refuelling> Refuellings
		{
			get
			{
				return this.GetTable<CarTrackr.Domain.Refuelling>();
			}
		}
	}
}
namespace CarTrackr.Domain
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.ComponentModel;
	using System;
	
	
	[Table(Name="dbo.aspnet_Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ApplicationId;
		
		private System.Guid _UserId;
		
		private string _UserName;
		
		private string _LoweredUserName;
		
		private string _MobileAlias;
		
		private bool _IsAnonymous;
		
		private System.DateTime _LastActivityDate;
		
		private EntitySet<Car> _Cars;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnApplicationIdChanging(System.Guid value);
    partial void OnApplicationIdChanged();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnLoweredUserNameChanging(string value);
    partial void OnLoweredUserNameChanged();
    partial void OnMobileAliasChanging(string value);
    partial void OnMobileAliasChanged();
    partial void OnIsAnonymousChanging(bool value);
    partial void OnIsAnonymousChanged();
    partial void OnLastActivityDateChanging(System.DateTime value);
    partial void OnLastActivityDateChanged();
    #endregion
		
		public User()
		{
			this._Cars = new EntitySet<Car>(new Action<Car>(this.attach_Cars), new Action<Car>(this.detach_Cars));
			OnCreated();
		}
		
		[Column(Storage="_ApplicationId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[Column(Storage="_UserId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid UserId
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
		
		[Column(Storage="_UserName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
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
		
		[Column(Storage="_LoweredUserName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string LoweredUserName
		{
			get
			{
				return this._LoweredUserName;
			}
			set
			{
				if ((this._LoweredUserName != value))
				{
					this.OnLoweredUserNameChanging(value);
					this.SendPropertyChanging();
					this._LoweredUserName = value;
					this.SendPropertyChanged("LoweredUserName");
					this.OnLoweredUserNameChanged();
				}
			}
		}
		
		[Column(Storage="_MobileAlias", DbType="NVarChar(16)")]
		public string MobileAlias
		{
			get
			{
				return this._MobileAlias;
			}
			set
			{
				if ((this._MobileAlias != value))
				{
					this.OnMobileAliasChanging(value);
					this.SendPropertyChanging();
					this._MobileAlias = value;
					this.SendPropertyChanged("MobileAlias");
					this.OnMobileAliasChanged();
				}
			}
		}
		
		[Column(Storage="_IsAnonymous", DbType="Bit NOT NULL")]
		public bool IsAnonymous
		{
			get
			{
				return this._IsAnonymous;
			}
			set
			{
				if ((this._IsAnonymous != value))
				{
					this.OnIsAnonymousChanging(value);
					this.SendPropertyChanging();
					this._IsAnonymous = value;
					this.SendPropertyChanged("IsAnonymous");
					this.OnIsAnonymousChanged();
				}
			}
		}
		
		[Column(Storage="_LastActivityDate", DbType="DateTime NOT NULL")]
		public System.DateTime LastActivityDate
		{
			get
			{
				return this._LastActivityDate;
			}
			set
			{
				if ((this._LastActivityDate != value))
				{
					this.OnLastActivityDateChanging(value);
					this.SendPropertyChanging();
					this._LastActivityDate = value;
					this.SendPropertyChanged("LastActivityDate");
					this.OnLastActivityDateChanged();
				}
			}
		}
		
		[Association(Name="User_Car", Storage="_Cars", OtherKey="OwnerId")]
		public EntitySet<Car> Cars
		{
			get
			{
				return this._Cars;
			}
			set
			{
				this._Cars.Assign(value);
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
		
		private void attach_Cars(Car entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Cars(Car entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[Table(Name="dbo.Car")]
	public partial class Car : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _OwnerId;
		
		private string _Make;
		
		private string _Model;
		
		private string _LicensePlate;
		
		private string _FuelType;
		
		private string _Description;
		
		private decimal _PurchasePrice;
		
		private EntitySet<Refuelling> _Refuellings;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnOwnerIdChanging(System.Guid value);
    partial void OnOwnerIdChanged();
    partial void OnMakeChanging(string value);
    partial void OnMakeChanged();
    partial void OnModelChanging(string value);
    partial void OnModelChanged();
    partial void OnLicensePlateChanging(string value);
    partial void OnLicensePlateChanged();
    partial void OnFuelTypeChanging(string value);
    partial void OnFuelTypeChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnPurchasePriceChanging(decimal value);
    partial void OnPurchasePriceChanged();
    #endregion
		
		public Car()
		{
			this._Refuellings = new EntitySet<Refuelling>(new Action<Refuelling>(this.attach_Refuellings), new Action<Refuelling>(this.detach_Refuellings));
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
		public System.Guid Id
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
		
		[Column(Storage="_OwnerId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid OwnerId
		{
			get
			{
				return this._OwnerId;
			}
			set
			{
				if ((this._OwnerId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOwnerIdChanging(value);
					this.SendPropertyChanging();
					this._OwnerId = value;
					this.SendPropertyChanged("OwnerId");
					this.OnOwnerIdChanged();
				}
			}
		}
		
		[Column(Storage="_Make", DbType="NVarChar(80) NOT NULL", CanBeNull=false)]
		public string Make
		{
			get
			{
				return this._Make;
			}
			set
			{
				if ((this._Make != value))
				{
					this.OnMakeChanging(value);
					this.SendPropertyChanging();
					this._Make = value;
					this.SendPropertyChanged("Make");
					this.OnMakeChanged();
				}
			}
		}
		
		[Column(Storage="_Model", DbType="NVarChar(80)")]
		public string Model
		{
			get
			{
				return this._Model;
			}
			set
			{
				if ((this._Model != value))
				{
					this.OnModelChanging(value);
					this.SendPropertyChanging();
					this._Model = value;
					this.SendPropertyChanged("Model");
					this.OnModelChanged();
				}
			}
		}
		
		[Column(Storage="_LicensePlate", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string LicensePlate
		{
			get
			{
				return this._LicensePlate;
			}
			set
			{
				if ((this._LicensePlate != value))
				{
					this.OnLicensePlateChanging(value);
					this.SendPropertyChanging();
					this._LicensePlate = value;
					this.SendPropertyChanged("LicensePlate");
					this.OnLicensePlateChanged();
				}
			}
		}
		
		[Column(Storage="_FuelType", DbType="NVarChar(20)")]
		public string FuelType
		{
			get
			{
				return this._FuelType;
			}
			set
			{
				if ((this._FuelType != value))
				{
					this.OnFuelTypeChanging(value);
					this.SendPropertyChanging();
					this._FuelType = value;
					this.SendPropertyChanged("FuelType");
					this.OnFuelTypeChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_PurchasePrice", DbType="decimal(16, 2) NOT NULL")]
		public decimal PurchasePrice
		{
			get
			{
				return this._PurchasePrice;
			}
			set
			{
				if ((this._PurchasePrice != value))
				{
					this.OnPurchasePriceChanging(value);
					this.SendPropertyChanging();
					this._PurchasePrice = value;
					this.SendPropertyChanged("PurchasePrice");
					this.OnPurchasePriceChanged();
				}
			}
		}
		
		[Association(Name="Car_Refuelling", Storage="_Refuellings", OtherKey="CarId")]
		public EntitySet<Refuelling> Refuellings
		{
			get
			{
				return this._Refuellings;
			}
			set
			{
				this._Refuellings.Assign(value);
			}
		}
		
		[Association(Name="User_Car", Storage="_User", ThisKey="OwnerId", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Cars.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Cars.Add(this);
						this._OwnerId = value.UserId;
					}
					else
					{
						this._OwnerId = default(System.Guid);
					}
					this.SendPropertyChanged("User");
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
		
		private void attach_Refuellings(Refuelling entity)
		{
			this.SendPropertyChanging();
			entity.Car = this;
		}
		
		private void detach_Refuellings(Refuelling entity)
		{
			this.SendPropertyChanging();
			entity.Car = null;
		}
	}
	
	[Table(Name="dbo.Refuelling")]
	public partial class Refuelling : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _CarId;
		
		private System.DateTime _Date;
		
		private string _ServiceStation;
		
		private decimal _Kilometers;
		
		private decimal _Liters;
		
		private decimal _PricePerLiter;
		
		private decimal _Total;
		
		private decimal _Usage;
		
		private EntityRef<Car> _Car;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnCarIdChanging(System.Guid value);
    partial void OnCarIdChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnServiceStationChanging(string value);
    partial void OnServiceStationChanged();
    partial void OnKilometersChanging(decimal value);
    partial void OnKilometersChanged();
    partial void OnLitersChanging(decimal value);
    partial void OnLitersChanged();
    partial void OnPricePerLiterChanging(decimal value);
    partial void OnPricePerLiterChanged();
    partial void OnTotalChanging(decimal value);
    partial void OnTotalChanged();
    partial void OnUsageChanging(decimal value);
    partial void OnUsageChanged();
    #endregion
		
		public Refuelling()
		{
			this._Car = default(EntityRef<Car>);
			OnCreated();
		}
		
		[Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
		public System.Guid Id
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
		
		[Column(Storage="_CarId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid CarId
		{
			get
			{
				return this._CarId;
			}
			set
			{
				if ((this._CarId != value))
				{
					if (this._Car.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCarIdChanging(value);
					this.SendPropertyChanging();
					this._CarId = value;
					this.SendPropertyChanged("CarId");
					this.OnCarIdChanged();
				}
			}
		}
		
		[Column(Storage="_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[Column(Storage="_ServiceStation", DbType="NVarChar(80) NOT NULL", CanBeNull=false)]
		public string ServiceStation
		{
			get
			{
				return this._ServiceStation;
			}
			set
			{
				if ((this._ServiceStation != value))
				{
					this.OnServiceStationChanging(value);
					this.SendPropertyChanging();
					this._ServiceStation = value;
					this.SendPropertyChanged("ServiceStation");
					this.OnServiceStationChanged();
				}
			}
		}
		
		[Column(Storage="_Kilometers", DbType="Decimal(18,0) NOT NULL")]
		public decimal Kilometers
		{
			get
			{
				return this._Kilometers;
			}
			set
			{
				if ((this._Kilometers != value))
				{
					this.OnKilometersChanging(value);
					this.SendPropertyChanging();
					this._Kilometers = value;
					this.SendPropertyChanged("Kilometers");
					this.OnKilometersChanged();
				}
			}
		}
		
		[Column(Storage="_Liters", DbType="Decimal(16,2) NOT NULL")]
		public decimal Liters
		{
			get
			{
				return this._Liters;
			}
			set
			{
				if ((this._Liters != value))
				{
					this.OnLitersChanging(value);
					this.SendPropertyChanging();
					this._Liters = value;
					this.SendPropertyChanged("Liters");
					this.OnLitersChanged();
				}
			}
		}
		
		[Column(Storage="_PricePerLiter", DbType="Decimal(16,3) NOT NULL")]
		public decimal PricePerLiter
		{
			get
			{
				return this._PricePerLiter;
			}
			set
			{
				if ((this._PricePerLiter != value))
				{
					this.OnPricePerLiterChanging(value);
					this.SendPropertyChanging();
					this._PricePerLiter = value;
					this.SendPropertyChanged("PricePerLiter");
					this.OnPricePerLiterChanged();
				}
			}
		}
		
		[Column(Storage="_Total", DbType="Decimal(16,2) NOT NULL")]
		public decimal Total
		{
			get
			{
				return this._Total;
			}
			set
			{
				if ((this._Total != value))
				{
					this.OnTotalChanging(value);
					this.SendPropertyChanging();
					this._Total = value;
					this.SendPropertyChanged("Total");
					this.OnTotalChanged();
				}
			}
		}
		
		[Column(Storage="_Usage", DbType="Decimal(16,2) NOT NULL")]
		public decimal Usage
		{
			get
			{
				return this._Usage;
			}
			set
			{
				if ((this._Usage != value))
				{
					this.OnUsageChanging(value);
					this.SendPropertyChanging();
					this._Usage = value;
					this.SendPropertyChanged("Usage");
					this.OnUsageChanged();
				}
			}
		}
		
		[Association(Name="Car_Refuelling", Storage="_Car", ThisKey="CarId", IsForeignKey=true)]
		public Car Car
		{
			get
			{
				return this._Car.Entity;
			}
			set
			{
				Car previousValue = this._Car.Entity;
				if (((previousValue != value) 
							|| (this._Car.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Car.Entity = null;
						previousValue.Refuellings.Remove(this);
					}
					this._Car.Entity = value;
					if ((value != null))
					{
						value.Refuellings.Add(this);
						this._CarId = value.Id;
					}
					else
					{
						this._CarId = default(System.Guid);
					}
					this.SendPropertyChanged("Car");
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