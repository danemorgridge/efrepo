namespace DbContextSample.Data
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static AddressRepository GetAddressRepository()
		{
			return new AddressRepository();
		}

		public static AddressRepository GetAddressRepository(IUnitOfWork unitOfWork)
		{
			var repository = new AddressRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static PersonRepository GetPersonRepository()
		{
			return new PersonRepository();
		}

		public static PersonRepository GetPersonRepository(IUnitOfWork unitOfWork)
		{
			var repository = new PersonRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}