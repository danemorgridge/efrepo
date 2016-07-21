# EFRepository

Note: I'm in the process of rewriting the documentation...

### 1. Installation

Get the EFRepo package from Nuget using the Nuget Manager in Visual Studio or using the Package Manager Console:

`PM> Install-Package EFRepo`

### 2. Add EF Data Model

EFRepository works using the ADO.NET Entity Data Model so you will need to add one or use an existing one.

### 3. Add Unit of Work class

The Unit of Work class provides access to the Entity Framework context from the Data Model. Add a class to your project and set the context in the constructor to a new instance of the entity model DbContext.

```
public class DataModelUnitOfWork : EFUnitOfWork
{
    public DataModelUnitOfWork()
    {
        Context = new YourDatabaseEntities();
    }
}
```

### 3. Add A Repository Class

A repository class is necessary for each entity type that you wish to interact with directly. This is because of how the DbContext works with types. For this example we have a Contact entity type. Additionally, you can wrap the repository class in an interface to allow for unit testing, mocking, etc.

```
public class ContactRepository : EFRepository<Contact>, IContactRepository
{
}

public interface IContactRepository : IRepository<Contact>
{
}
```

The repository class will inherit the following methods from the IRepository interface, which will provide most of the functionality you will need.

```
public interface IRepository<T> 
{
    IUnitOfWork UnitOfWork { get; set; }
    IQueryable<T> All();
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void Delete(int id);
    T Get(int id);
    void Delete(T entity);
}
```

### 4. Putting it all together

To use the repository, simply create an instance of it and an instance of the unit of work class, then set the `UnitOfWork` property on the repository instance. You can then use all 

```
ContactRepository repository = new ContactRepository();
DataModelUnitOfWork unitOfWork = new DataModelUnitOfWork();
repository.UnitOfWork = unitOfWork;
var allcontacts = repository.All().ToList();
```

If you make any changes (add, edit, delete) any entities, you will need to call the `Commit` method on the unit of work. This will call `SaveChanges` on the underlying `DbContext`

```
unitOfWork.Commit();
```

### Getting Help

Feel free to hit me up on twitter [@danemorgridge](https://twitter.com/danemorgridge) or via  [email](mailto:dane@projectsandbox.com) if you have any questions.

### Licensed under the MIT License

Copyright (c) 2016 Dane Morgridge

Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
and associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial 
portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT 
NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
