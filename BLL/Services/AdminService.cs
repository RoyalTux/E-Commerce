//using System;
//using AutoMapper;
//using BLL.Dto;
//using BLL.Extensibility;
//using DLL.Extensibility.Entities;

//namespace BLL.Services
//{
//	internal class AdminService : IAdminService
//	{
//		private readonly IAccountServiceHelper _db;
//		private readonly IMapper _mapper;

//		public AdminService(IAccountServiceHelper db, IMapper mapper)
//		{
//			_db = db;
//			_mapper = mapper;
//		}

//		public bool AddCategory(CategoryDto categoryDto)
//		{
//			try
//			{
//				var category = _mapper.Map<Category>(categoryDto);
//				_db.Categories.Add(category);
//				_db.SaveChanges();
//			}
//			catch (Exception)
//			{
//				return false;
//			}
//			return true;
//		}

//		public bool UpdateCategory(CategoryDto categoryDto)
//		{
//			try
//			{
//				var category = _mapper.Map<Category>(categoryDto);
//				_db.Categories.Edit(category);
//				_db.SaveChanges();
//			}
//			catch (Exception)
//			{
//				return false;
//			}
//			return true;
//		}

//		public bool RemoveCategory(int id)
//		{
//			try
//			{
//				_db.Categories.DeleteById(id);
//				_db.SaveChanges();
//			}
//			catch (Exception)
//			{
//				return false;
//			}
//			return true;
//		}

//		public bool AddItemCharacteristic(ItemCharacteristicsDto itemCharacteristicsDto)
//		{
//			try
//			{
//				var itemCharacteristic = _mapper.Map<ItemCharacteristic>(itemCharacteristicsDto);
//				_db.Characteristics.Add(itemCharacteristic);
//				_db.SaveChanges();
//			}
//			catch (Exception)
//			{
//				return false;
//			}
//			return true;
//		}

//		public bool UpdateItemCharacteristic(ItemCharacteristicsDto itemCharacteristicsDto)
//		{
//			try
//			{
//				var itemCharacteristic = _mapper.Map<ItemCharacteristic>(itemCharacteristicsDto);
//				_db.Characteristics.Add(itemCharacteristic);
//				_db.SaveChanges();
//			}
//			catch (Exception)
//			{
//				return false;
//			}
//			return true;
//		}

//		public bool RemoveItemCharacteristic(int id)
//		{
//			try
//			{
//				_db.Characteristics.DeleteById(id);
//				_db.SaveChanges();
//			}
//			catch (Exception)
//			{
//				return false;
//			}
//			return true;
//		}

//		public bool AddProduct(ItemDto itemDto)
//		{
//			try
//			{
//				var item = _mapper.Map<Item>(itemDto);
//				_db.Products.Add(item);
//				_db.SaveChanges();
//			}
//			catch (Exception)
//			{
//				return false;
//			}
//			return true;
//		}

//		public bool UpdateProduct(ItemDto itemDto)
//		{
//			try
//			{
//				var item = _mapper.Map<Item>(itemDto);
//				_db.Products.Edit(item);
//				_db.SaveChanges();
//			}
//			catch (Exception)
//			{
//				return false;
//			}
//			return true;
//		}

//		public bool RemoveProduct(int id)
//		{
//			try
//			{
//				_db.Products.DeleteById(id);
//				_db.SaveChanges();
//			}
//			catch (Exception)
//			{
//				return false;
//			}
//			return true;
//		}

//		public CategoryDto GetCategory(int id)
//		{
//			return _mapper.Map<CategoryDto>(_db.Categories.GetById(id));
//		}

//		public ItemCharacteristicsDto GetItemCharacteristics(int id)
//		{
//			return _mapper.Map<ItemCharacteristicsDto>(_db.Characteristics.GetById(id));
//		}

//		public ItemDto GetProduct(int id)
//		{
//			return _mapper.Map<ItemDto>(_db.Products.GetById(id));
//		}

//		public OrderDto GetOrder(int id)
//		{
//			return _mapper.Map<OrderDto>(_db.Orders.GetById(id));
//		}

//		public void Dispose(bool disposing)
//		{
//			_db.Dispose();
//		}
//	}
//}
